Imports LoLFlavor_Sync.Lib
Imports LoLFlavor_Sync.DLBuilds

Namespace Global.LoLFlavor_Sync.SaveBuilds
    Public Class SaveInfoLF : Implements ISaveInfo
        Private destPathBase As String
        Private destPath As String
        Private destFile As String

        Sub New(ByVal _DestinationPathBase As String, ByVal _DestinationPath As String, ByVal _DestinationFile As String)
            Me.destPathBase = _DestinationPathBase
            Me.destPath = _DestinationPath
            Me.destFile = _DestinationFile
        End Sub

#Region "DestinationPathBase"

        Public Function GetDestinationPathBase() As String Implements ISaveInfo.GetDestinationPathBase
            Return Me.destPathBase
        End Function

        Public Function GetDestinationPathBase(ByRef champ As [Lib].Champion) As String Implements ISaveInfo.GetDestinationPathBase
            Return GetDestinationPathBase().Replace(Properties.ChampionVar, champ.Name)
        End Function

        Public Function GetDestinationPathBase(ByRef champ As [Lib].Champion, lane As DLBuilds.IDownloadInfo.laneType) As String Implements ISaveInfo.GetDestinationPathBase
            Return GetDestinationPathBase(champ).Replace(Properties.LaneVar, lane.ToString())
        End Function

#End Region

#Region "DestinationPath"

        Public Function GetDestinationPath() As String Implements ISaveInfo.GetDestinationPath
            Return Me.destPath
        End Function

        Public Function GetDestinationPath(ByRef champ As [Lib].Champion) As String Implements ISaveInfo.GetDestinationPath
            Return GetDestinationPath().Replace(Properties.ChampionVar, champ.Name)
        End Function

        Public Function GetDestinationPath(ByRef champ As [Lib].Champion, lane As DLBuilds.IDownloadInfo.laneType) As String Implements ISaveInfo.GetDestinationPath
            Return GetDestinationPath(champ).Replace(Properties.LaneVar, lane.ToString())
        End Function

#End Region

#Region "DestinationFile"

        Public Function GetDestinationFile() As String Implements ISaveInfo.GetDestinationFile
            Return Me.destFile
        End Function

        Public Function GetDestinationFile(ByRef champ As [Lib].Champion) As String Implements ISaveInfo.GetDestinationFile
            Return GetDestinationFile().Replace(Properties.ChampionVar, champ.Name)
        End Function

        Public Function GetDestinationFile(ByRef champ As [Lib].Champion, lane As DLBuilds.IDownloadInfo.laneType) As String Implements ISaveInfo.GetDestinationFile
            Return GetDestinationFile(champ).Replace(Properties.LaneVar, lane.ToString())
        End Function

#End Region

#Region "FullPath"

        Public Function GetFullPath() As String Implements ISaveInfo.GetFullPath
            Return GetDestinationPathBase() & GetDestinationPath() & GetDestinationFile()
        End Function

        Public Function GetFullPath(lane As DLBuilds.IDownloadInfo.laneType) As String Implements ISaveInfo.GetFullPath
            Return GetFullPath().Replace(Properties.LaneVar, lane.ToString())
        End Function

        Public Function GetFullPath(ByRef champ As [Lib].Champion) As String Implements ISaveInfo.GetFullPath
            Return GetFullPath().Replace(Properties.ChampionVar, champ.Name)
        End Function

        Public Function GetFullPath(ByRef champ As [Lib].Champion, lane As DLBuilds.IDownloadInfo.laneType) As String Implements ISaveInfo.GetFullPath
            Return GetFullPath().Replace(Properties.ChampionVar, champ.Name).Replace(Properties.LaneVar, lane.ToString())
        End Function

#End Region
    End Class
End Namespace
