Namespace Global.LoLFlavor_Sync.Library
    Public Class DownloadChampion : Implements IDisposable
        Private _Champ As Champion
        Private DPB As String

        Public Shared Property LaneVar As String = "{Lane}"

        Public ReadOnly Property Champ As Champion
            Get
                Return _Champ
            End Get
        End Property

        Public Enum laneType As Integer
            lane
            jungle
            support
            aram
        End Enum

        Sub New(ByRef ch As Champion, ByVal DestinationPathBase As String)
            Me.DPB = DestinationPathBase
            Me._Champ = ch
        End Sub

        Public Function GetSourceUrl(ByVal lane As laneType) As String
            Return _Champ.SourceUrl(False).Replace(LaneVar, lane.ToString())
        End Function

        Public Function GetDestinationPathBase(ByVal lane As laneType) As String
            Return DPB.Replace(_LaneVar, lane.ToString())
        End Function

        Public Function GetDestinationPath(ByVal lane As laneType) As String
            Return _Champ.DestinationPath(False).Replace(_LaneVar, lane.ToString())
        End Function

        Public Function GetDestinationFile(ByVal lane As laneType) As String
            Return _Champ.DestinationFile(False).Replace(_LaneVar, lane.ToString())
        End Function

        Public Sub DownloadBuild(ByVal lane As laneType)
            Using Downloader As New Download : With Downloader
                    .Download(GetSourceUrl(lane), GetDestinationPathBase(lane) & GetDestinationPath(lane) & GetDestinationFile(lane))
                End With
            End Using
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
