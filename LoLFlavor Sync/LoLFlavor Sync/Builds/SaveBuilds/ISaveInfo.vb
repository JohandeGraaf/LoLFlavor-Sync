Imports LoLFlavor_Sync.Lib
Imports LoLFlavor_Sync.DLBuilds

Namespace Global.LoLFlavor_Sync.SaveBuilds
    Public Interface ISaveInfo

#Region "DestinationPathBase"

        Function GetDestinationPathBase() As String
        Function GetDestinationPathBase(ByRef champ As Champion) As String
        Function GetDestinationPathBase(ByRef champ As Champion, ByVal lane As IDownloadInfo.laneType) As String

#End Region

#Region "DestinationPath"

        Function GetDestinationPath() As String
        Function GetDestinationPath(ByRef champ As Champion) As String
        Function GetDestinationPath(ByRef champ As Champion, ByVal lane As IDownloadInfo.laneType) As String

#End Region

#Region "DestinationFile"

        Function GetDestinationFile() As String
        Function GetDestinationFile(ByRef champ As Champion) As String
        Function GetDestinationFile(ByRef champ As Champion, ByVal lane As IDownloadInfo.laneType) As String

#End Region

#Region "FullPath"

        Function GetFullPath() As String
        Function GetFullPath(ByRef champ As Champion) As String
        Function GetFullPath(ByVal lane As IDownloadInfo.laneType) As String
        Function GetFullPath(ByRef champ As Champion, ByVal lane As IDownloadInfo.laneType) As String

#End Region

    End Interface
End Namespace
