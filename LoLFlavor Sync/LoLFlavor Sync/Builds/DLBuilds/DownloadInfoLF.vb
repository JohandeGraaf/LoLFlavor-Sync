Imports LoLFlavor_Sync.Lib
Imports LoLFlavor_Sync.DLBuilds

Namespace Global.LoLFlavor_Sync.DLBuilds
    Public Class DownloadInfoLF : Implements IDownloadInfo
        Private srcUrl As String

        Sub New(ByVal _SourceUrl As String)
            Me.srcUrl = _SourceUrl
        End Sub

        Public Function GetSourceUrl() As String Implements IDownloadInfo.GetSourceUrl
            Return Me.srcUrl
        End Function
        Public Function GetSourceUrl(ByRef champ As Champion) As String Implements IDownloadInfo.GetSourceUrl
            Return GetSourceUrl().Replace(Properties.ChampionVar, champ.Name)
        End Function
        Public Function GetSourceUrl(ByRef champ As Champion, ByVal lane As IDownloadInfo.laneType) As String Implements IDownloadInfo.GetSourceUrl
            Return GetSourceUrl(champ).Replace(Properties.LaneVar, lane.ToString)
        End Function
    End Class
End Namespace
