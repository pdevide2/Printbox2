
Imports System.Data.SqlClient
Public Class FrmPrintWMS
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub FrmPrintWMS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Listar()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim sql As String = ""
        Try
            abrir()

            sql = " SELECT "
            sql += "        caedu_reserva_automatica_pack_wms.distribuicao , "
            sql += "        caedu_reserva_automatica_pack_wms.caixa, "
            sql += "        caedu_reserva_automatica_pack_wms.venda, "
            sql += "        caedu_reserva_automatica_pack_wms.produto, "
            sql += "        caedu_reserva_automatica_pack_wms.filial, "
            sql += "        caedu_reserva_automatica_pack_wms.filial_origem, "
            sql += "        caedu_reserva_automatica_pack_wms.qtde_total, "
            sql += "        caedu_reserva_automatica_pack_wms.data, "
            sql += "        caedu_reserva_automatica_pack_wms.qtde_pack, "
            sql += "        caedu_reserva_automatica_pack_wms.romaneio, "
            sql += "        caedu_reserva_automatica_pack_wms.gerado, "
            sql += "        caedu_reserva_automatica_pack_wms.pack "
            sql += " FROM   caedu_reserva_automatica_pack_wms "
            sql += " where distribuicao = '" & Trim(txtDistribuicao.Text) & "' "
            sql += " ORDER  BY caedu_reserva_automatica_pack_wms.distribuicao, "
            sql += "           caedu_reserva_automatica_pack_wms.produto "

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
        dg.Columns(0).HeaderText = "Distribuição"
        dg.Columns(1).HeaderText = "Caixa"
        dg.Columns(2).HeaderText = "Venda"
        dg.Columns(3).HeaderText = "Produto"
        dg.Columns(4).HeaderText = "Filial"
        dg.Columns(4).Width = 160
        dg.Columns(5).HeaderText = "Filial Origem"
        dg.Columns(5).Width = 160
        dg.Columns(6).HeaderText = "Qtde Total"
        dg.Columns(6).Width = 70
        dg.Columns(7).HeaderText = "Data"
        For i = 8 To 11
            dg.Columns(i).Visible = False
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Listar()
    End Sub

    Private Sub BtnNormal_Click(sender As Object, e As EventArgs) Handles btnNormal.Click
        PrintNormalWMS()
    End Sub

    Private Sub BtnVolumeNormal_Click(sender As Object, e As EventArgs) Handles btnVolumeNormal.Click
        PrintVolumeBarcode128WMS(txtDistribuicao.Text)
    End Sub

    Private Sub BtnVolumeQRCode_Click(sender As Object, e As EventArgs) Handles btnVolumeQRCode.Click

    End Sub

    Private Sub BtnVolumeQRCodeReduzido_Click(sender As Object, e As EventArgs) Handles btnVolumeQRCodeReduzido.Click

    End Sub
    Private Sub PrintNormalWMS()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim sql As String

        Try

            abrir()

            sql = " SELECT	FILIAIS.erp_cod_rota, "
            sql += " 		FILIAIS.erp_ordem_rota, "
            sql += " 		TAB1.DISTRIBUICAO, "
            sql += " 		TAB1.CAIXA, "
            sql += " 		TAB1.VENDA, "
            sql += " 		TAB1.PRODUTO, "
            sql += " 		TAB1.FILIAL, "
            sql += " 		SUM(TAB1.QTDE_TOTAL) AS QTDE_TOTAL "
            sql += " FROM ( "
            sql += " SELECT 	"
            sql += "        caedu_reserva_automatica_pack_wms.distribuicao , "
            sql += "        caedu_reserva_automatica_pack_wms.caixa, "
            sql += "        caedu_reserva_automatica_pack_wms.venda, "
            sql += "        caedu_reserva_automatica_pack_wms.produto, "
            sql += "        caedu_reserva_automatica_pack_wms.filial, "
            sql += "        caedu_reserva_automatica_pack_wms.filial_origem, "
            sql += "        caedu_reserva_automatica_pack_wms.qtde_total, "
            sql += "        caedu_reserva_automatica_pack_wms.data, "
            sql += "        caedu_reserva_automatica_pack_wms.qtde_pack, "
            sql += "        caedu_reserva_automatica_pack_wms.romaneio,  "
            sql += "        caedu_reserva_automatica_pack_wms.gerado,  "
            sql += "        caedu_reserva_automatica_pack_wms.pack "
            sql += " FROM   caedu_reserva_automatica_pack_wms "
            sql += " where distribuicao = '" & txtDistribuicao.Text & "') AS TAB1 "
            sql += " INNER JOIN FILIAIS ON FILIAIS.FILIAL = TAB1.FILIAL "
            sql += " GROUP BY TAB1.DISTRIBUICAO, TAB1.CAIXA, TAB1.venda, TAB1.produto, TAB1.filial,FILIAIS.ERP_COD_ROTA,FILIAIS.ERP_ORDEM_ROTA "
            sql += " ORDER BY  FILIAIS.ERP_COD_ROTA,TAB1.filial,FILIAIS.ERP_ORDEM_ROTA,TAB1.DISTRIBUICAO , TAB1.CAIXA "

            da = New SqlDataAdapter(sql, conn)
            da.Fill(dt)

            Dim _pedido As String, _caixa As String, _produto As String, _filial As String, _qtde_total As Integer

            For Each row As DataRow In dt.Rows
                _pedido = row("distribuicao").ToString
                _caixa = row("caixa").ToString
                _produto = row("produto").ToString
                _filial = row("filial").ToString
                _qtde_total = CInt(row("qtde_total"))
                Dim sZebraText = GeraTextoNormalPrintWMS(_pedido, _caixa, _produto, _filial, _qtde_total)
                ImprimeZebraZT230(sZebraText)
            Next


        Catch ex As Exception
            MessageBox.Show("Erro na Pesquisa " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)


        Finally
            fechar()

        End Try


    End Sub

    Private Function GeraTextoNormalPrintWMS(ByVal _pedido As String, ByVal _caixa As String,
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
        sZebraText += "^FT39,57^A0N,25,24^FH\^FDD: " & _pedido & "^FS"
        sZebraText += "^FT38,156^A0N,28,28^FH\^FD" & objProduto.Colecao & "^FS"
        sZebraText += "^FT39,121^A0N,23,24^FH\^FD" & objProduto.Linha & "^FS"
        sZebraText += "^FT39,90^A0N,28,28^FH\^FD" & objProduto.Griffe & "^FS"
        sZebraText += "^BY3,3,72^FT301,102^BCN,,Y,N"
        sZebraText += "^FD>;" & _caixa & "^FS"
        sZebraText += "^FT664,152^A0N,34,33^FH\^FD" & "QTD." & _qtde_total.ToString & "^FS"
        sZebraText += "^FT664,60^A0N,28,28^FH\^FD" & objFilial.CodigoRota & "-" & objFilial.SufixoFilial & "^FS"
        sZebraText += "^FT571,157^A0N,17,16^FH\^FD" & objProduto.Categoria & "^FS"
        sZebraText += "^FT533,93^A0N,23,24^FH\^FD" & objCaixa.NomeCliFor.PadLeft(25, " ") & "^FS"
        sZebraText += "^PQ1,0,1,Y^XZ"

        Return sZebraText
    End Function

    Private Sub PrintVolumeBarcode128WMS(ByVal _pedido As String)
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim sql As String

        Try
            abrir()

            sql = " select a.distribuicao as pedido, a.produto, count(a.produto) as qtd_cores, "
            sql += " count(a.QTDE_PACK) as qtde_total, max(a.pack) as packs, max(a.qtde_total) as qtde "
            sql += " from caedu_reserva_automatica_pack_wms a "
            sql += " where a.distribuicao= '" & _pedido & "' "
            sql += " group by a.distribuicao, a.produto "

            da = New SqlDataAdapter(sql, conn)
            da.Fill(dt)

            Dim _pack As String, _produto As String, _volume As Integer, _qtde As Integer

            For Each row As DataRow In dt.Rows
                _pack = row("packs").ToString
                _produto = row("produto").ToString
                _qtde = CInt(row("qtde_total"))

                If rbTodos.Checked Then
                    For i = 1 To _qtde
                        Dim sZebraText = GeraTextoVolumeCode128WMS(_pedido, _produto, _pack, i, _qtde)
                        ImprimeZebraZT230(sZebraText)
                    Next
                End If

                If rbFaixa.Checked Then
                    For i = NumericUpDown1.Value To NumericUpDown2.Value
                        Dim sZebraText = GeraTextoVolumeCode128WMS(_pedido, _produto, _pack, i, _qtde)
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
    Private Function GeraTextoVolumeCode128WMS(ByVal _pedido As String, ByVal _produto As String,
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
        sZebraText += "^BY2,3,64^FT59,96^BCN,,Y,N"
        sZebraText += "^FD>:" & _pack & "|>" & _produto & ">6|>5" & _pedido & ">6|" & sVolume & "^FS"
        sZebraText += "^FT656,152^A0N,23,24^FH\^FDVol. " & _volume & "/" & _qtde & "^FS"
        sZebraText += "^FT511,152^A0N,23,24^FH\^FDQtde: " & _qtde & "^FS"
        sZebraText += "^FT267,152^A0N,23,24^FH\^FDProduto: " & _produto & "^FS"
        sZebraText += "^FT60,152^A0N,23,24^FH\^FDDistrib.: " & _pedido & "^FS"
        sZebraText += "^PQ1,0,1,Y^XZ"


        Return sZebraText
    End Function

End Class