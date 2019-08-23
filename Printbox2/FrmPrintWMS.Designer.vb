<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPrintWMS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrintWMS))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtDistribuicao = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotalReg = New System.Windows.Forms.Label()
        Me.dg = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.rbFaixa = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.btnNormal = New System.Windows.Forms.Button()
        Me.btnVolumeNormal = New System.Windows.Forms.Button()
        Me.btnVolumeQRCode = New System.Windows.Forms.Button()
        Me.btnVolumeQRCodeReduzido = New System.Windows.Forms.Button()
        Me.btnMarcar = New System.Windows.Forms.Button()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(212, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 25)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Pesquisar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtDistribuicao
        '
        Me.txtDistribuicao.Location = New System.Drawing.Point(106, 10)
        Me.txtDistribuicao.Name = "txtDistribuicao"
        Me.txtDistribuicao.Size = New System.Drawing.Size(100, 20)
        Me.txtDistribuicao.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Distribuição nº"
        '
        'lblTotalReg
        '
        Me.lblTotalReg.AutoSize = True
        Me.lblTotalReg.Location = New System.Drawing.Point(1055, 33)
        Me.lblTotalReg.Name = "lblTotalReg"
        Me.lblTotalReg.Size = New System.Drawing.Size(50, 13)
        Me.lblTotalReg.TabIndex = 6
        Me.lblTotalReg.Text = " 0 Linhas"
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.Location = New System.Drawing.Point(28, 49)
        Me.dg.Name = "dg"
        Me.dg.Size = New System.Drawing.Size(1080, 417)
        Me.dg.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(213, 483)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Etiquetas de Volumes:"
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Checked = True
        Me.rbTodos.Location = New System.Drawing.Point(331, 481)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(89, 17)
        Me.rbTodos.TabIndex = 9
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Imprimir todas"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'rbFaixa
        '
        Me.rbFaixa.AutoSize = True
        Me.rbFaixa.Location = New System.Drawing.Point(426, 481)
        Me.rbFaixa.Name = "rbFaixa"
        Me.rbFaixa.Size = New System.Drawing.Size(103, 17)
        Me.rbFaixa.TabIndex = 10
        Me.rbFaixa.Text = "Imprimir por faixa"
        Me.rbFaixa.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(535, 483)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "de"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(560, 481)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(65, 20)
        Me.NumericUpDown1.TabIndex = 12
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(631, 483)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "até"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(659, 481)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(65, 20)
        Me.NumericUpDown2.TabIndex = 14
        Me.NumericUpDown2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnSair
        '
        Me.btnSair.Image = CType(resources.GetObject("btnSair.Image"), System.Drawing.Image)
        Me.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSair.Location = New System.Drawing.Point(933, 516)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(175, 47)
        Me.btnSair.TabIndex = 15
        Me.btnSair.Text = "Fechar"
        Me.btnSair.UseVisualStyleBackColor = True
        '
        'btnNormal
        '
        Me.btnNormal.Image = CType(resources.GetObject("btnNormal.Image"), System.Drawing.Image)
        Me.btnNormal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNormal.Location = New System.Drawing.Point(752, 516)
        Me.btnNormal.Name = "btnNormal"
        Me.btnNormal.Size = New System.Drawing.Size(175, 47)
        Me.btnNormal.TabIndex = 16
        Me.btnNormal.Text = "Imprimir Normal"
        Me.btnNormal.UseVisualStyleBackColor = True
        '
        'btnVolumeNormal
        '
        Me.btnVolumeNormal.Image = CType(resources.GetObject("btnVolumeNormal.Image"), System.Drawing.Image)
        Me.btnVolumeNormal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolumeNormal.Location = New System.Drawing.Point(571, 516)
        Me.btnVolumeNormal.Name = "btnVolumeNormal"
        Me.btnVolumeNormal.Size = New System.Drawing.Size(175, 47)
        Me.btnVolumeNormal.TabIndex = 17
        Me.btnVolumeNormal.Text = "Imprimir Volume"
        Me.btnVolumeNormal.UseVisualStyleBackColor = True
        '
        'btnVolumeQRCode
        '
        Me.btnVolumeQRCode.Image = CType(resources.GetObject("btnVolumeQRCode.Image"), System.Drawing.Image)
        Me.btnVolumeQRCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolumeQRCode.Location = New System.Drawing.Point(390, 516)
        Me.btnVolumeQRCode.Name = "btnVolumeQRCode"
        Me.btnVolumeQRCode.Size = New System.Drawing.Size(175, 47)
        Me.btnVolumeQRCode.TabIndex = 18
        Me.btnVolumeQRCode.Text = "Imprimir Volume QR"
        Me.btnVolumeQRCode.UseVisualStyleBackColor = True
        '
        'btnVolumeQRCodeReduzido
        '
        Me.btnVolumeQRCodeReduzido.Image = CType(resources.GetObject("btnVolumeQRCodeReduzido.Image"), System.Drawing.Image)
        Me.btnVolumeQRCodeReduzido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVolumeQRCodeReduzido.Location = New System.Drawing.Point(209, 516)
        Me.btnVolumeQRCodeReduzido.Name = "btnVolumeQRCodeReduzido"
        Me.btnVolumeQRCodeReduzido.Size = New System.Drawing.Size(175, 47)
        Me.btnVolumeQRCodeReduzido.TabIndex = 19
        Me.btnVolumeQRCodeReduzido.Text = "QR Code Reduzido"
        Me.btnVolumeQRCodeReduzido.UseVisualStyleBackColor = True
        '
        'btnMarcar
        '
        Me.btnMarcar.Location = New System.Drawing.Point(28, 478)
        Me.btnMarcar.Name = "btnMarcar"
        Me.btnMarcar.Size = New System.Drawing.Size(109, 23)
        Me.btnMarcar.TabIndex = 20
        Me.btnMarcar.Text = "Desmarcar Tudo"
        Me.btnMarcar.UseVisualStyleBackColor = True
        '
        'FrmPrintWMS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1120, 576)
        Me.Controls.Add(Me.btnMarcar)
        Me.Controls.Add(Me.btnVolumeQRCodeReduzido)
        Me.Controls.Add(Me.btnVolumeQRCode)
        Me.Controls.Add(Me.btnVolumeNormal)
        Me.Controls.Add(Me.btnNormal)
        Me.Controls.Add(Me.btnSair)
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.rbFaixa)
        Me.Controls.Add(Me.rbTodos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dg)
        Me.Controls.Add(Me.lblTotalReg)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDistribuicao)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FrmPrintWMS"
        Me.Text = "FrmPrintWMS"
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents txtDistribuicao As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTotalReg As Label
    Friend WithEvents dg As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents rbTodos As RadioButton
    Friend WithEvents rbFaixa As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents btnSair As Button
    Friend WithEvents btnNormal As Button
    Friend WithEvents btnVolumeNormal As Button
    Friend WithEvents btnVolumeQRCode As Button
    Friend WithEvents btnVolumeQRCodeReduzido As Button
    Friend WithEvents btnMarcar As Button
End Class
