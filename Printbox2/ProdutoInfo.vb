Imports System.Data.SqlClient

Public Class ProdutoInfo
    Private _produto As String
    Public Property Produto() As String
        Get
            Return _produto
        End Get
        Set(ByVal value As String)
            _produto = value
        End Set
    End Property

    Private _griffe As String
    Public Property Griffe() As String
        Get
            Return _griffe
        End Get
        Set(ByVal value As String)
            _griffe = value
        End Set
    End Property

    Private _linha As String
    Public Property Linha() As String
        Get
            Return _linha
        End Get
        Set(ByVal value As String)
            _linha = value
        End Set
    End Property

    Private _grupo As String
    Public Property Grupo() As String
        Get
            Return _grupo
        End Get
        Set(ByVal value As String)
            _grupo = value
        End Set
    End Property

    Private _subgrupo As String
    Public Property SubGrupo() As String
        Get
            Return _subgrupo
        End Get
        Set(ByVal value As String)
            _subgrupo = value
        End Set
    End Property

    Private _id_colecao As String
    Public Property IdColecao() As String
        Get
            Return _id_colecao
        End Get
        Set(ByVal value As String)
            _id_colecao = value
        End Set
    End Property

    Private _colecao As String
    Public Property Colecao() As String
        Get
            Return _colecao
        End Get
        Set(ByVal value As String)
            _colecao = value
        End Set
    End Property

    Private _grade As String
    Public Property Grade() As String
        Get
            Return _grade
        End Get
        Set(ByVal value As String)
            _grade = value
        End Set
    End Property

    Private _categoria As String
    Public Property Categoria() As String
        Get
            Return _categoria
        End Get
        Set(ByVal value As String)
            _categoria = value
        End Set
    End Property

    Private _tamanho_pack As Integer
    Public Property TamanhoPack() As Integer
        Get
            Return _tamanho_pack
        End Get
        Set(ByVal value As Integer)
            _tamanho_pack = value
        End Set
    End Property

    Private _desc_produto As String
    Public Property DescProduto() As String
        Get
            Return _desc_produto
        End Get
        Set(ByVal value As String)
            _desc_produto = value
        End Set
    End Property
    Public Sub New(produto As String)
        Me.Produto = produto
        PreencheProduto(produto)
    End Sub
    Private Sub PreencheProduto(ByVal _produto As String)
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim sql As String = ""
        Try
            abrir()

            sql = " select	produto, "
            sql += " 		griffe, "
            sql += " 		linha, "
            sql += " 		grupo_produto, "
            sql += " 		subgrupo_produto, "
            sql += " 		colecoes.colecao, "
            sql += " 		colecoes.DESC_COLECAO, "
            sql += " 		grade, "
            sql += " 		case "
            sql += " 		when COD_CATEGORIA = '2' then 'CABIDE' "
            sql += " 		else '      ' "
            sql += " 		end as categoria, "
            sql += " 		isnull(ERP_QTD_PACK,0) as ERP_QTD_PACK, "
            sql += "        desc_produto "
            sql += " from produtos (nolock) "
            sql += " inner join COLECOES  (nolock) on COLECOES.COLECAO = PRODUTOS.COLECAO "
            sql += " where produtos.produto = '" & _produto & "' "

            da = New SqlDataAdapter(sql, conn)
            da.Fill(dt)

            'Preenche todas as propriedades da classe
            For Each row As DataRow In dt.Rows

                Griffe = row("griffe").ToString
                Linha = row("linha").ToString
                Grupo = row("grupo_produto").ToString
                SubGrupo = row("subgrupo_produto").ToString
                IdColecao = row("colecao").ToString
                Colecao = row("desc_colecao").ToString
                Grade = row("grade").ToString
                Categoria = row("categoria").ToString
                TamanhoPack = CInt(row("erp_qtd_pack"))
                DescProduto = row("desc_produto").ToString

            Next

        Catch ex As Exception
            MessageBox.Show("Erro ao Pesquisar Produto " + ex.Message)
        Finally
            fechar()
        End Try

    End Sub
End Class
