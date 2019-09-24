Imports System.Data.SqlClient
Public Class DadosConexao
    Private _server As String
    Public Property Server() As String
        Get
            Return _server
        End Get
        Set(ByVal value As String)
            _server = value
        End Set
    End Property
    Private _database As String
    Public Property Database() As String
        Get
            Return _database
        End Get
        Set(ByVal value As String)
            _database = value
        End Set
    End Property
    Private _user As String
    Public Property Usuario() As String
        Get
            Return _user
        End Get
        Set(ByVal value As String)
            _user = value
        End Set
    End Property
    Private _senha As String
    Public Property Senha() As String
        Get
            Return _senha
        End Get
        Set(ByVal value As String)
            _senha = value
        End Set
    End Property
    Private _stringConn As String
    Public Property StringConnection() As String
        Get
            Return _stringConn
        End Get
        Set(ByVal value As String)
            _stringConn = value
        End Set
    End Property

    Private Sub PreencherDados()

        Dim _id_ambiente As Integer = GetAmbiente("AMBIENTE")
        Dim _id_homolog As Integer = GetAmbiente("HOMOLOG")

        If _id_ambiente = 1 Then
            Me.Server = "dblinx.caedu.com.br"
            Me.Database = "CAEDU"
            Me.Usuario = "PRINTBAR_USER"
            Me.Senha = "#C@edu$7890@"
        Else
            If _id_homolog = 1 Then
                Me.Server = "172.16.25.15\SPK"
                Me.Database = "CAEDU"
                Me.Usuario = "PRINTBAR_USER"
                Me.Senha = "#C@edu$7890@"
            Else
                Me.Server = "172.16.25.15\LINX"
                Me.Database = "CAEDU"
                Me.Usuario = "diariodebordo"
                Me.Senha = "c102030@"
            End If
        End If


    End Sub

    Public Sub New()
        Me.PreencherDados()
    End Sub

End Class

