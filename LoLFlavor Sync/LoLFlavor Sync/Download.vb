Namespace Download
    Public Class DownloadHandler
        Implements IDisposable

        Private Property DestinationPathBase As String

        Public Property SourceUrlFormat As String = "http://www.lolflavor.com/champions/{Champion}/Recommended/{Champion}_{Lane}_scrape.json"
        Public Property DestinationPathFormat As String = "\Config\Champions\{Champion}\Recommended\"
        Public Property DestinationFileFormat As String = "{Champion}_{Lane}_scrape.json"

        Public Enum laneTypes As Integer
            lane
            jungle
            support
            aram
        End Enum

        Public Function DownloadChamps(ByVal ChampsToDownload As Queue, ByVal Lane As laneTypes) As Queue
            Dim messageQueue As New Queue

            Dim SourceUrlLane As String = SourceUrlFormat.Replace("{Lane}", Lane.ToString())
            Dim DestinationPathLane As String = DestinationPathBase & DestinationPathFormat.Replace("{Lane}", Lane.ToString()) & DestinationFileFormat.Replace("{Lane}", Lane.ToString())

            Using Dlclass As New DownloadClass
                For Each Champion As String In ChampsToDownload
                    Dim SourceUrl As String = SourceUrlLane.Replace("{Champion}", Champion)
                    Dim DestinationPath As String = DestinationPathLane.Replace("{Champion}", Champion)
                    Dim msg As String = Dlclass.Download(SourceUrl, DestinationPath)
                    If Not String.IsNullOrWhiteSpace(msg) Then messageQueue.Enqueue(msg)
                Next
            End Using
            Return messageQueue
        End Function

#Region "Constructor"
        Public Sub New(ByVal DestinationPathBase As String)
            Me.DestinationPathBase = DestinationPathBase
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
        Implements IDisposable

        Public Function Download(ByVal SourceUrl As String, ByVal DestinationPath As String) As String
            Try
                My.Computer.Network.DownloadFile(SourceUrl, DestinationPath, "", "", False, 5000, True)
            Catch ex As Exception
                Return ex.Message & Environment.NewLine & "  While downloading: " & Environment.NewLine & "  " & SourceUrl
                Exit Function
            End Try
            Return Nothing
        End Function

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
