Imports System.IO
Imports System.Text.Encoding
Module Funcoes
    'Diretorio do executavel C:\WORKSPACE\Printbox2\Printbox2\bin\Debug
    'Retorna: C:\WORKSPACE\Printbox2\
    Public dirhome As String = Application.StartupPath.Replace("Printbox2\bin\Debug", "")
    Public strConexaoSQL As String = ""
    Public Function BuscaConexaoTXT(ByVal mnomecnx As String) As String

        Dim retorno As String = ""
        Dim strSenhaC As String = ""

        Try
            Dim strLocalPath
            strLocalPath = dirhome + "Printbox2\Conexao\" + mnomecnx

            Dim i As Integer = 1
            Dim strVarSenha As String
            strVarSenha = LerArquivo(strLocalPath)

            Dim intAux As Integer
            Dim intTam As Integer = strVarSenha.Length

            For i = 0 To intTam

                intAux = Asc(strVarSenha.Substring(i, 1)) / 2

                strConexaoSQL += Chr(intAux)
            Next
            Return strConexaoSQL

        Catch ex As Exception

        End Try
        Return strConexaoSQL

    End Function

    Public Function LerArquivo(ByVal caminho As String) As String
        Dim fluxoTexto As IO.StreamReader
        fluxoTexto = New IO.StreamReader(caminho, System.Text.Encoding.Default)
        Dim texto As String

        texto = fluxoTexto.ReadToEnd

        fluxoTexto.Close()
        Return texto
    End Function
End Module
