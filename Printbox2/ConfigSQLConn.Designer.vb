<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigSQLConn
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbProducao = New System.Windows.Forms.RadioButton()
        Me.rbHomolog = New System.Windows.Forms.RadioButton()
        Me.ckSpk = New System.Windows.Forms.CheckBox()
        Me.ckLinx = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ckLinx)
        Me.GroupBox1.Controls.Add(Me.ckSpk)
        Me.GroupBox1.Controls.Add(Me.rbHomolog)
        Me.GroupBox1.Controls.Add(Me.rbProducao)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(290, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Conexão Linx ERP"
        '
        'rbProducao
        '
        Me.rbProducao.AutoSize = True
        Me.rbProducao.Checked = True
        Me.rbProducao.Location = New System.Drawing.Point(18, 29)
        Me.rbProducao.Name = "rbProducao"
        Me.rbProducao.Size = New System.Drawing.Size(93, 17)
        Me.rbProducao.TabIndex = 0
        Me.rbProducao.TabStop = True
        Me.rbProducao.Text = "Linx Produção"
        Me.rbProducao.UseVisualStyleBackColor = True
        '
        'rbHomolog
        '
        Me.rbHomolog.AutoSize = True
        Me.rbHomolog.Location = New System.Drawing.Point(18, 66)
        Me.rbHomolog.Name = "rbHomolog"
        Me.rbHomolog.Size = New System.Drawing.Size(113, 17)
        Me.rbHomolog.TabIndex = 1
        Me.rbHomolog.Text = "Linx Homologação"
        Me.rbHomolog.UseVisualStyleBackColor = True
        '
        'ckSpk
        '
        Me.ckSpk.AutoSize = True
        Me.ckSpk.Checked = True
        Me.ckSpk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckSpk.Location = New System.Drawing.Point(148, 66)
        Me.ckSpk.Name = "ckSpk"
        Me.ckSpk.Size = New System.Drawing.Size(52, 17)
        Me.ckSpk.TabIndex = 2
        Me.ckSpk.Text = "\SPK"
        Me.ckSpk.UseVisualStyleBackColor = True
        '
        'ckLinx
        '
        Me.ckLinx.AutoSize = True
        Me.ckLinx.Location = New System.Drawing.Point(206, 67)
        Me.ckLinx.Name = "ckLinx"
        Me.ckLinx.Size = New System.Drawing.Size(55, 17)
        Me.ckLinx.TabIndex = 3
        Me.ckLinx.Text = "\LINX"
        Me.ckLinx.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(239, 156)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Aplicar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ConfigSQLConn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 188)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ConfigSQLConn"
        Me.Text = "ConfigSQLConn"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ckLinx As CheckBox
    Friend WithEvents ckSpk As CheckBox
    Friend WithEvents rbHomolog As RadioButton
    Friend WithEvents rbProducao As RadioButton
    Friend WithEvents Button1 As Button
End Class
