Imports System.Data.SqlClient

Public Class FilialInfo
    Private _filial As String
    Public Property Filial() As String
        Get
            Return _filial
        End Get
        Set(ByVal value As String)
            _filial = value
        End Set
    End Property
    Private _cod_filial As String
    Public Property CodFilial() As String
        Get
            Return _cod_filial
        End Get
        Set(ByVal value As String)
            _cod_filial = value
        End Set
    End Property
    Private _cod_rota As String
    Public Property CodigoRota() As String
        Get
            Return _cod_rota
        End Get
        Set(ByVal value As String)
            _cod_rota = value
        End Set
    End Property
    Private _ordem_rota As String
    Public Property OrdemRota() As String
        Get
            Return _ordem_rota
        End Get
        Set(ByVal value As String)
            _ordem_rota = value
        End Set
    End Property
    Private _sufixo_filial As String
    Public Property SufixoFilial() As String
        Get
            Return _sufixo_filial
        End Get
        Set(ByVal value As String)
            _sufixo_filial = value
        End Set
    End Property

    Public Sub New(filial As String)
        Me.Filial = filial
        PreencheFilial(filial)
    End Sub

    Private Sub PreencheFilial(ByVal _filial As String)
        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim sql As String = ""
        Try
            abrir()

            sql = "SELECT FILIAL, COD_FILIAL, ISNULL(erp_cod_rota,'') AS erp_cod_rota, ISNULL(erp_ordem_rota,'') AS erp_ordem_rota, "
            sql += "RIGHT(COD_FILIAL,3) AS SUFIXO_FILIAL  FROM FILIAIS WHERE FILIAL = '" & _filial & "'"

            da = New SqlDataAdapter(sql, conn)
            da.Fill(dt)

            'Preenche todas as propriedades da classe
            For Each row As DataRow In dt.Rows
                CodFilial = row("cod_filial").ToString
                CodigoRota = row("erp_cod_rota").ToString
                OrdemRota = row("erp_ordem_rota").ToString
                SufixoFilial = row("sufixo_filial").ToString
            Next

        Catch ex As Exception
            MessageBox.Show("Erro ao Pesquisar Filial " + ex.Message)
        Finally
            fechar()
        End Try
    End Sub


End Class
