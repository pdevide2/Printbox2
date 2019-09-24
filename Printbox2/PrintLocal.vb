
Imports System.IO
Imports System.Runtime.InteropServices
Module PrintLocal
    Public Sub ImprimeZebraZT230Local(ByVal strTextoZebra, ByVal sNomeCompartilhamento)

        Try
            Dim file As System.IO.StreamWriter
            Dim arquivo = "C:\TEMP\" & Trim(ProtocoloNumero()) & ".txt"
            file = My.Computer.FileSystem.OpenTextFileWriter(arquivo, False)
            file.WriteLine(strTextoZebra)
            file.Close()

            System.IO.File.Copy(arquivo, "\\LOCALHOST\" & sNomeCompartilhamento, True)
            My.Computer.FileSystem.DeleteFile(arquivo)
        Catch ex As Exception


            MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
End Module
