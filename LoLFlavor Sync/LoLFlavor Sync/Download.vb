Namespace Global.LoLFlavor_Sync.Library
    Public Class Download : Implements IDisposable

        ''' <summary>
        ''' User name to authenticate. Default is an empty string, "".
        ''' </summary>
        Public Property Username As String = ""
        ''' <summary>
        ''' Password to authenticate. Default is an empty string, "".
        ''' </summary>
        Public Property Password As String = ""
        ''' <summary>
        ''' Timeout interval, in milliseconds. Default is 5 seconds.
        ''' </summary>
        Public Property Timeout As Integer = 5000
        ''' <summary>
        ''' True to overwrite existing files. Default is True.
        ''' </summary>
        Public Property Overwrite As Boolean = True

        ''' <param name="SourceUrl">Path of the file to download, including host address and file name.</param>
        ''' <param name="DestinationPath">"File name and path of the downloaded file."</param>
        Public Sub Download(ByVal SourceUrl As String, ByVal DestinationPath As String)
            My.Computer.Network.DownloadFile(SourceUrl, DestinationPath, _Username, _Password, False, _Timeout, _Overwrite)
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
End Namespace