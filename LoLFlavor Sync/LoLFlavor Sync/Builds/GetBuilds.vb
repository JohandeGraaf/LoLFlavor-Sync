Imports System.IO
Imports LoLFlavor_Sync.Lib
Imports LoLFlavor_Sync.DLBuilds
Imports LoLFlavor_Sync.SaveBuilds

Public Class GetBuilds
    Private _DownloadCompleted As Boolean = False
    Private _Saved As Boolean = False

    Private _Builds As New List(Of Build)

    Private _ChampsToDownload As List(Of Champion)
    Private _BuildsToDownload As List(Of IDownloadInfo.laneType)
    Private _DownloadBehaviour As IDownloadBehaviour
    Private _DownloadInfo As IDownloadInfo

    Private _SaveBehaviour As ISaveBehaviour
    Private _SaveInfo As ISaveInfo

    Private _UpdateLabel As Action(Of String)
    Private _UpdateStatus As Action(Of String)
    Private _UpdatePB As Action

    Private _Cancel As Boolean = False

    Public Enum Source As Integer
        LoLFlavor
    End Enum

    Public ReadOnly Property GetChampsToDownload As List(Of Champion)
        Get
            Return _ChampsToDownload
        End Get
    End Property

    Public ReadOnly Property GetBuildsToDownload As List(Of IDownloadInfo.laneType)
        Get
            Return _BuildsToDownload
        End Get
    End Property

    Public ReadOnly Property GetDownloadedBuilds As List(Of Build)
        Get
            Return _Builds
        End Get
    End Property

    Public ReadOnly Property DownloadCompleted As Boolean
        Get
            Return _DownloadCompleted
        End Get
    End Property

    Public ReadOnly Property Saved As Boolean
        Get
            Return _Saved
        End Get
    End Property

    Public Sub SetUpdateLabel(ByRef [delegate] As Action(Of String))
        Me._UpdateLabel = [delegate]
    End Sub

    Public Sub SetUpdateStatus(ByRef [delegate] As Action(Of String))
        Me._UpdateStatus = [delegate]
    End Sub

    Public Sub SetUpdatePB(ByRef [delegate] As Action)
        Me._UpdatePB = [delegate]
    End Sub

    Public Sub New(ByVal src As Source, ByVal champsToDownload As List(Of Champion), ByVal buildsToDownload As List(Of IDownloadInfo.laneType))
        Me._ChampsToDownload = champsToDownload
        Me._BuildsToDownload = buildsToDownload

        If src = Source.LoLFlavor Then
            If Properties.Garena Then
                Me._DownloadInfo = (New DownloadInfoLF(Properties.LoLFlavorSourceUrlFormat))
                Me._SaveInfo = (New SaveInfoLF(Properties.LoLPath, Properties.GarenaDestinationPath, Properties.GarenaDestinationFile))
            Else
                Me._DownloadInfo = (New DownloadInfoLF(Properties.LoLFlavorSourceUrlFormat))
                Me._SaveInfo = (New SaveInfoLF(Properties.LoLPath, Properties.RiotDestinationPath, Properties.RiotDestinationFile))
            End If
            Me._DownloadBehaviour = (New DownloadBehaviourLF(_DownloadInfo))
            Me._SaveBehaviour = (New SaveBehaviourLF(_SaveInfo))
        End If
    End Sub

    Private Sub resetDelegates()
        _UpdateLabel = Nothing
        _UpdateStatus = Nothing
        _UpdatePB = Nothing
    End Sub

    Public Function Download() As List(Of Build)
        _Cancel = False
        For Each objChampion As Champion In _ChampsToDownload
            If _UpdateLabel IsNot Nothing Then _UpdateLabel("Downloading builds for: " & objChampion.DisplayName)
            If _UpdateStatus IsNot Nothing Then _UpdateStatus("Downloading builds for: " & objChampion.DisplayName)
            For Each objBuildType As IDownloadInfo.laneType In _BuildsToDownload
                If _Cancel Then
                    _DownloadCompleted = False
                    _Builds = Nothing
                    resetDelegates()
                    Return Nothing
                End If
                Dim lStrF As String = objBuildType.ToString.ElementAt(0)
                Dim lStr As String = lStrF.ToUpper & objBuildType.ToString.Remove(0, 1)
                Try
                    Dim nBuild As Build = _DownloadBehaviour.DownloadBuild(objChampion, objBuildType)
                    _Builds.Add(nBuild)
                    If _UpdateStatus IsNot Nothing Then _UpdateStatus(lStr & " Success")
                Catch ex As Exception
                    If _UpdateStatus IsNot Nothing Then _UpdateStatus(lStr & " Failed: " & ex.Message)
                End Try
                If _UpdatePB IsNot Nothing Then _UpdatePB()
            Next
            If _UpdateStatus IsNot Nothing Then _UpdateStatus(" ")
        Next
        resetDelegates()
        _DownloadCompleted = True
        Return _Builds
    End Function

    Private Sub prepareSaving(ByVal RemoveOldBuilds As Boolean)
        Dim del As New List(Of String)
        Dim path As String = If(_SaveInfo.GetDestinationPath.Contains(Properties.ChampionVar), _
                                    _SaveInfo.GetDestinationPathBase & _SaveInfo.GetDestinationPath.Substring(0, _SaveInfo.GetDestinationPath.IndexOf(Properties.ChampionVar)), _
                                    _SaveInfo.GetDestinationPathBase & _SaveInfo.GetDestinationPath)

        If Not Directory.Exists(path) Then
            RemoveOldBuilds = False
            Directory.CreateDirectory(path)
        End If

        For Each objChampion As Champion In Properties.AllChampions
            Dim pth1 As String = _SaveInfo.GetDestinationPathBase(objChampion) & _SaveInfo.GetDestinationPath(objChampion)


            If Directory.Exists(pth1) Then
                del.Add(pth1)
            Else
                Dim pth2 As String = pth1.Substring(0, pth1.IndexOf(objChampion.Name) + objChampion.Name.Count + 1)
                If Not Directory.Exists(pth2) Then
                    Directory.CreateDirectory(pth2)
                End If
                Directory.CreateDirectory(pth1)
            End If
        Next

        If RemoveOldBuilds Then
            For Each objStr As String In del
                Properties.DelFolderContent(objStr, False)
            Next
        End If
    End Sub

    Public Sub Save(ByVal RemoveOldBuilds As Boolean)
        _Cancel = False
        prepareSaving(RemoveOldBuilds)
        If _DownloadCompleted Then
            For Each objBuild As Build In _Builds
                If _Cancel Then
                    resetDelegates()
                    _Saved = False
                    Return
                End If
                Try
                    _SaveBehaviour.SaveBuild(objBuild)
                    If _UpdatePB IsNot Nothing Then _UpdatePB()
                Catch ex As Exception
                End Try
            Next
        Else
            Throw New DownloadNotCompletedException("Please invoke the Download method before saving the builds.", (New NotSupportedException()))
        End If

        resetDelegates()
        _Saved = True
    End Sub

    Public Sub RemoveAllBuilds()
        For Each objChampion As Champion In Properties.AllChampions
            Dim path As String = _SaveInfo.GetDestinationPathBase(objChampion) & _SaveInfo.GetDestinationPath(objChampion)
            If Directory.Exists(path) Then
                Properties.DelFolderContent(path, False)
            End If
        Next
    End Sub

    Public Sub Cancel()
        _Cancel = True
    End Sub
End Class
