Public Class ConfigSQLConn
    Private Sub CkSpk_CheckedChanged(sender As Object, e As EventArgs) Handles ckSpk.CheckedChanged
        If ckSpk.Checked Then
            ckLinx.Checked = False
        Else
            ckLinx.Checked = True
        End If
    End Sub

    Private Sub CkLinx_CheckedChanged(sender As Object, e As EventArgs) Handles ckLinx.CheckedChanged
        If ckLinx.Checked Then
            ckSpk.Checked = False
        Else
            ckSpk.Checked = True
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AplicarAlteracoes()
    End Sub

    Private Sub AplicarAlteracoes()

        Try

            PersisteAmbiente(IIf(rbProducao.Checked, 1, 2), IIf(ckSpk.Checked, 1, 2))

            MessageBox.Show("Atualizado com Sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Catch ex As Exception
            MessageBox.Show("Erro ao salvar os dados " + ex.Message)
        Finally


        End Try


    End Sub

    Private Sub ConfigSQLConn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _id_ambiente As Integer = GetAmbiente("AMBIENTE")
        Dim _id_homolog As Integer = GetAmbiente("HOMOLOG")

        If _id_ambiente = 1 Then
            rbProducao.Checked = True
            rbHomolog.Checked = False
        Else
            rbProducao.Checked = False
            rbHomolog.Checked = True
        End If

        If _id_homolog = 1 Then
            ckSpk.Checked = True
            ckLinx.Checked = False
        Else
            ckSpk.Checked = False
            ckLinx.Checked = True
        End If

    End Sub
End Class