
Imports System.Data.SqlClient
Public Class FrmPrintWMS
    Dim listaCodigos As List(Of Long)

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
        Dim i As Integer
        dg.Columns("distribuicao").HeaderText = "Distribuição"
        dg.Columns("caixa").HeaderText = "Caixa"
        dg.Columns("venda").HeaderText = "Venda"
        dg.Columns("produto").HeaderText = "Produto"
        dg.Columns("filial").HeaderText = "Filial"
        dg.Columns("filial").Width = 160
        dg.Columns("filial_origem").HeaderText = "Filial Origem"
        dg.Columns("filial_origem").Width = 160
        dg.Columns("qtde_total").HeaderText = "Qtde Total"
        dg.Columns("qtde_total").Width = 70
        dg.Columns("data").HeaderText = "Data"
        dg.Columns("pack").HeaderText = "Pack"
        dg.Columns("pack").Width = 55

        dg.Columns("qtde_pack").Visible = False
        dg.Columns("romaneio").Visible = False
        dg.Columns("gerado").Visible = False
        dg.Columns("pack").Visible = True

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
        PrintVolumeQRCode(txtDistribuicao.Text)
    End Sub
    Private Sub PrintVolumeQRCode(ByVal _pedido As String)
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim sql As String
        Dim i As Integer
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

    Private Sub BtnVolumeQRCodeReduzido_Click(sender As Object, e As EventArgs) Handles btnVolumeQRCodeReduzido.Click
        PrintVolumeQRCodeReduzido(txtDistribuicao.Text)
    End Sub

    Private Sub PrintVolumeQRCodeReduzido(ByVal _pedido As String)
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim sql As String
        Dim i As Integer
        Dim sHeader As String, sFooter As String
        Dim sBody(2) As String
        Dim sZebraText As String = ""
        Try
            abrir()

            sql = " select a.distribuicao as pedido, a.produto, count(a.produto) as qtd_cores, "
            sql += " count(a.QTDE_PACK) as qtde_total, max(a.pack) as packs, max(a.qtde_total) as qtde "
            sql += " from caedu_reserva_automatica_pack_wms a "
            sql += " where a.distribuicao= '" & _pedido & "' "
            sql += " group by a.distribuicao, a.produto "

            'sql = " select	(select top 1 packs "
            'sql += " 			from compras_produto cp "
            'sql += " 			where cp.pedido = tab1.PEDIDO and cp.PRODUTO=tab1.PRODUTO) as pack, "
            'sql += " 		tab1.* "
            'sql += " from ( "
            'sql += " select a.pedido, b.produto, count(B.produto) as qtd_cores, "
            'sql += " max(CAST(TOT_QTDE_ORIGINAL/C.QTDE AS INT)) as qtde_total "
            'sql += " from compras a "
            'sql += " inner join compras_produto b on b.pedido = a.pedido "
            'sql += " INNER JOIN CAEDU_COMPRAS_PRODUTOS_PACKS_TOTAL C ON C.PEDIDO = A.PEDIDO "
            'sql += " where a.pedido= '" & _pedido & "' "
            'sql += " group by a.pedido, b.produto) as tab1 "

            da = New SqlDataAdapter(sql, conn)
            da.Fill(dt)

            Dim _pack As String, _produto As String, _volume As Integer, _qtde As Integer

            For Each row As DataRow In dt.Rows
                _pack = row("packs").ToString
                _produto = Trim(row("produto").ToString)
                _qtde = CInt(row("qtde_total"))

                If rbTodos.Checked Then
                    i = 1
                    While i <= _qtde
                        sHeader = "CT~~CD,~CC^~CT~"
                        sHeader += "^XA~TA000~JSN^LT0^MNW^MTD^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ"
                        sHeader += "^XA"
                        sHeader += "^MMT"
                        sHeader += "^PW839"
                        sHeader += "^LL0232"
                        sHeader += "^LS0"
                        'Reseta a variavel que acumula os conteudos do corpo da etiqueta
                        sZebraText = ""
                        Dim nn As Integer
                        For nn = 1 To 3
                            sBody(nn - 1) = GeraTextoVolumeQRCodeReduzido(nn, _pedido, _produto, _pack, i, _qtde)
                            sZebraText += sBody(nn - 1)
                            i += 1
                            If i > _qtde Then
                                Exit For
                            End If
                        Next
                        sFooter = "^PQ1,0,1,Y^XZ"
                        sZebraText = sHeader & sZebraText & sFooter
                        ImprimeZebraZT230(sZebraText)

                    End While
                End If

                If rbFaixa.Checked Then
                    i = NumericUpDown1.Value
                    While i <= NumericUpDown2.Value
                        sHeader = "CT~~CD,~CC^~CT~"
                        sHeader += "^XA~TA000~JSN^LT0^MNW^MTD^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ"
                        sHeader += "^XA"
                        sHeader += "^MMT"
                        sHeader += "^PW839"
                        sHeader += "^LL0232"
                        sHeader += "^LS0"
                        'Reseta a variavel que acumula os conteudos do corpo da etiqueta
                        sZebraText = ""
                        Dim nn As Integer
                        For nn = 1 To 3
                            sBody(nn - 1) = GeraTextoVolumeQRCodeReduzido(nn, _pedido, _produto, _pack, i, _qtde)
                            sZebraText += sBody(nn - 1)
                            i += 1
                            If i > NumericUpDown2.Value Then
                                Exit For
                            End If
                        Next
                        sFooter = "^PQ1,0,1,Y^XZ"
                        sZebraText = sHeader & sZebraText & sFooter

                        'sZebraText = GeraTextoVolumeQRCode(_pedido, _produto, _pack, i, _qtde)
                        ImprimeZebraZT230(sZebraText)
                    End While
                End If

            Next

        Catch ex As Exception
            MessageBox.Show("Erro na Pesquisa " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            fechar()
        End Try

    End Sub
    Private Function GeraTextoVolumeQRCodeReduzido(ByVal _coluna As Integer, ByVal _pedido As String, ByVal _produto As String,
                                            ByVal _pack As String, ByVal _volume As Integer, ByVal _qtde As Integer) As String
        Dim sBody As String
        Dim sVolume As String
        Dim nColuna1 As Integer, nColuna2 As Integer, nColuna3 As Integer, nColuna4 As Integer, nColuna5 As Integer
        Dim nLinha1 As Integer, nLinha2 As Integer, nLinha3 As Integer, nLinha4 As Integer, nLinha5 As Integer

        If _volume >= 1000 Then
            sVolume = Format(_volume, "0000")
        Else
            sVolume = Format(_volume, "000")
        End If

        nLinha1 = 169
        nLinha2 = 169
        nLinha3 = 132
        nLinha4 = 95
        nLinha5 = 59

        Select Case _coluna
            Case 1
                nColuna1 = 29
                nColuna2 = 137
                nColuna3 = 138
                nColuna4 = 138
                nColuna5 = 137
            Case 2
                nColuna1 = 301
                nColuna2 = 409
                nColuna3 = 410
                nColuna4 = 410
                nColuna5 = 409
            Case 3
                nColuna1 = 572
                nColuna2 = 680
                nColuna3 = 681
                nColuna4 = 681
                nColuna5 = 680
        End Select


        sBody = "^FT" & nColuna1 & "," & nLinha1 & "^BQN,2,4"
        sBody += "^FH\^FDLA," & _pack & "|" & _produto & "|" & Trim(_pedido) & "|" & sVolume & "^FS" '"^FH\^FDLA,A|C8010064|00001451|012^FS"
        sBody += "^FT" & nColuna2 & "," & nLinha2 & "^A0N,28,28^FH\^FD" & sVolume & "/" & _qtde & "^FS"
        sBody += "^FT" & nColuna3 & "," & nLinha3 & "^A0N,28,28^FH\^FD" & Trim(_pedido) & "^FS"
        sBody += "^FT" & nColuna4 & "," & nLinha4 & "^A0N,28,28^FH\^FD" & Trim(_produto) & "^FS"
        sBody += "^FT" & nColuna5 & "," & nLinha5 & "^A0N,28,28^FH\^FD" & _pack & "^FS"

        'sZebraText = "CT~~CD,~CC^~CT~"
        'sZebraText += "^XA~TA000~JSN^LT0^MNW^MTD^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ"
        'sZebraText += "^XA"
        'sZebraText += "^MMT"
        'sZebraText += "^PW831"
        'sZebraText += "^LL0208"
        'sZebraText += "^LS0"
        'sZebraText += "^FT193,165^BQN,2,4"
        'sZebraText += "^FH\^FDLA," & _pack & "|" & _produto & "|" & Trim(_pedido) & "|" & sVolume & "^FS"
        'sZebraText += "^FT323,81^A0N,28,28^FH\^FD" & _pack & "|" & _produto & "|" & Trim(_pedido) & "|" & sVolume & "^FS"
        'sZebraText += "^FT451,145^A0N,28,28^FH\^FDVolume: " & _volume & "/" & _qtde & "^FS"
        'sZebraText += "^PQ1,0,1,Y^XZ"

        Return sBody
    End Function

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        NumericUpDown2.Value = NumericUpDown1.Value
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        NumericUpDown2.Minimum = NumericUpDown1.Value
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

            criarLista() 'Cria lista das caixas selecionadas para impressão


            For Each row As DataRow In dt.Rows
                _pedido = row("distribuicao").ToString
                _caixa = row("caixa").ToString
                _produto = row("produto").ToString
                _filial = row("filial").ToString
                _qtde_total = CInt(row("qtde_total"))

                If buscaSelecionado(CLng(_caixa)) <> -1 Then

                    Dim sZebraText = GeraTextoNormalPrintWMS(_pedido, _caixa, _produto, _filial, _qtde_total)
                    ImprimeZebraZT230(sZebraText)

                End If

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

        'sZebraText = "CT~~CD,~CC^~CT~"
        'sZebraText += "^XA~TA000~JSN^LT0^MNW^MTD^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ"
        'sZebraText += "^XA"
        'sZebraText += "^MMT"
        'sZebraText += "^PW831"
        'sZebraText += "^LL0208"
        'sZebraText += "^LS0"
        'sZebraText += "^FT39,57^A0N,25,24^FH\^FDD: " & _pedido & "^FS"
        'sZebraText += "^FT38,156^A0N,28,28^FH\^FD" & objProduto.Colecao & "^FS"
        'sZebraText += "^FT39,121^A0N,23,24^FH\^FD" & objProduto.Linha & "^FS"
        'sZebraText += "^FT39,90^A0N,28,28^FH\^FD" & objProduto.Griffe & "^FS"
        'sZebraText += "^BY3,3,72^FT301,102^BCN,,Y,N"
        'sZebraText += "^FD>;" & _caixa & "^FS"
        'sZebraText += "^FT664,152^A0N,34,33^FH\^FD" & "QTD." & _qtde_total.ToString & "^FS"
        'sZebraText += "^FT664,60^A0N,28,28^FH\^FD" & objFilial.CodigoRota & "-" & objFilial.SufixoFilial & "^FS"
        'sZebraText += "^FT571,157^A0N,17,16^FH\^FD" & objProduto.Categoria & "^FS"
        'sZebraText += "^FT533,93^A0N,23,24^FH\^FD" & objCaixa.NomeCliFor.PadLeft(25, " ") & "^FS"
        'sZebraText += "^PQ1,0,1,Y^XZ"

        sZebraText = "CT~~CD,~CC^~CT~"
        sZebraText += "^XA~TA000~JSN^LT0^MNW^MTD^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ"
        sZebraText += "^XA"
        sZebraText += "^MMT"
        sZebraText += "^PW831"
        sZebraText += "^LL0208"
        sZebraText += "^LS0"
        sZebraText += "^FT40,61^A0N,25,24^FH\^FDP: " & _pedido & "^FS"
        sZebraText += "^FT40,169^A0N,28,28^FH\^FD" & objProduto.Colecao & "^FS"
        sZebraText += "^FT40,132^A0N,23,24^FH\^FD" & objProduto.Linha & "^FS"
        sZebraText += "^FT40,100^A0N,28,28^FH\^FD" & objProduto.Griffe & "^FS"
        sZebraText += "^BY3,3,64^FT272,100^BCN,,Y,N"
        sZebraText += "^FD>;" & _caixa & "^FS"
        sZebraText += "^FT678,124^A0N,39,38^FH\^FDQTD. " & _qtde_total & "^FS"
        sZebraText += "^FT675,70^A0N,34,33^FH\^FD" & objFilial.CodigoRota & "^FS"
        sZebraText += "^FT532,128^A0N,23,24^FH\^FD" & objProduto.Categoria & "^FS"
        sZebraText += "^FT378,167^A0N,31,31^FH\^FD" & objCaixa.NomeCliFor.PadLeft(25, " ") & "^FS"
        sZebraText += "^PQ1,0,1,Y^XZ"


        Return sZebraText
    End Function

    Private Sub PrintVolumeBarcode128WMS(ByVal _pedido As String)
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim sql As String
        Dim i As Integer
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

    Private Sub criarLista()

        listaCodigos = New List(Of Long)()


        For Each row As DataGridViewRow In Me.dg.Rows

            If Not row.IsNewRow Then

                If row.Cells(0).Value = True Then
                    listaCodigos.Add(CLng(row.Cells("caixa").Value))
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
End Class