Namespace Download
    Public Class DownloadHandler
        Inherits DownloadClass
        Implements IDisposable

        ''' <summary>
        ''' Path of the file to download, including host address and file name.
        ''' Replace the champion name with: {Champion}
        ''' Replace the lane with: {Lane}
        ''' </summary>
        Public Property SourceUrlFormat As String = "http://www.lolflavor.com/champions/{Champion}/Recommended/{Champion}_{Lane}_scrape.json"
        ''' <summary>
        ''' Base path (usually a temp directory)
        ''' </summary>
        Public Property DestinationPathBase As String
        ''' <summary>
        ''' Path where the file needs to be stored, without filename and base path.
        ''' Default: \Config\Champions\{Champion}\Recommended\
        ''' Store base path in DownloadClass.DestinationPathBase and the filename in DownloadClass.DestinationFileFormat
        ''' Replace the champion name with: {Champion}
        ''' Replace the lane with: {Lane}
        ''' </summary>
        Public Property DestinationPathFormat As String = "\Config\Champions\{Champion}\Recommended\"
        ''' <summary>
        ''' File name
        ''' Default: {Champion}_{Lane}_scrape.json
        ''' Replace the champion name with: {Champion}
        ''' Replace the lane with: {Lane}
        ''' </summary>
        Public Property DestinationFileFormat As String = "{Champion}_{Lane}_scrape.json"

        Public Enum laneTypes As Integer
            lane
            jungle
            support
            aram
        End Enum

        ''' <param name="ChampsToDownload">Champion names that need to be downloaded As String in a Queue.</param>
        ''' <param name="Lane">Lane to download builds for. See laneTypes Enum.</param>
        Public Shadows Function Download(ByVal ChampsToDownload As Queue, ByVal Lane As laneTypes) As Queue
            Dim messageQueue As New Queue
            Dim SourceUrlLane As String = _SourceUrlFormat.Replace("{Lane}", Lane.ToString())
            Dim DestinationPathLane As String = _DestinationPathBase & _DestinationPathFormat.Replace("{Lane}", Lane.ToString()) & _DestinationFileFormat.Replace("{Lane}", Lane.ToString())

            For Each Champion As String In ChampsToDownload
                Dim SourceUrl As String = SourceUrlLane.Replace("{Champion}", Champion)
                Dim DestinationPath As String = DestinationPathLane.Replace("{Champion}", Champion)
                Dim Ex As Exception = MyBase.Download(SourceUrl, DestinationPath)
                If Ex IsNot Nothing Then
                    messageQueue.Enqueue(Ex.Message & Environment.NewLine & "  While downloading: " & Environment.NewLine & "  " & SourceUrl)
                End If
            Next
            Return messageQueue
        End Function

#Region "Constructor"
        Public Sub New(ByVal DestinationPathBase As String)
            Me._DestinationPathBase = DestinationPathBase
        End Sub
#End Region

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

    Public Class DownloadClass
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
        Public Function Download(ByVal SourceUrl As String, ByVal DestinationPath As String) As Exception
            Try
                My.Computer.Network.DownloadFile(SourceUrl, DestinationPath, _Username, _Password, False, _Timeout, _Overwrite)
            Catch ex As Exception
                Return ex
                Exit Function
            End Try
            Return Nothing
        End Function
    End Class
End Namespace