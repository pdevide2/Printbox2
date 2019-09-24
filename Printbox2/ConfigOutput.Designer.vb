<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigOutput
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
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbRede = New System.Windows.Forms.RadioButton()
        Me.rbLocal = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSharedName = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSharedName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.rbLocal)
        Me.GroupBox1.Controls.Add(Me.rbRede)
        Me.GroupBox1.Location = New System.Drawing.Point(31, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(503, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opções de Impressão"
        '
        'rbRede
        '
        Me.rbRede.AutoSize = True
        Me.rbRede.Checked = True
        Me.rbRede.Location = New System.Drawing.Point(24, 29)
        Me.rbRede.Name = "rbRede"
        Me.rbRede.Size = New System.Drawing.Size(128, 17)
        Me.rbRede.TabIndex = 0
        Me.rbRede.TabStop = True
        Me.rbRede.Text = "Endereço IP de Rede"
        Me.rbRede.UseVisualStyleBackColor = True
        '
        'rbLocal
        '
        Me.rbLocal.AutoSize = True
        Me.rbLocal.Location = New System.Drawing.Point(24, 65)
        Me.rbLocal.Name = "rbLocal"
        Me.rbLocal.Size = New System.Drawing.Size(138, 17)
        Me.rbLocal.TabIndex = 1
        Me.rbLocal.Text = "Compartilhamento Local"
        Me.rbLocal.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(168, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nome Compartilhamento:"
        '
        'txtSharedName
        '
        Me.txtSharedName.Location = New System.Drawing.Point(299, 64)
        Me.txtSharedName.Name = "txtSharedName"
        Me.txtSharedName.Size = New System.Drawing.Size(186, 20)
        Me.txtSharedName.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(423, 128)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Aplicar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ConfigOutput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(565, 176)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ConfigOutput"
        Me.Text = "Configurar Saida da Impressora"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtSharedName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents rbLocal As RadioButton
    Friend WithEvents rbRede As RadioButton
    Friend WithEvents Button1 As Button
End Class
