Imports LoLFlavor_Sync.Domain
Namespace Global.LoLFlavor_Sync.DLBuilds
    Public Interface IDownloadBehaviour
        Function DownloadBuild(ByRef champ As Champion, ByVal lane As IDownloadInfo.laneType) As Build
    End Interface
End Namespace
