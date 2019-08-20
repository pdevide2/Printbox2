Imports System.Data.SqlClient

Public Class FrmPrintPedido
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Listar()
    End Sub
    Private Sub Listar()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim sql As String = ""
        Try
            abrir()

            sql = "select pedido,caixa,venda,produto,cor_produto,filial,filial_origem,data, "
            sql += "qtde_total from caedu_reserva_automatica (nolock) where pedido = '" & Trim(txtPedido.Text) & "'"

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
        dg.Columns(0).HeaderText = "Pedido"
        dg.Columns(1).HeaderText = "Caixa"
        dg.Columns(2).HeaderText = "Venda"
        dg.Columns(3).HeaderText = "Produto"
        dg.Columns(4).HeaderText = "Cor Produto"
        dg.Columns(5).HeaderText = "Filial"
        dg.Columns(6).HeaderText = "Filial Origem"
        dg.Columns(7).HeaderText = "Data"
        dg.Columns(8).HeaderText = "Qtde Total"


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
End Class