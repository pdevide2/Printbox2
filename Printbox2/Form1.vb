Public Class Form1
    Private Sub DemoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DemoToolStripMenuItem.Click
        Dim form = New DemoPrint
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub ImprimirEtiquetasDeCaixasDoPedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirEtiquetasDeCaixasDoPedidoToolStripMenuItem.Click
        Dim form = New FrmPrintPedido
        form.MdiParent = Me
        form.Show()

    End Sub
End Class
