Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.Encoding
Module Funcoes

    Public Enum Operacao
        Consulta = 0
        Novo = 1
        Edicao = 2
        Exclusao = 3
    End Enum

    Public usuarioNome As String = ""

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

    Public Sub ImprimeZebraZT230(ByVal strTextoZebra)
        If My.Settings.OUTPUT_PRINTER.Equals(1) Then 'Imprime para IP de rede

            Dim ipAddress As String = EnderecoImpressora() '"172.16.16.250"
            Dim port As Integer = 6101

            If String.IsNullOrEmpty(ipAddress) Then
                MessageBox.Show("Impressora Padrão não definida!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Try
                Dim client As System.Net.Sockets.TcpClient = New Net.Sockets.TcpClient()
                client.Connect(ipAddress, port)
                'client.Connect(ipAddress,)

                Dim writer As System.IO.StreamWriter = New System.IO.StreamWriter(client.GetStream())
                writer.Write(strTextoZebra)
                writer.Flush()

                'Fechando a conexao
                writer.Close()
                client.Close()


            Catch ex As Exception
                MessageBox.Show("Erro ao Listar " + ex.Message)
            End Try
        Else 'Imprime para compartilhamento LOCAL - exemplo \\localhost\ZT230
            ImprimeZebraZT230Local(strTextoZebra, My.Settings.SHARED_NAME)
        End If

    End Sub
    Public Function EnderecoImpressora() As String
        Dim sAddress As String = ""
        Try
            Dim dt = SqliteExecuteDataTable("select PRINTER_IP from CONFIG_PRINTER where IS_DEFAULT = 1")

            If dt.Rows.Count > 0 Then
                sAddress = dt.Rows(0)("PRINTER_IP").ToString
            End If

        Catch ex As Exception
            MessageBox.Show("Erro ao Listar " + ex.Message)
        End Try
        Return sAddress
    End Function

    Public Sub PersisteAmbiente(ByVal p_valor1 As Integer, p_valor2 As Integer)
        My.Settings.AMBIENTE = p_valor1
        My.Settings.HOMOLOG = p_valor2
        My.Settings.Save()
    End Sub

    Public Function GetAmbiente(ByVal _valor As String) As Integer
        Dim ret As Integer = 0
        If Trim(_valor).ToUpper.Equals("AMBIENTE") Then
            ret = My.Settings.AMBIENTE
        End If
        If Trim(_valor).ToUpper.Equals("HOMOLOG") Then
            ret = My.Settings.HOMOLOG
        End If
        Return ret
    End Function

    Function ProtocoloNumero() As String
        'Retorna String com Ano + Mês + Dia + Hora Formato 24 + minutos + segundos + Milesimos de Segundos (3 digitos)
        'Exemplo: "20160819124536827"
        Return DateTime.Now.ToString("yyyyMMddHHmmssfff")
    End Function

    Public Function GetVersion() As String
        Dim ret As String = ""
        If System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            Dim ver As Version = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion
            ret = String.Format("{0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision)
        End If
        Return ret
    End Function
End Module
