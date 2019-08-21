Public Class TestClass
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim obj As New ProdutoInfo(txtProduto.Text)

        txtCategoria.Text = obj.Categoria
        txtColecao.Text = obj.Colecao
        txtGrade.Text = obj.Grade
        txtGriffe.Text = obj.Griffe
        txtGrupo.Text = obj.Grupo
        txtIdColecao.Text = obj.IdColecao
        txtLinha.Text = obj.Linha
        txtSubgrupo.Text = obj.SubGrupo
        txtTamanhoPack.Text = obj.TamanhoPack
        txtDescProduto.Text = obj.DescProduto

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim obj As New FilialInfo(txtFilial.Text)
        txtCodFilial.Text = obj.CodFilial
        txtRota.Text = obj.CodigoRota
        txtOrdemRota.Text = obj.OrdemRota
        txtSufixoFilial.Text = obj.SufixoFilial
    End Sub
End Class