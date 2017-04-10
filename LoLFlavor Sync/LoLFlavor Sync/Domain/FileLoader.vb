Imports System.IO

Public Class FileLoader
    Private _url As String
    Private _available As Boolean
    Private _content As String

    Sub New(url As String)
        _url = url
    End Sub

    Public ReadOnly Property Available As Boolean
        Get
            Return _available
        End Get
    End Property

    Public ReadOnly Property Content As String
        Get
            Return _content
        End Get
    End Property

    Public Sub Load()
        Try
            Dim uri As New Uri(_url, System.UriKind.Absolute)

            Using client As New Net.WebClient
                Using reader As New StreamReader(client.OpenRead(uri), Text.Encoding.UTF8)
                    _content = reader.ReadToEnd()
                    _available = True
                End Using
            End Using
        Catch
        End Try
    End Sub
End Class
