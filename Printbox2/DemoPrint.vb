Public Class DemoPrint



    Private Sub DemoPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For i = 1 To NumericUpDown1.Value

            Dim strTextoZebra As String
            strTextoZebra = "CT~~CD,~CC^~CT~"
            strTextoZebra += "^XA~TA000~JSN^LT0^MNW^MTD^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ"
            strTextoZebra += "^XA"
            strTextoZebra += "^MMT"
            strTextoZebra += "^PW831"
            strTextoZebra += "^LL0208"
            strTextoZebra += "^LS0"
            strTextoZebra += "^BY3,3,80^FT66,124^BCN,,Y,N"
            strTextoZebra += "^FD>:E>5" & Format(14392866 + i, "00000000") & ">6|>5" & "1000" & ">6|>5" & "1200" & ">60^FS"
            strTextoZebra += "^PQ1,0,1,Y^XZ"

            ImprimeZebra(strTextoZebra)
        Next


    End Sub

    Private Sub ImprimeZebra(ByVal strTextoZebra)
        Dim ipAddress As String = "172.16.16.250"
        Dim port As Integer = 6101

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

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim strConexao As String
        'Server=dblinx.caedu.com.br;driver={SQL Server};Provider=SQLOLEDB.1;Persist Security Info=True;DATABASE=caedu;UID=printbar_user;PWD=#C@edu$7890@
        'strConexao = BuscaConexaoTXT("db_printbar_conn.txt")
        'Dim intservidor = strConexao.IndexOf("Server=")
        'Dim intdriver = strConexao.IndexOf("driver=") - 1
        'Dim intdatabase = strConexao.IndexOf("DATABASE=")
        'Dim intuid = 100

        'MessageBox.Show(strConexao.Substring(intservidor, intdriver) & Chr(13) & strConexao.Substring(intdatabase, intuid))

        Dim objConn As New DadosConexao()
        MessageBox.Show(objConn.Server & Chr(13) & objConn.Database & Chr(13) & objConn.Usuario & Chr(13) & objConn.Senha)

    End Sub
End Class