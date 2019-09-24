<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPrincipal
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrincipal))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArquivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirEtiquetasDeCaixasDoPedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirEtiquetasDeCaixasWMSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImprimirEtiquetasWMSImportadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImprimirEtiquetasDeCaixasEurekaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurarIPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SairToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConfigurarAmbienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArquivoToolStripMenuItem, Me.ConfigurarToolStripMenuItem, Me.SairToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1350, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArquivoToolStripMenuItem
        '
        Me.ArquivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirEtiquetasDeCaixasDoPedidoToolStripMenuItem, Me.ImprimirEtiquetasDeCaixasWMSToolStripMenuItem, Me.ToolStripMenuItem1, Me.ImprimirEtiquetasWMSImportadoToolStripMenuItem, Me.ToolStripMenuItem2, Me.ImprimirEtiquetasDeCaixasEurekaToolStripMenuItem})
        Me.ArquivoToolStripMenuItem.Name = "ArquivoToolStripMenuItem"
        Me.ArquivoToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ArquivoToolStripMenuItem.Text = "Arquivo"
        '
        'ImprimirEtiquetasDeCaixasDoPedidoToolStripMenuItem
        '
        Me.ImprimirEtiquetasDeCaixasDoPedidoToolStripMenuItem.Image = CType(resources.GetObject("ImprimirEtiquetasDeCaixasDoPedidoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImprimirEtiquetasDeCaixasDoPedidoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirEtiquetasDeCaixasDoPedidoToolStripMenuItem.Name = "ImprimirEtiquetasDeCaixasDoPedidoToolStripMenuItem"
        Me.ImprimirEtiquetasDeCaixasDoPedidoToolStripMenuItem.Size = New System.Drawing.Size(297, 38)
        Me.ImprimirEtiquetasDeCaixasDoPedidoToolStripMenuItem.Text = "Imprimir Etiquetas de Caixas do Pedido"
        '
        'ImprimirEtiquetasDeCaixasWMSToolStripMenuItem
        '
        Me.ImprimirEtiquetasDeCaixasWMSToolStripMenuItem.Image = CType(resources.GetObject("ImprimirEtiquetasDeCaixasWMSToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImprimirEtiquetasDeCaixasWMSToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirEtiquetasDeCaixasWMSToolStripMenuItem.Name = "ImprimirEtiquetasDeCaixasWMSToolStripMenuItem"
        Me.ImprimirEtiquetasDeCaixasWMSToolStripMenuItem.Size = New System.Drawing.Size(297, 38)
        Me.ImprimirEtiquetasDeCaixasWMSToolStripMenuItem.Text = "Imprimir Etiquetas de Caixas WMS"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(294, 6)
        '
        'ImprimirEtiquetasWMSImportadoToolStripMenuItem
        '
        Me.ImprimirEtiquetasWMSImportadoToolStripMenuItem.Image = CType(resources.GetObject("ImprimirEtiquetasWMSImportadoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImprimirEtiquetasWMSImportadoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirEtiquetasWMSImportadoToolStripMenuItem.Name = "ImprimirEtiquetasWMSImportadoToolStripMenuItem"
        Me.ImprimirEtiquetasWMSImportadoToolStripMenuItem.Size = New System.Drawing.Size(297, 38)
        Me.ImprimirEtiquetasWMSImportadoToolStripMenuItem.Text = "Imprimir Etiquetas WMS Importado"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(294, 6)
        '
        'ImprimirEtiquetasDeCaixasEurekaToolStripMenuItem
        '
        Me.ImprimirEtiquetasDeCaixasEurekaToolStripMenuItem.Image = CType(resources.GetObject("ImprimirEtiquetasDeCaixasEurekaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImprimirEtiquetasDeCaixasEurekaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImprimirEtiquetasDeCaixasEurekaToolStripMenuItem.Name = "ImprimirEtiquetasDeCaixasEurekaToolStripMenuItem"
        Me.ImprimirEtiquetasDeCaixasEurekaToolStripMenuItem.Size = New System.Drawing.Size(297, 38)
        Me.ImprimirEtiquetasDeCaixasEurekaToolStripMenuItem.Text = "Imprimir Etiquetas de Caixas Eureka"
        '
        'ConfigurarToolStripMenuItem
        '
        Me.ConfigurarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurarIPToolStripMenuItem, Me.ToolStripMenuItem3, Me.ConfigurarAmbienteToolStripMenuItem})
        Me.ConfigurarToolStripMenuItem.Name = "ConfigurarToolStripMenuItem"
        Me.ConfigurarToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.ConfigurarToolStripMenuItem.Text = "Configurar"
        '
        'ConfigurarIPToolStripMenuItem
        '
        Me.ConfigurarIPToolStripMenuItem.Image = CType(resources.GetObject("ConfigurarIPToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConfigurarIPToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConfigurarIPToolStripMenuItem.Name = "ConfigurarIPToolStripMenuItem"
        Me.ConfigurarIPToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.ConfigurarIPToolStripMenuItem.Text = "Configurar IP"
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SairToolStripMenuItem1})
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(38, 20)
        Me.SairToolStripMenuItem.Text = "Sair"
        '
        'SairToolStripMenuItem1
        '
        Me.SairToolStripMenuItem1.Image = CType(resources.GetObject("SairToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.SairToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SairToolStripMenuItem1.Name = "SairToolStripMenuItem1"
        Me.SairToolStripMenuItem1.Size = New System.Drawing.Size(109, 38)
        Me.SairToolStripMenuItem1.Text = "Sair"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(199, 6)
        '
        'ConfigurarAmbienteToolStripMenuItem
        '
        Me.ConfigurarAmbienteToolStripMenuItem.Image = CType(resources.GetObject("ConfigurarAmbienteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConfigurarAmbienteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConfigurarAmbienteToolStripMenuItem.Name = "ConfigurarAmbienteToolStripMenuItem"
        Me.ConfigurarAmbienteToolStripMenuItem.Size = New System.Drawing.Size(202, 38)
        Me.ConfigurarAmbienteToolStripMenuItem.Text = "Configurar Ambiente"
        '
        'FrmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1350, 729)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmPrincipal"
        Me.Text = "Printbox 2"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArquivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfigurarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SairToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SairToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ImprimirEtiquetasDeCaixasDoPedidoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImprimirEtiquetasDeCaixasWMSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ImprimirEtiquetasWMSImportadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ImprimirEtiquetasDeCaixasEurekaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfigurarIPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents ConfigurarAmbienteToolStripMenuItem As ToolStripMenuItem
End Class
