Imports System.Data.SqlClient

Public Class FrmEtiquetaPDAImportado

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

            sql += " SELECT CAST(1 AS BIT) AS SELECAO, produto FROM ( "
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
        For Each row As DataGridViewRow In dg.Rows
            row.Cells(0).Value = False
        Next
        For Each row As DataGridViewRow In dg2.Rows
            If row.Cells(0).Value = True Then
                MarcaProdutosSelecionados(row.Cells("produto").Value.ToString)
                Exit Sub
            End If
        Next
    End Sub
    Private Sub MarcaProdutosSelecionados(ByVal _produto As String)
        'For Each row As DataGridViewRow In dg.Rows
        '    If row.Cells("produto").Value.Equals(_produto) Then
        '        row.Cells(0).Value = True
        '    End If
        'Next
        Dim dt = TryCast(dg.DataSource, DataTable)

        Dim resultado = From dados In dt.AsEnumerable()
                        Where dados.Field(Of [String])("produto").Equals(_produto)
                        Select dados
        dg.DataSource = resultado.AsDataView().ToTable()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MarcaProdutosSelecionados(dg2.CurrentRow.Cells("produto").Value)
    End Sub
End Class