Public Class ConfigOutput

    Private Sub ConfigOutput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtSharedName.Text = Trim(My.Settings.SHARED_NAME)
        If My.Settings.OUTPUT_PRINTER.Equals(1) Then
            rbRede.Checked = True
            rbLocal.Checked = False
        Else
            rbRede.Checked = False
            rbLocal.Checked = True
        End If
    End Sub
    Private Sub AplicarAlteracoes()

        Try

            My.Settings.OUTPUT_PRINTER = IIf(rbRede.Checked, 1, 2)
            My.Settings.SHARED_NAME = Trim(txtSharedName.Text)
            My.Settings.Save()
            MessageBox.Show("Atualizado com Sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Catch ex As Exception
            MessageBox.Show("Erro ao salvar os dados " + ex.Message)
        Finally


        End Try


    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        AplicarAlteracoes()
    End Sub
End Class