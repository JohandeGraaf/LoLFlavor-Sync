Imports System.IO
Imports LoLFlavor_Sync.Domain

Namespace Global.LoLFlavor_Sync.DLBuilds
    Public Class DownloadBehaviourLF : Implements IDisposable, IDownloadBehaviour
        Private _DownloadInfo As IDownloadInfo

        Public ReadOnly Property GetDownloadInfo As IDownloadInfo
            Get
                Return _DownloadInfo
            End Get
        End Property

        Public Sub New(ByRef DLInfo As IDownloadInfo)
            Me._DownloadInfo = DLInfo
        End Sub

        Public Function DownloadBuild(ByRef champ As Champion, ByVal lane As IDownloadInfo.laneType) As Build Implements IDownloadBehaviour.DownloadBuild
            Dim bld As Build
            Dim source As New System.Uri(_DownloadInfo.GetSourceUrl(champ, lane), System.UriKind.Absolute)
            Using client As New System.Net.WebClient
                Using stream As New StreamReader(client.OpenRead(source), System.Text.Encoding.UTF8)
                    bld = New Build(champ, lane, stream.ReadToEnd())
                End Using
            End Using
            Return bld
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
