Imports System.Data.SqlClient
Imports System.Diagnostics

Public Class FrmEtiquetaPDAImportado
    Private _intLinhas As Integer
    Public Property TotalLinhas() As Integer
        Get
            Return _intLinhas
        End Get
        Set(ByVal value As Integer)
            _intLinhas = value
        End Set
    End Property

    Dim listaProdutos As New List(Of String)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Pesquisar()
        PesquisarProdutos()

    End Sub

    Private Sub Pesquisar()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim sql As String = ""
        Try
            abrir()

            sql += " SELECT CAST(1 AS BIT) AS SELECAO, PACK,PRODUTO,NF,SERIE,A.ID_COLETA ETIQUETA,B.STATUS "
            sql += " FROM  PDA_WMS_TB_RECEBIMENTO_IMPORTADO_COLETA A "
            sql += " INNER JOIN PDA_WMS_TB_REC_CD_STATUS_RECEBIMENTO B "
            sql += " ON (LTRIM(RTRIM(A.NF))+' '+LTRIM(RTRIM(SERIE)) = B.PEDIDO) "
            sql += " WHERE B.STATUS>=3 "
            sql += " 	AND A.NF='" & txtNota.Text & "' AND SERIE='" & txtSerie.Text & "' "

            da = New SqlDataAdapter(sql, conn)
            da.Fill(dt)
            dg.DataSource = dt

            ContarLinhas()
            FormatarDG()

        Catch ex As Exception
            MessageBox.Show("Erro ao Listar " + ex.Message)
        Finally
            fechar()
        End Try

    End Sub
    Private Sub FormatarDG()
        Dim i As Integer
        For i = 1 To 6
            dg.Columns(i).ReadOnly = True
        Next
        'dg.Columns(0).Visible = False
        'dg.Columns("pedido").HeaderText = "Pedido"
        'dg.Columns("caixa").HeaderText = "Caixa"
        'dg.Columns("venda").HeaderText = "Venda"
        'dg.Columns("produto").HeaderText = "Produto"
        'dg.Columns("cor_produto").HeaderText = "Cor Produto"
        'dg.Columns("filial").HeaderText = "Filial"
        'dg.Columns("filial").Width = 160
        'dg.Columns("filial_origem").HeaderText = "Filial Origem"
        'dg.Columns("filial_origem").Width = 160
        'dg.Columns("data").HeaderText = "Data"
        'dg.Columns("data").Width = 70
        'dg.Columns("qtde_total").HeaderText = "Qtde Total"

        'Dim coluna As New DataGridViewCheckBoxColumn()
        'With coluna
        '    .HeaderText = "Secionar"
        '    .Name = "colSelecao"
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '    .FlatStyle = FlatStyle.Standard
        '    .CellTemplate = New DataGridViewCheckBoxCell()
        '    .CellTemplate.Style.BackColor = Color.Beige
        'End With
        'dg.Columns.Insert(0, coluna)

        'For i = 1 To dg.DisplayedColumnCount(True) - 1
        '    dg.Columns(i).ReadOnly = True
        'Next
        ''Marca todas as colunas como True (flagado)
        'For Each row As DataGridViewRow In dg.Rows
        '    row.Cells(0).Value = True
        'Next
    End Sub
    Private Sub ContarLinhas()
        Try
            If dg.Rows.Count > 0 Then

                Dim intTotal As Integer = dg.Rows.Count '- 1
                lblTotalReg.Text = CInt(intTotal) & " Linhas"
                TotalLinhas = CInt(intTotal)
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub PesquisarProdutos()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim sql As String = ""
        Try
            abrir()

            sql += " SELECT CAST(1 AS BIT) AS Selecao, Produto FROM ( "
            sql += " SELECT CAST(1 AS BIT) AS SELECAO, PACK,PRODUTO,NF,SERIE,A.ID_COLETA ETIQUETA,B.STATUS "
            sql += " FROM  PDA_WMS_TB_RECEBIMENTO_IMPORTADO_COLETA A "
            sql += " INNER JOIN PDA_WMS_TB_REC_CD_STATUS_RECEBIMENTO B "
            sql += " ON (LTRIM(RTRIM(A.NF))+' '+LTRIM(RTRIM(SERIE)) = B.PEDIDO) "
            sql += " WHERE B.STATUS>=3 "
            sql += " 	AND A.NF='" & txtNota.Text & "' AND SERIE='" & txtSerie.Text & "') vNotaFiscal01 "
            sql += " group by produto "
            sql += " order by produto "

            da = New SqlDataAdapter(sql, conn)
            da.Fill(dt)
            dg2.DataSource = dt
            dg2.Columns("produto").ReadOnly = True
            'ContarLinhas()
            'FormatarDG()

        Catch ex As Exception
            MessageBox.Show("Erro ao Listar " + ex.Message)
        Finally
            fechar()
        End Try

    End Sub

    Private Sub BtnMarcarProdutos_Click(sender As Object, e As EventArgs) Handles btnMarcarProdutos.Click
        If btnMarcarProdutos.Text = "Desmarcar Tudo" Then
            For Each row As DataGridViewRow In dg2.Rows
                row.Cells(0).Value = False
            Next

            btnMarcarProdutos.Text = "Marcar Tudo"
        Else
            For Each row As DataGridViewRow In dg2.Rows
                row.Cells(0).Value = True
            Next

            btnMarcarProdutos.Text = "Desmarcar Tudo"
        End If
    End Sub

    Private Sub LblMarcarProdutos_Click(sender As Object, e As EventArgs) Handles lblMarcarProdutos.Click
        Dim blnMarcado As Boolean = False
        For Each row As DataGridViewRow In dg.Rows
            row.Cells(0).Value = False
        Next
        listaProdutos.Clear()

        dg.CurrentCell = dg.Rows(0).Cells(1)


        For Each row As DataGridViewRow In dg2.Rows
            blnMarcado = row.Cells("selecao").Value
            If blnMarcado Then
                listaProdutos.Add(row.Cells("produto").Value)
            End If
        Next
        'Dim msg As String = ""
        'For Each s In listaProdutos
        '    msg += s & Chr(13)
        'Next
        'MessageBox.Show(msg)
        MarcaProdutosSelecionados()
    End Sub
    Private Sub MarcaProdutosSelecionados()
        Dim blnAchou As Boolean = False
        Dim i As Integer = 0
        For Each row As DataGridViewRow In dg.Rows
            blnAchou = listaProdutos.Contains(row.Cells("produto").Value)
            row.Cells(0).Value = blnAchou
            i += IIf(blnAchou, 1, 0)
        Next
        lblTotalReg.Text = i.ToString() & " Linhas"
        TotalLinhas = i
    End Sub

    Private Sub Dg2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg2.CellContentClick
        'http://www.vbforums.com/showthread.php?827863-Datagridview-Checkbox-Cell-won-t-check
        If e.ColumnIndex = 0 Then
            Dim cboSelected As DataGridViewCheckBoxCell = CType(dg2.Rows(e.RowIndex).Cells(0), DataGridViewCheckBoxCell)
            dg2.EndEdit()
            'MessageBox.Show(cboSelected.Value)
        End If
    End Sub

    Private Sub BtnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub BtnVolumeQRCode_Click(sender As Object, e As EventArgs) Handles btnVolumeQRCode.Click
        'PrintQRCode3Colunas()
    End Sub

    Private Sub PrintQRCode3Colunas()

        Dim sHeader As String, sFooter As String
        Dim sBody(2) As String
        Dim sZebraText As String = ""
        Dim nn As Integer

        Try
            Dim lista = EtiquetasWMSImportado.GetEtiquetas(dg)

            sHeader = "CT~~CD,~CC^~CT~"
            sHeader += "^XA~TA000~JSN^LT0^MNW^MTD^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ"
            sHeader += "^XA"
            sHeader += "^MMT"
            sHeader += "^PW839"
            sHeader += "^LL0232"
            sHeader += "^LS0"

            sFooter = "^PQ1,0,1,Y^XZ"
            nn = 1
            sBody(0) = ""
            sBody(1) = ""
            sBody(2) = ""
            sZebraText = ""

            For Each p As EtiquetasWMSImportado In lista

                'MessageBox.Show(p.Id & " - " & p.Produto)
                'Reseta a variavel que acumula os conteudos do corpo da etiqueta
                sBody(nn - 1) = GeraTextoVolumeQRCodeReduzido(nn, p.Nfe_num, p.NfeSerie, p.Produto, p.Pack, p.EtiquetaNum)
                sZebraText += sBody(nn - 1)

                nn += 1


                If (nn > 3) Or (p.Id = TotalLinhas) Then

                    sZebraText = sHeader & sZebraText & sFooter
                    ImprimeZebraZT230(sZebraText)
                    sZebraText = ""
                    nn = 1
                    sBody(0) = ""
                    sBody(1) = ""
                    sBody(2) = ""

                End If


            Next

        Catch ex As Exception
            MessageBox.Show("Erro ao Imprimir " + ex.Message)
        End Try

    End Sub
    Private Function GeraTextoVolumeQRCodeReduzido(ByVal _coluna As Integer, ByVal _nf As String, ByVal _serie As String,
                                            ByVal _produto As String, ByVal _pack As String, ByVal _etiqueta As Integer) As String
        Dim sBody As String
        Dim sVolume As String
        Dim nColuna1 As Integer, nColuna2 As Integer, nColuna3 As Integer, nColuna4 As Integer, nColuna5 As Integer, nColuna6 As Integer
        Dim nLinha1 As Integer, nLinha2 As Integer, nLinha3 As Integer, nLinha4 As Integer, nLinha5 As Integer, nLinha6 As Integer

        nLinha1 = 182
        nLinha2 = 164
        nLinha3 = 133
        nLinha4 = 102
        nLinha5 = 133
        nLinha6 = 72

        Select Case _coluna
            Case 1
                nColuna1 = 32
                nColuna2 = 138
                nColuna3 = 138
                nColuna4 = 138
                nColuna5 = 251
                nColuna6 = 138
            Case 2
                nColuna1 = 304
                nColuna2 = 410
                nColuna3 = 410
                nColuna4 = 410
                nColuna5 = 523
                nColuna6 = 410
            Case 3
                nColuna1 = 575
                nColuna2 = 681
                nColuna3 = 681
                nColuna4 = 681
                nColuna5 = 794
                nColuna6 = 681
        End Select

        sBody = "^FT" & nColuna1 & "," & nLinha1 & "^BQN,2,4"
        sBody += "^FH\^FDLA," & _pack & "|" & Trim(_produto) & "|" & Trim(_nf) & "|" & Trim(_serie) & "|" & _etiqueta & "^FS"
        sBody += "^FT" & nColuna2 & "," & nLinha2 & "^A0N,23,24^FH\^FD" & _etiqueta & "^FS"
        sBody += "^FT" & nColuna3 & "," & nLinha3 & "^A0N,23,24^FH\^FD" & Trim(_nf) & "^FS"
        sBody += "^FT" & nColuna4 & "," & nLinha4 & "^A0N,23,24^FH\^FD" & Trim(_produto) & "^FS"
        sBody += "^FT" & nColuna5 & "," & nLinha5 & "^A0N,23,24^FH\^FD" & Trim(_serie) & "^FS"
        sBody += "^FT" & nColuna6 & "," & nLinha6 & "^A0N,23,24^FH\^FD" & _pack & "^FS"


        Return sBody
    End Function

    Private Sub BtnVolumeQRCodeReduzido_Click(sender As Object, e As EventArgs) Handles btnVolumeQRCodeReduzido.Click
        PrintQRCode3Colunas()
    End Sub
End Class