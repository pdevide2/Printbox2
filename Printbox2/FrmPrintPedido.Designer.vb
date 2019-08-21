<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrintPedido
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrintPedido))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPedido = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dg = New System.Windows.Forms.DataGridView()
        Me.lblTotalReg = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pedido nº"
        '
        'txtPedido
        '
        Me.txtPedido.Location = New System.Drawing.Point(72, 16)
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.Size = New System.Drawing.Size(100, 20)
        Me.txtPedido.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(185, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 25)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Pesquisar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.Location = New System.Drawing.Point(20, 65)
        Me.dg.Name = "dg"
        Me.dg.ReadOnly = True
        Me.dg.Size = New System.Drawing.Size(1080, 417)
        Me.dg.TabIndex = 3
        '
        'lblTotalReg
        '
        Me.lblTotalReg.AutoSize = True
        Me.lblTotalReg.Location = New System.Drawing.Point(1048, 49)
        Me.lblTotalReg.Name = "lblTotalReg"
        Me.lblTotalReg.Size = New System.Drawing.Size(50, 13)
        Me.lblTotalReg.TabIndex = 4
        Me.lblTotalReg.Text = " 0 Linhas"
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(214, 487)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(175, 47)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "QR Code Reduzido"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(392, 487)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(175, 47)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Imprimir Volume QR"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(570, 487)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(175, 47)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Imprimir Volume"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(748, 487)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(175, 47)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Imprimir Normal"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(926, 487)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(175, 47)
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "Fechar"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'FrmPrintPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1120, 536)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lblTotalReg)
        Me.Controls.Add(Me.dg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtPedido)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmPrintPedido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impressão de Etiquetas de Caixas de Pedido"
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtPedido As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents dg As DataGridView
    Friend WithEvents lblTotalReg As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
End Class
