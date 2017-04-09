Imports LoLFlavor_Sync.DLBuilds

Namespace Global.LoLFlavor_Sync.Domain
    Public Class Build
        Private _Champ As Champion
        Private _Lane As IDownloadInfo.laneType
        Private _Build As String

        Public ReadOnly Property GetChampion() As Champion
            Get
                Return _Champ
            End Get
        End Property

        Public ReadOnly Property GetLaneType As IDownloadInfo.laneType
            Get
                Return _Lane
            End Get
        End Property

        Public ReadOnly Property GetBuildText() As String
            Get
                Return _Build
            End Get
        End Property

        Sub New(ByRef champ As Champion, ByVal lane As IDownloadInfo.laneType, ByVal build As String)
            Me._Champ = champ
            Me._Lane = lane
            Me._Build = build
        End Sub
    End Class
End Namespace