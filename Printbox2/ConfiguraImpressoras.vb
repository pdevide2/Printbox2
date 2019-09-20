Imports System.Data.SqlClient
Public Class ConfiguraImpressoras
    Private intOperacao As Integer = Operacao.Consulta

    Private Sub ConfiguraImpressoras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        intOperacao = Operacao.Consulta
        HabilitarCampos(intOperacao)

        StatusBotoes(intOperacao)


        'txtBuscaCPF.Visible = False
        Listar()

    End Sub

    Private Sub Listar()

        Dim dt = SqliteExecuteDataTable("select * from CONFIG_PRINTER")
        dg.DataSource = dt
        FormatarDG()
    End Sub

    Private Sub FormatarDG()
        dg.Columns(0).HeaderText = "Código"
        dg.Columns(1).HeaderText = "IP da Impressora"
        dg.Columns(2).HeaderText = "Descrição"
        dg.Columns(3).HeaderText = "Impressora Padrão?"

        dg.Columns(0).Width = 60
        dg.Columns(1).Width = 150
        dg.Columns(2).Width = 290
        dg.Columns(3).Width = 80

    End Sub

    Private Sub HabilitarCampos(_operacao As Integer)
        Dim blnMode As Boolean
        Select Case intOperacao
            Case Operacao.Consulta, Operacao.Exclusao
                blnMode = False
            Case Operacao.Novo, Operacao.Edicao
                blnMode = True
        End Select

        txtCodigo.Enabled = blnMode
        txtDescricao.Enabled = blnMode
        txtIPAddress.Enabled = blnMode
        ckPadrao.Enabled = blnMode


    End Sub
    Private Sub StatusBotoes(intOperacao As Integer)
        Select Case intOperacao
            Case Operacao.Consulta
                btnNovo.Enabled = True
                btnSalvar.Enabled = False
                btnDesfazer.Enabled = False
                btnAlterar.Enabled = False
                btnExcluir.Enabled = False
            Case Operacao.Novo, Operacao.Edicao
                btnNovo.Enabled = False
                btnSalvar.Enabled = True
                btnDesfazer.Enabled = True
                btnAlterar.Enabled = False
                btnExcluir.Enabled = False
            Case Operacao.Exclusao
                btnNovo.Enabled = False
                btnSalvar.Enabled = False
                btnDesfazer.Enabled = False
                btnAlterar.Enabled = False
                btnExcluir.Enabled = False

        End Select
    End Sub

    Private Sub BtnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        intOperacao = Operacao.Edicao
        HabilitarCampos(intOperacao)
        StatusBotoes(intOperacao)
    End Sub

    Private Sub BtnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        intOperacao = Operacao.Novo
        HabilitarCampos(intOperacao)
        Limpar()
        StatusBotoes(intOperacao)
    End Sub

    Private Sub Limpar()

        txtCodigo.Text = ""
        txtDescricao.Text = ""
        txtIPAddress.Text = ""
        ckPadrao.Checked = False

    End Sub

    Private Sub BtnDesfazer_Click(sender As Object, e As EventArgs) Handles btnDesfazer.Click

        intOperacao = Operacao.Consulta
        HabilitarCampos(intOperacao)
        StatusBotoes(intOperacao)
        Limpar()

    End Sub

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Dim sql As String = ""
        If Not ValidaCampos() Then

            Try
                If intOperacao = Operacao.Novo Then
                    sql = "insert into CONFIG_PRINTER (PRINTER_IP,DESC_PRINTER,IS_DEFAULT) VALUES ('{0}','{1}',{2})"
                    sql = String.Format(sql, txtIPAddress.Text, txtDescricao.Text, IIf(ckPadrao.Checked, 1, 0))

                    SqliteExecuteNonQuery(sql)

                Else
                    sql = "UPDATE CONFIG_PRINTER SET PRINTER_IP = '{0}',DESC_PRINTER = '{1}',IS_DEFAULT = {2} WHERE ID = {3}"
                    sql = String.Format(sql, txtIPAddress.Text, txtDescricao.Text, IIf(ckPadrao.Checked, 1, 0), CInt(txtCodigo.Text))

                    SqliteExecuteNonQuery(sql)

                End If



                MessageBox.Show("Atualizado com Sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Listar()
                Limpar()

            Catch ex As Exception
                MessageBox.Show("Erro ao salvar os dados " + ex.Message)
            Finally

                intOperacao = Operacao.Consulta
                HabilitarCampos(intOperacao)
                StatusBotoes(intOperacao)



            End Try
        End If

    End Sub

    Private Function ValidaCampos() As Boolean
        ValidaCampos = False
        If txtIPAddress.Text = "" Then
            ValidaCampos = True
        End If
    End Function

    Private Sub Dg_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg.CellClick
        btnNovo.Enabled = True
        btnAlterar.Enabled = True
        btnExcluir.Enabled = True

        txtCodigo.Text = dg.CurrentRow.Cells(0).Value
        txtIPAddress.Text = dg.CurrentRow.Cells(1).Value
        txtDescricao.Text = dg.CurrentRow.Cells(2).Value
        If dg.CurrentRow.Cells(3).Value = True Then
            ckPadrao.Checked = True
        Else
            ckPadrao.Checked = False
        End If

    End Sub

    Private Sub BtnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If MessageBox.Show("Confirma exclusão", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim sql As String = ""
            intOperacao = Operacao.Exclusao
            HabilitarCampos(intOperacao)
            StatusBotoes(intOperacao)

            Try
                sql = "DELETE FROM CONFIG_PRINTER WHERE ID = {0}"
                sql = String.Format(sql, CInt(txtCodigo.Text))

                SqliteExecuteNonQuery(sql)

                MessageBox.Show("Excluído com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Catch ex As Exception
                MessageBox.Show("Erro ao excluir os dados " + ex.Message)
            Finally
                intOperacao = Operacao.Consulta
                HabilitarCampos(intOperacao)
                StatusBotoes(intOperacao)

                Listar()

            End Try

        End If

    End Sub
End Class