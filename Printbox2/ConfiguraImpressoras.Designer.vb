<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConfiguraImpressoras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfiguraImpressoras))
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.btnDesfazer = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnAlterar = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.ckPadrao = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dg = New System.Windows.Forms.DataGridView()
        Me.txtIPAddress = New System.Windows.Forms.TextBox()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnNovo
        '
        Me.btnNovo.Image = CType(resources.GetObject("btnNovo.Image"), System.Drawing.Image)
        Me.btnNovo.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnNovo.Location = New System.Drawing.Point(143, 408)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(96, 43)
        Me.btnNovo.TabIndex = 0
        Me.btnNovo.Text = "Novo"
        Me.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNovo.UseVisualStyleBackColor = True
        '
        'btnDesfazer
        '
        Me.btnDesfazer.Image = CType(resources.GetObject("btnDesfazer.Image"), System.Drawing.Image)
        Me.btnDesfazer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDesfazer.Location = New System.Drawing.Point(245, 408)
        Me.btnDesfazer.Name = "btnDesfazer"
        Me.btnDesfazer.Size = New System.Drawing.Size(96, 43)
        Me.btnDesfazer.TabIndex = 1
        Me.btnDesfazer.Text = "Desfazer"
        Me.btnDesfazer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDesfazer.UseVisualStyleBackColor = True
        '
        'btnSalvar
        '
        Me.btnSalvar.Image = CType(resources.GetObject("btnSalvar.Image"), System.Drawing.Image)
        Me.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalvar.Location = New System.Drawing.Point(347, 408)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(96, 43)
        Me.btnSalvar.TabIndex = 2
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnAlterar
        '
        Me.btnAlterar.Image = CType(resources.GetObject("btnAlterar.Image"), System.Drawing.Image)
        Me.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAlterar.Location = New System.Drawing.Point(449, 408)
        Me.btnAlterar.Name = "btnAlterar"
        Me.btnAlterar.Size = New System.Drawing.Size(96, 43)
        Me.btnAlterar.TabIndex = 3
        Me.btnAlterar.Text = "Editar"
        Me.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAlterar.UseVisualStyleBackColor = True
        '
        'btnExcluir
        '
        Me.btnExcluir.Image = CType(resources.GetObject("btnExcluir.Image"), System.Drawing.Image)
        Me.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluir.Location = New System.Drawing.Point(551, 408)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(96, 43)
        Me.btnExcluir.TabIndex = 4
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcluir.UseVisualStyleBackColor = True
        '
        'txtCodigo
        '
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(108, 22)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(100, 26)
        Me.txtCodigo.TabIndex = 5
        '
        'txtDescricao
        '
        Me.txtDescricao.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescricao.Location = New System.Drawing.Point(108, 70)
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(392, 26)
        Me.txtDescricao.TabIndex = 7
        '
        'ckPadrao
        '
        Me.ckPadrao.AutoSize = True
        Me.ckPadrao.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPadrao.Location = New System.Drawing.Point(519, 72)
        Me.ckPadrao.Name = "ckPadrao"
        Me.ckPadrao.Size = New System.Drawing.Size(172, 24)
        Me.ckPadrao.TabIndex = 8
        Me.ckPadrao.Text = "Definir como Padrão"
        Me.ckPadrao.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Código"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(276, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "IP da Impressora"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Descrição"
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.Location = New System.Drawing.Point(26, 110)
        Me.dg.Name = "dg"
        Me.dg.ReadOnly = True
        Me.dg.Size = New System.Drawing.Size(665, 259)
        Me.dg.TabIndex = 13
        '
        'txtIPAddress
        '
        Me.txtIPAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIPAddress.Location = New System.Drawing.Point(412, 19)
        Me.txtIPAddress.Name = "txtIPAddress"
        Me.txtIPAddress.Size = New System.Drawing.Size(279, 26)
        Me.txtIPAddress.TabIndex = 14
        '
        'ConfiguraImpressoras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 455)
        Me.Controls.Add(Me.txtIPAddress)
        Me.Controls.Add(Me.dg)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ckPadrao)
        Me.Controls.Add(Me.txtDescricao)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.btnAlterar)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.btnDesfazer)
        Me.Controls.Add(Me.btnNovo)
        Me.Name = "ConfiguraImpressoras"
        Me.Text = "Configurar Impressoras Zebra ZT230"
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnNovo As Button
    Friend WithEvents btnDesfazer As Button
    Friend WithEvents btnSalvar As Button
    Friend WithEvents btnAlterar As Button
    Friend WithEvents btnExcluir As Button
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents txtDescricao As TextBox
    Friend WithEvents ckPadrao As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dg As DataGridView
    Friend WithEvents txtIPAddress As TextBox
End Class
