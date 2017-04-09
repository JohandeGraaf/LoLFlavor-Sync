Imports LoLFlavor_Sync.Domain
Namespace Global.LoLFlavor_Sync.DLBuilds
    Public Interface IDownloadInfo
        Enum laneType As Integer
            lane
            jungle
            support
            aram
        End Enum

        Function GetSourceUrl() As String
        Function GetSourceUrl(ByRef champ As Champion) As String
        Function GetSourceUrl(ByRef champ As Champion, ByVal lane As laneType) As String
    End Interface
End Namespace
