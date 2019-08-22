Public Class FrmPrincipal
    Private Sub DemoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim form = New DemoPrint
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub ImprimirEtiquetasDeCaixasDoPedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirEtiquetasDeCaixasDoPedidoToolStripMenuItem.Click
        Dim form = New FrmPrintPedido
        form.MdiParent = Me
        form.Show()

    End Sub

    Private Sub SairToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SairToolStripMenuItem1.Click
        Application.Exit()
    End Sub

    Private Sub TesteClasseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TesteClasseToolStripMenuItem.Click
        Dim form = New TestClass
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub ImprimirEtiquetasDeCaixasWMSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirEtiquetasDeCaixasWMSToolStripMenuItem.Click
        Dim form = New FrmPrintWMS
        form.MdiParent = Me
        form.Show()
    End Sub
End Class
