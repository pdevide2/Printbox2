Imports System.Data.SqlClient

Public Class CaixaInfo
    Private _caixa As String
    Public Property Caixa() As String
        Get
            Return _caixa
        End Get
        Set(ByVal value As String)
            _caixa = value
        End Set
    End Property
    Private _nome_clifor As String
    Public Property NomeCliFor() As String
        Get
            Return _nome_clifor
        End Get
        Set(ByVal value As String)
            _nome_clifor = value
        End Set
    End Property
    Private _qtde_caixa As Integer
    Public Property QtdeCaixa() As Integer
        Get
            Return _qtde_caixa
        End Get
        Set(ByVal value As Integer)
            _qtde_caixa = value
        End Set
    End Property
    Private _caixa_mae As Boolean
    Public Property CaixaMae() As Boolean
        Get
            Return _caixa_mae
        End Get
        Set(ByVal value As Boolean)
            _caixa_mae = value
        End Set
    End Property
    Private _lista_caixa_filhas As String
    Public Property ListaCaixaFilhas() As String
        Get
            Return _lista_caixa_filhas
        End Get
        Set(ByVal value As String)
            _lista_caixa_filhas = value
        End Set
    End Property

    Public Sub New(caixa As String)
        Me.Caixa = caixa
        PreencheCaixa(caixa)
    End Sub

    Private Sub PreencheCaixa(ByVal _caixa As String)
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim sql As String = ""
        Try
            abrir()

            sql = " select	caixa, "
            sql += " 		NOME_CLIFOR, "
            sql += " 		QTDE_CAIXA, "
            sql += " 		isnull(ERP_AGRUPAMENTO_CAIXAS,cast(0 as bit)) as ERP_AGRUPAMENTO_CAIXAS, "
            sql += " 		isnull(ERP_LISTA_CAIXAS_AGRUPADAS,'') as ERP_LISTA_CAIXAS_AGRUPADAS "
            sql += " from FATURAMENTO_CAIXAS where caixa = '" & _caixa & "' "

            da = New SqlDataAdapter(sql, conn)
            da.Fill(dt)

            'Preenche todas as propriedades da classe
            For Each row As DataRow In dt.Rows
                NomeCliFor = row("nome_clifor").ToString
                QtdeCaixa = CInt(row("qtde_caixa"))
                CaixaMae = CBool(row("erp_agrupamento_caixas"))
                ListaCaixaFilhas = row("erp_lista_caixas_agrupadas").ToString
            Next

        Catch ex As Exception
            MessageBox.Show("Erro ao Pesquisar Caixa " + ex.Message)
        Finally
            fechar()
        End Try
    End Sub

End Class
