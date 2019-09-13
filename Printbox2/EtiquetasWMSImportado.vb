Public Class EtiquetasWMSImportado
    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _pack As String
    Public Property Pack() As String
        Get
            Return _pack
        End Get
        Set(ByVal value As String)
            _pack = value
        End Set
    End Property

    Private _produto As String
    Public Property Produto() As String
        Get
            Return _produto
        End Get
        Set(ByVal value As String)
            _produto = value
        End Set
    End Property

    Private _nfe_num As String
    Public Property Nfe_num() As String
        Get
            Return _nfe_num
        End Get
        Set(ByVal value As String)
            _nfe_num = value
        End Set
    End Property

    Private _nfe_serie As String
    Public Property NfeSerie() As String
        Get
            Return _nfe_serie
        End Get
        Set(ByVal value As String)
            _nfe_serie = value
        End Set
    End Property

    Private _etiqueta_num As Integer
    Public Property EtiquetaNum() As Integer
        Get
            Return _etiqueta_num
        End Get
        Set(ByVal value As Integer)
            _etiqueta_num = value
        End Set
    End Property

    Public Sub New(ByVal _id As Integer, ByVal _pack As String, ByVal _produto As String, ByVal _nfe_num As String, ByVal _serie As String, ByVal _etiqueta As Integer)
        Me.Id = _id
        Me.Pack = _pack
        Me.Produto = _produto
        Me.Nfe_num = _nfe_num
        Me.NfeSerie = _serie
        Me.EtiquetaNum = _etiqueta
    End Sub
    Public Shared Function GetEtiquetas(ByVal dg As DataGridView) As List(Of EtiquetasWMSImportado)
        Dim listaEtiquetas = New List(Of EtiquetasWMSImportado)
        listaEtiquetas.Clear()

        Try
            Dim i As Integer = 1

            For Each row As DataGridViewRow In dg.Rows
                If row.Cells("selecao").Value = True Then
                    listaEtiquetas.Add(New EtiquetasWMSImportado(i, row.Cells("pack").Value, row.Cells("produto").Value,
                                                             row.Cells("nf").Value, row.Cells("serie").Value, CInt(row.Cells("etiqueta").Value)))
                    i += 1
                End If
            Next



        Catch ex As Exception

        End Try
        Return listaEtiquetas
    End Function

End Class
