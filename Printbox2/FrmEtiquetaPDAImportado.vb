Imports System.Data.SqlClient

Public Class FrmEtiquetaPDAImportado

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
    End Sub

    Private Sub Dg2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg2.CellContentClick
        'http://www.vbforums.com/showthread.php?827863-Datagridview-Checkbox-Cell-won-t-check
        If e.ColumnIndex = 0 Then
            Dim cboSelected As DataGridViewCheckBoxCell = CType(dg2.Rows(e.RowIndex).Cells(0), DataGridViewCheckBoxCell)
            dg2.EndEdit()
            'MessageBox.Show(cboSelected.Value)
        End If
    End Sub
End Class