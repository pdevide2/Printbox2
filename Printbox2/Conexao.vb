Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.Data.SQLite.SQLiteConnection

Module Conexao

    'Public servidor As String = ".\SQL2017DEV"
    Dim objConn As New DadosConexao()
    Dim strCon As String = "Data Source=" & objConn.Server & ";Initial Catalog=" & objConn.Database & ";User ID=" & objConn.Usuario & ";Password=" & objConn.Senha & ";"
    Dim sqlLiteConnectionString = "Data Source=dbPrintbox2.db;Version=3;New=True;Compress=True;"
    'Dim oConn As New SQLite.SQLiteConnection(sqlLiteConnectionString)
    Dim sqliteConn As New SQLiteConnection("Data Source=C:\Printbox2.0\dados\dbPrintbox2.db")

    '= "Data Source=SERVERNAME\SQLEXPRESS;Initial Catalog=DATABASENAME;User ID=USERNAME;Password=PASSWORD;Connection Timeout=50;"
    'Public conn As New SqlConnection("Server = .\DEVELOPER; Database=dbSistemaVB; Trusted_Connection=True")

    ' VB.NET
    Sub OpenSQLitedb()
        Using sqliteConn As New System.Data.SQLite.SQLiteConnection("Data Source=C:\Printbox2.0\dados\dbPrintbox2.db;")
            conn.Open()
        End Using
    End Sub

    Sub SqliteExecuteNonQuery(ByVal cmd As String)
        Try
            'Using sqliteConn As New System.Data.SQLite.SQLiteConnection("Data Source=C:\Printbox2.0\dados\dbPrintbox2.db;")
            '    sqliteConn.Open()
            'End Using
            sqliteConn.Open()

            Using Comm As New System.Data.SQLite.SQLiteCommand(sqliteConn)
                Comm.CommandText = cmd
                Comm.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            MessageBox.Show("Erro no comando SQL " + ex.Message)
        Finally
            sqliteConn.Close()
        End Try
    End Sub

    Public Function SqliteExecuteDataTable(ByVal cmd As String) As DataTable
        Dim dt As New DataTable
        Dim SQLcommand As SQLiteCommand
        Try
            Using sqliteConn As New System.Data.SQLite.SQLiteConnection("Data Source=C:\Printbox2.0\dados\dbPrintbox2.db;")
                sqliteConn.Open()
            End Using
            SQLcommand = sqliteConn.CreateCommand
            SQLcommand.CommandText = cmd

            Using Comm As New System.Data.SQLite.SQLiteCommand(sqliteConn)
                Comm.CommandText = cmd
                Dim Adapter As New System.Data.SQLite.SQLiteDataAdapter(Comm)
                Adapter.Fill(dt)
            End Using


        Catch ex As Exception
            MessageBox.Show("Erro ao Listar " + ex.Message)
        Finally
            sqliteConn.Close()
        End Try
        Return dt

    End Function


    Public conn As New SqlConnection(strCon)
    Sub abrir()
        If conn.State = 0 Then
            conn.Open()
        End If
    End Sub
    Sub fechar()
        If conn.State = 1 Then
            conn.Close()
        End If
    End Sub


    Public Function PesquisarFkListaBLL(ByVal cmdSQL As String) As ArrayList

        Dim dt As New DataTable
        Dim da As SqlDataAdapter
        Dim myArrList As New ArrayList()

        Try
            abrir()
            da = New SqlDataAdapter(cmdSQL, conn)
            da.Fill(dt)

            For Each datarow As DataRow In dt.Rows

                myArrList.Add(datarow)

            Next

            Return myArrList
        Catch ex As Exception
            MessageBox.Show("Erro ao Listar " + ex.Message)
            Return myArrList
        Finally
            fechar()
        End Try



    End Function

End Module
