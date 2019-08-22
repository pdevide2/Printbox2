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
    Private Function GeraTextoVolumeCode128(ByVal _pedido As String, ByVal _produto As String,
                                            ByVal _pack As String, ByVal _volume As Integer, ByVal _qtde As Integer) As String
        Dim sZebraText As String
        Dim sVolume As String

        If _volume >= 1000 Then
            sVolume = Format(_volume, "0000")
        Else
            sVolume = Format(_volume, "000")
        End If
        sZebraText = "CT~~CD,~CC^~CT~"
        sZebraText += "^XA~TA000~JSN^LT0^MNW^MTD^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ"
        sZebraText += "^XA"
        sZebraText += "^MMT"
        sZebraText += "^PW831"
        sZebraText += "^LL0208"
        sZebraText += "^LS0"
        sZebraText += "^BY3,3,64^FT59,96^BCN,,Y,N"
        sZebraText += "^FD>:" & _pack & "|>" & _produto & ">6|>5" & _pedido & ">6|" & sVolume & "^FS"
        sZebraText += "^FT656,152^A0N,23,24^FH\^FDVol. " & _volume & "/" & _qtde & "^FS"
        sZebraText += "^FT511,152^A0N,23,24^FH\^FDQtde: " & _qtde & "^FS"
        sZebraText += "^FT267,152^A0N,23,24^FH\^FDProduto: " & _produto & "^FS"
        sZebraText += "^FT60,152^A0N,23,24^FH\^FDPedido: " & _pedido & "^FS"
        sZebraText += "^PQ1,0,1,Y^XZ"


        Return sZebraText
    End Function


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PrintVolumeBarcode128(txtPedido.Text)
    End Sub

    Private Sub PrintVolumeBarcode128(ByVal _pedido As String)
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim sql As String

        Try
            abrir()
            sql = " select	(select top 1 packs "
            sql += " 			from compras_produto cp "
            sql += " 			where cp.pedido = tab1.PEDIDO and cp.PRODUTO=tab1.PRODUTO) as pack, "
            sql += " 		tab1.* "
            sql += " from ( "
            sql += " select a.pedido, b.produto, count(B.produto) as qtd_cores, "
            sql += " max(CAST(TOT_QTDE_ORIGINAL/C.QTDE AS INT)) as qtde_total "
            sql += " from compras a "
            sql += " inner join compras_produto b on b.pedido = a.pedido "
            sql += " INNER JOIN CAEDU_COMPRAS_PRODUTOS_PACKS_TOTAL C ON C.PEDIDO = A.PEDIDO "
            sql += " where a.pedido= '" & _pedido & "' "
            sql += " group by a.pedido, b.produto) as tab1 "

            da = New SqlDataAdapter(sql, conn)
            da.Fill(dt)

            Dim _pack As String, _produto As String, _volume As Integer, _qtde As Integer

            For Each row As DataRow In dt.Rows
                _pack = row("pack").ToString
                _produto = row("produto").ToString
                _qtde = CInt(row("qtde_total"))

                If rbTodos.Checked Then
                    For i = 1 To _qtde
                        Dim sZebraText = GeraTextoVolumeCode128(_pedido, _produto, _pack, i, _qtde)
                        ImprimeZebraZT230(sZebraText)
                    Next
                End If

                If rbFaixa.Checked Then
                    For i = NumericUpDown1.Value To NumericUpDown2.Value
                        Dim sZebraText = GeraTextoVolumeCode128(_pedido, _produto, _pack, i, _qtde)
                        ImprimeZebraZT230(sZebraText)
                    Next
                End If

            Next

        Catch ex As Exception
            MessageBox.Show("Erro na Pesquisa " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            fechar()
        End Try



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PrintVolumeQRCode(txtPedido.Text)
    End Sub

    Private Sub PrintVolumeQRCode(ByVal _pedido As String)
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim sql As String

        Try
            abrir()
            sql = " select	(select top 1 packs "
            sql += " 			from compras_produto cp "
            sql += " 			where cp.pedido = tab1.PEDIDO and cp.PRODUTO=tab1.PRODUTO) as pack, "
            sql += " 		tab1.* "
            sql += " from ( "
            sql += " select a.pedido, b.produto, count(B.produto) as qtd_cores, "
            sql += " max(CAST(TOT_QTDE_ORIGINAL/C.QTDE AS INT)) as qtde_total "
            sql += " from compras a "
            sql += " inner join compras_produto b on b.pedido = a.pedido "
            sql += " INNER JOIN CAEDU_COMPRAS_PRODUTOS_PACKS_TOTAL C ON C.PEDIDO = A.PEDIDO "
            sql += " where a.pedido= '" & _pedido & "' "
            sql += " group by a.pedido, b.produto) as tab1 "

            da = New SqlDataAdapter(sql, conn)
            da.Fill(dt)

            Dim _pack As String, _produto As String, _volume As Integer, _qtde As Integer

            For Each row As DataRow In dt.Rows
                _pack = row("pack").ToString
                _produto = Trim(row("produto").ToString)
                _qtde = CInt(row("qtde_total"))

                If rbTodos.Checked Then
                    For i = 1 To _qtde
                        Dim sZebraText = GeraTextoVolumeQRCode(_pedido, _produto, _pack, i, _qtde)
                        ImprimeZebraZT230(sZebraText)
                    Next
                End If

                If rbFaixa.Checked Then
                    For i = NumericUpDown1.Value To NumericUpDown2.Value
                        Dim sZebraText = GeraTextoVolumeQRCode(_pedido, _produto, _pack, i, _qtde)
                        ImprimeZebraZT230(sZebraText)
                    Next
                End If

            Next

        Catch ex As Exception
            MessageBox.Show("Erro na Pesquisa " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            fechar()
        End Try

    End Sub

    Private Function GeraTextoVolumeQRCode(ByVal _pedido As String, ByVal _produto As String,
                                            ByVal _pack As String, ByVal _volume As Integer, ByVal _qtde As Integer) As String
        Dim sZebraText As String
        Dim sVolume As String

        If _volume >= 1000 Then
            sVolume = Format(_volume, "0000")
        Else
            sVolume = Format(_volume, "000")
        End If
        sZebraText = "CT~~CD,~CC^~CT~"
        sZebraText += "^XA~TA000~JSN^LT0^MNW^MTD^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ"
        sZebraText += "^XA"
        sZebraText += "^MMT"
        sZebraText += "^PW831"
        sZebraText += "^LL0208"
        sZebraText += "^LS0"
        sZebraText += "^FT193,165^BQN,2,4"
        sZebraText += "^FH\^FDLA," & _pack & "|" & _produto & "|" & Trim(_pedido) & "|" & sVolume & "^FS"
        sZebraText += "^FT323,81^A0N,28,28^FH\^FD" & _pack & "|" & _produto & "|" & Trim(_pedido) & "|" & sVolume & "^FS"
        sZebraText += "^FT451,145^A0N,28,28^FH\^FDVolume: " & _volume & "/" & _qtde & "^FS"
        sZebraText += "^PQ1,0,1,Y^XZ"

        Return sZebraText
    End Function

End Class
