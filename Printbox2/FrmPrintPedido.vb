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
        dg.Columns(5).Width = 160
        dg.Columns(6).HeaderText = "Filial Origem"
        dg.Columns(6).Width = 160
        dg.Columns(7).HeaderText = "Data"
        dg.Columns(7).Width = 70
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

            sql = " SELECT b.erp_cod_rota, "
            sql += "        b.erp_ordem_rota, "
            sql += "        a.pedido, "
            sql += "        a.caixa, "
            sql += "        a.venda, "
            sql += "        a.produto, "
            sql += "        a.filial, "
            sql += "        Sum(a.qtde_total) AS qtde_total "
            sql += " FROM   ( "
            sql += "             select pedido,caixa,venda,produto,cor_produto,filial,filial_origem,data, "
            sql += "             qtde_total from caedu_reserva_automatica (nolock) where pedido = '" & Trim(txtPedido.Text) & "' "
            sql += " ) a "
            sql += "        LEFT JOIN FILIAIS b "
            sql += "               ON a.filial = b.filial  "
            sql += " GROUP  BY a.pedido, "
            sql += "           a.caixa, "
            sql += "           a.venda, "
            sql += "           a.produto, "
            sql += "           a.filial, "
            sql += "           b.erp_cod_rota, "
            sql += "           b.erp_ordem_rota "
            sql += " ORDER  BY b.erp_cod_rota, "
            sql += "           a.filial, "
            sql += "           b.erp_ordem_rota, "
            sql += "           a.pedido, "
            sql += "           a.caixa "

            da = New SqlDataAdapter(sql, conn)
            da.Fill(dt)

            Dim _pedido As String, _caixa As String, _produto As String, _filial As String, _qtde_total As Integer

            For Each row As DataRow In dt.Rows
                _pedido = row("pedido").ToString
                _caixa = row("caixa").ToString
                _produto = row("produto").ToString
                _filial = row("filial").ToString
                _qtde_total = CInt(row("qtde_total"))
                Dim sZebraText = GeraTextoNormalPrint(_pedido, _caixa, _produto, _filial, _qtde_total)
                ImprimeZebraZT230(sZebraText)
            Next


        Catch ex As Exception
            MessageBox.Show("Erro na Pesquisa " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)


        Finally
            fechar()

        End Try


    End Sub

    Private Function GeraTextoNormalPrint(ByVal _pedido As String, ByVal _caixa As String,
                                           ByVal _produto As String, ByVal _filial As String, ByVal _qtde_total As Integer) As String
        Dim sZebraText As String
        Dim objProduto As New ProdutoInfo(_produto)
        Dim objFilial As New FilialInfo(_filial)
        Dim objCaixa As New CaixaInfo(_caixa)

        sZebraText = "CT~~CD,~CC^~CT~"
        sZebraText += "^XA~TA000~JSN^LT0^MNW^MTD^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ"
        sZebraText += "^XA"
        sZebraText += "^MMT"
        sZebraText += "^PW831"
        sZebraText += "^LL0208"
        sZebraText += "^LS0"
        sZebraText += "^FT39,57^A0N,25,24^FH\^FDP: " & _pedido & "^FS"
        sZebraText += "^FT38,156^A0N,28,28^FH\^FD" & objProduto.Colecao & "^FS"
        sZebraText += "^FT39,121^A0N,23,24^FH\^FD" & objProduto.Linha & "^FS"
        sZebraText += "^FT39,90^A0N,28,28^FH\^FD" & objProduto.Griffe & "^FS"
        sZebraText += "^BY3,3,72^FT331,102^BCN,,Y,N"
        sZebraText += "^FD>;" & _caixa & "^FS"
        sZebraText += "^FT664,152^A0N,34,33^FH\^FD" & "QTD." & _qtde_total.ToString & "^FS"
        sZebraText += "^FT684,60^A0N,28,28^FH\^FD" & objFilial.CodigoRota & "-" & objFilial.SufixoFilial & "^FS"
        sZebraText += "^FT571,157^A0N,17,16^FH\^FD" & objProduto.Categoria & "^FS"
        sZebraText += "^FT593,93^A0N,23,24^FH\^FD" & objCaixa.NomeCliFor & "^FS"
        sZebraText += "^PQ1,0,1,Y^XZ"

        Return sZebraText
    End Function
    Private Sub ImprimeZebraZT230(ByVal strTextoZebra)
        Dim ipAddress As String = "172.16.16.250"
        Dim port As Integer = 6101

        Try
            Dim client As System.Net.Sockets.TcpClient = New Net.Sockets.TcpClient()
            client.Connect(ipAddress, port)
            'client.Connect(ipAddress,)

            Dim writer As System.IO.StreamWriter = New System.IO.StreamWriter(client.GetStream())
            writer.Write(strTextoZebra)
            writer.Flush()

            'Fechando a conexao
            writer.Close()
            client.Close()


        Catch ex As Exception

        End Try
    End Sub

End Class