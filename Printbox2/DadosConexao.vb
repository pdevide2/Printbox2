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
        Dim strConexao = BuscaConexaoTXT("db_printbar_conn.txt")

        Dim intservidor = strConexao.IndexOf("Server=")
        Dim intdriver = strConexao.IndexOf("driver=") - 1
        Dim intdatabase = strConexao.IndexOf("DATABASE=")
        Dim intLenght = 100
        Dim servidor = strConexao.Substring(intservidor, intdriver)

        Dim dadosServer As String() = servidor.Split("=")
        Me.Server = Trim(dadosServer(1))

        Dim dados = strConexao.Substring(intdatabase, intLenght)
        Dim dados2 As String() = dados.Split(";")

        Dim dadosDatabase As String() = dados2(0).Split("=")
        Dim dadosUsuario As String() = dados2(1).Split("=")
        Dim dadosSenha As String() = dados2(2).Split("=")

        Me.Database = Trim(dadosDatabase(1))
        Me.Usuario = Trim(dadosUsuario(1))
        Me.Senha = Trim(dadosSenha(1)).Replace(vbNullChar, "")


    End Sub

    Public Sub New()
        Me.PreencherDados()
    End Sub

End Class

