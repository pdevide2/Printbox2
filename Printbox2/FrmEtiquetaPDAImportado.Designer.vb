<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEtiquetaPDAImportado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEtiquetaPDAImportado))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNota = New System.Windows.Forms.TextBox()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dg = New System.Windows.Forms.DataGridView()
        Me.lblTotalReg = New System.Windows.Forms.Label()
        Me.dg2 = New System.Windows.Forms.DataGridView()
        Me.btnMarcarProdutos = New System.Windows.Forms.Button()
        Me.lblMarcarProdutos = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NF"
        '
        'txtNota
        '
        Me.txtNota.Location = New System.Drawing.Point(47, 12)
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(112, 20)
        Me.txtNota.TabIndex = 1
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(250, 12)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(47, 20)
        Me.txtSerie.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(213, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Série"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(312, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(98, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Pesquisar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.Location = New System.Drawing.Point(17, 207)
        Me.dg.Name = "dg"
        Me.dg.Size = New System.Drawing.Size(813, 335)
        Me.dg.TabIndex = 5
        '
        'lblTotalReg
        '
        Me.lblTotalReg.AutoSize = True
        Me.lblTotalReg.Location = New System.Drawing.Point(780, 190)
        Me.lblTotalReg.Name = "lblTotalReg"
        Me.lblTotalReg.Size = New System.Drawing.Size(50, 13)
        Me.lblTotalReg.TabIndex = 6
        Me.lblTotalReg.Text = "0 Linhas."
        '
        'dg2
        '
        Me.dg2.AllowUserToAddRows = False
        Me.dg2.AllowUserToDeleteRows = False
        Me.dg2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg2.Location = New System.Drawing.Point(16, 38)
        Me.dg2.Name = "dg2"
        Me.dg2.Size = New System.Drawing.Size(281, 129)
        Me.dg2.TabIndex = 7
        '
        'btnMarcarProdutos
        '
        Me.btnMarcarProdutos.Location = New System.Drawing.Point(19, 176)
        Me.btnMarcarProdutos.Name = "btnMarcarProdutos"
        Me.btnMarcarProdutos.Size = New System.Drawing.Size(107, 23)
        Me.btnMarcarProdutos.TabIndex = 8
        Me.btnMarcarProdutos.Text = "Desmarcar Tudo"
        Me.btnMarcarProdutos.UseVisualStyleBackColor = True
        '
        'lblMarcarProdutos
        '
        Me.lblMarcarProdutos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMarcarProdutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarcarProdutos.Image = CType(resources.GetObject("lblMarcarProdutos.Image"), System.Drawing.Image)
        Me.lblMarcarProdutos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMarcarProdutos.Location = New System.Drawing.Point(308, 38)
        Me.lblMarcarProdutos.Name = "lblMarcarProdutos"
        Me.lblMarcarProdutos.Size = New System.Drawing.Size(482, 129)
        Me.lblMarcarProdutos.TabIndex = 9
        Me.lblMarcarProdutos.Text = "Selecionar todos itens com produtos marcados"
        Me.lblMarcarProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(428, 10)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FrmEtiquetaPDAImportado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 606)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lblMarcarProdutos)
        Me.Controls.Add(Me.btnMarcarProdutos)
        Me.Controls.Add(Me.dg2)
        Me.Controls.Add(Me.lblTotalReg)
        Me.Controls.Add(Me.dg)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNota)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmEtiquetaPDAImportado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmEtiquetaPDAImportado"
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtNota As TextBox
    Friend WithEvents txtSerie As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents dg As DataGridView
    Friend WithEvents lblTotalReg As Label
    Friend WithEvents dg2 As DataGridView
    Friend WithEvents btnMarcarProdutos As Button
    Friend WithEvents lblMarcarProdutos As Label
    Friend WithEvents Button2 As Button
End Class
