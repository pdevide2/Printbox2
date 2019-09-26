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

    Private Sub TesteClasseToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim form = New TestClass
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub ImprimirEtiquetasDeCaixasWMSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirEtiquetasDeCaixasWMSToolStripMenuItem.Click
        Dim form = New FrmPrintWMS
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub ImprimirEtiquetasWMSImportadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirEtiquetasWMSImportadoToolStripMenuItem.Click
        Dim form = New FrmEtiquetaPDAImportado
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub ImprimirEtiquetasDeCaixasEurekaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirEtiquetasDeCaixasEurekaToolStripMenuItem.Click
        Dim form = New FrmPrintEureka
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub ConfigurarIPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurarIPToolStripMenuItem.Click
        Dim form = New ConfiguraImpressoras
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub ConfigurarAmbienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurarAmbienteToolStripMenuItem.Click
        Dim form = New ConfigSQLConn
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub ConfigurarSaídaDaImpressoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurarSaídaDaImpressoraToolStripMenuItem.Click
        Dim form = New ConfigOutput
        form.MdiParent = Me
        form.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form = New TestClass
        form.MdiParent = Me
        form.Show()
    End Sub
End Class
