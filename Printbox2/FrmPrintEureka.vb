Imports System.Data.SqlClient

Public Class FrmPrintEureka
    Dim listaCodigos As List(Of Long)


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Listar()
    End Sub
    Private Sub Listar()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim sql As String = ""
        Try
            abrir()


            sql = " SELECT TAB1.*, FILIAL, erp_ordem_rota, erp_cod_rota"
            sql += " FROM ("
            sql += " select a.CODIGO_FILIAL, a.PEDIDO, a.CAIXA_EUREKA, COUNT(*) AS VOLUMES, SUM(CAIXA_QTDE) AS TOTAL_PECAS "
            sql += " from PDA_WMS_TB_CX_EUREKA a"
            sql += " where a.pedido = '" & Trim(txtPedido.Text) & "'"
            sql += " GROUP BY CODIGO_FILIAL, PEDIDO, CAIXA_EUREKA ) AS TAB1"
            sql += " inner join FILIAIS f on f.COD_FILIAL = tab1.CODIGO_FILIAL"

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

        Dim coluna As New DataGridViewCheckBoxColumn()
        With coluna
            .HeaderText = "Secionar"
            .Name = "colSelecao"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .FlatStyle = FlatStyle.Standard
            .CellTemplate = New DataGridViewCheckBoxCell()
            .CellTemplate.Style.BackColor = Color.Beige
        End With
        dg.Columns.Insert(0, coluna)

        For i = 1 To dg.DisplayedColumnCount(True) - 1
            dg.Columns(i).ReadOnly = True
        Next
        'Marca todas as colunas como True (flagado)
        For Each row As DataGridViewRow In dg.Rows
            row.Cells(0).Value = True
        Next
    End Sub
    Private Sub ContarLinhas()
        Try
            If dg.Rows.Count > 0 Then

                Dim intTotal As Integer = dg.Rows.Count '- 1
                lblTotalReg.Text = CInt(intTotal) & " Linhas"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        PrintNormal()
    End Sub

    Private Sub PrintNormal()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim sql As String

        Try

            abrir()

            sql = " SELECT TAB1.*, FILIAL, erp_ordem_rota, erp_cod_rota"
            sql += " FROM ("
            sql += " select a.CODIGO_FILIAL, a.PEDIDO, a.CAIXA_EUREKA, COUNT(*) AS VOLUMES, SUM(CAIXA_QTDE) AS TOTAL_PECAS "
            sql += " from PDA_WMS_TB_CX_EUREKA a"
            sql += " where a.pedido = '" & Trim(txtPedido.Text) & "'"
            sql += " GROUP BY CODIGO_FILIAL, PEDIDO, CAIXA_EUREKA ) AS TAB1"
            sql += " inner join FILIAIS f on f.COD_FILIAL = tab1.CODIGO_FILIAL"

            da = New SqlDataAdapter(sql, conn)
            da.Fill(dt)

            Dim _pedido As String, _caixa As String, _rota As String, _filial As String, _qtde_total As Integer, _volumes As Integer

            criarLista() 'Cria lista das caixas selecionadas para impressão

            For Each row As DataRow In dt.Rows
                _pedido = row("pedido").ToString
                _caixa = row("caixa_eureka").ToString
                _rota = row("erp_cod_rota").ToString & " - " & row("codigo_filial").Substring(row("codigo_filial").Length - 3, 3)
                _filial = row("filial").ToString
                _qtde_total = CInt(row("total_pecas"))
                _volumes = CInt(row("volumes"))

                ' Pesquisa a caixa no datagrid - se encontrou e estiver selecionada então imprime
                If buscaSelecionado(CLng(_caixa)) <> -1 Then

                    Dim sZebraText = GeraTextoNormalPrint(_pedido, _caixa, _rota, _filial, _qtde_total, _volumes)
                    ImprimeZebraZT230(sZebraText)

                End If

            Next


        Catch ex As Exception
            MessageBox.Show("Erro na Pesquisa " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)


        Finally
            fechar()

        End Try


    End Sub

    Private Function GeraTextoNormalPrint(ByVal _pedido As String, ByVal _caixa As String,
                                           ByVal _rota As String, ByVal _filial As String,
                                           ByVal _qtde_total As Integer, ByVal _volumes As Integer) As String
        Dim sZebraText As String

        sZebraText = "CT~~CD,~CC^~CT~"
        sZebraText += "^XA~TA000~JSN^LT0^MNW^MTD^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ"
        sZebraText += "^XA"
        sZebraText += "^MMT"
        sZebraText += "^PW831"
        sZebraText += "^LL0208"
        sZebraText += "^LS0"
        sZebraText += "^BY2,3,80^FT50,117^BCN,,Y,N"
        sZebraText += "^FD>:E>5" & _caixa & ">6|" & _volumes & "|" & _qtde_total & "^FS"
        sZebraText += "^FT616,137^A0N,28,28^FH\^FDVOL. " & _volumes & "^FS"
        sZebraText += "^FT490,137^A0N,28,28^FH\^FDQTD. " & _qtde_total & "^FS"
        sZebraText += "^FT489,101^A0N,23,24^FH\^FD" & _filial & "^FS"
        sZebraText += "^FT489,69^A0N,28,28^FH\^FD" & _rota & "^FS"
        sZebraText += "^PQ1,0,1,Y^XZ"

        Return sZebraText
    End Function


    Private Sub BtnMarcar_Click(sender As Object, e As EventArgs) Handles btnMarcar.Click
        If btnMarcar.Text = "Desmarcar Tudo" Then
            'Marca todas as colunas como True (flagado)
            For Each row As DataGridViewRow In dg.Rows
                row.Cells(0).Value = False
            Next

            btnMarcar.Text = "Marcar Tudo"
        Else
            'Marca todas as colunas como True (flagado)
            For Each row As DataGridViewRow In dg.Rows
                row.Cells(0).Value = True
            Next

            btnMarcar.Text = "Desmarcar Tudo"
        End If
    End Sub

    Private Sub criarLista()

        listaCodigos = New List(Of Long)()


        For Each row As DataGridViewRow In Me.dg.Rows

            If Not row.IsNewRow Then

                If row.Cells(0).Value = True Then
                    listaCodigos.Add(CLng(row.Cells("caixa_eureka").Value))
                End If

            End If

        Next

    End Sub

    Private Function buscaSelecionado(_caixa As Long) As Long

        'criarLista()

        Dim retCodigo As Integer


        retCodigo = listaCodigos.IndexOf(_caixa)

        'If retCodigo = -1 Then
        '    retCodigo = i
        'End If


        Return retCodigo

    End Function





End Class
