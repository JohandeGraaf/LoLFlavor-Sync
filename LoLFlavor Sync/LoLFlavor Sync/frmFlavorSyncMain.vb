Imports LoLFlavor_Sync.Library
Imports System.IO
Public Class frmFlavorSyncMain
    Public Property frmState As Boolean
        Set(value As Boolean)
            For i As Integer = 0 To Me.Controls.Count - 1
                Me.Controls(i).Enabled = value
            Next
        End Set
        Get
            For i As Integer = 0 To Me.Controls.Count - 1
                If Me.Controls(i).Enabled Then
                    Return True
                End If
            Next
            Return False
        End Get
    End Property

    Private Sub FormLoad()
        Me.Text = "LoLFlavor Sync " & Properties.VersionLocal
        Me.MenuStrip1.BackColor = Color.FromArgb(130, 186, 201, 212)
        If Properties.OptionLastUsed = Nothing Then
            lblLastUsed.Text = "Never"
        Else
            lblLastUsed.Text = Properties.OptionLastUsed.ToShortDateString() & " - " & Properties.OptionLastUsed.ToShortTimeString()
        End If
        initializeClbChamps(True)
        CheckNewVersion()
        ActiveControl = btnDownloadBuilds
    End Sub

    Private Sub initializeClbChamps(ByVal checkAll As Boolean)
        clbChamps.Items.Clear()
        For Each obj As Champion In Properties.AllChampions
            clbChamps.Items.Add(obj.DisplayName)
        Next
        If checkAll Then CheckAllItems()
    End Sub

    Private Sub CheckNewVersion()
        If Properties.OptionVersionCheckDisabled Then Exit Sub
        Try
            If System.IO.Directory.Exists(Properties.TempDirVersion) Then
                Properties.DelFolderContent(Properties.TempDirVersion)
            Else
                My.Computer.FileSystem.CreateDirectory(TempDirVersion)
            End If

            Using dl As New Download : With dl
                    .Timeout = 4000
                    .Download(Properties.VersionUrl, Properties.TempDirVersion & "\" & Properties.VersionFileName)
                End With
            End Using

            If File.Exists(Properties.TempDirVersion & "\" & Properties.VersionFileName) Then
                Dim v As String = Properties.ReadFile(Properties.TempDirVersion & "\" & Properties.VersionFileName)
                If String.IsNullOrWhiteSpace(v) Then
                    Throw New IOException("Error while reading versionfile. No data.")
                Else
                    Properties.VersionOnline = v
                End If
            Else
                Throw New FileNotFoundException("Error while reading versionfile. No file at " & Properties.TempDirVersion & "\" & Properties.VersionFileName)
            End If

            If String.Compare(Properties.VersionLocal, Properties.VersionOnline) <> 0 Then
                Dim popup As New NotifyIcon
                AddHandler popup.BalloonTipClicked, Sub(sender As Object, e As EventArgs) Process.Start(Properties.UrlExecutable)
                popup.BalloonTipTitle = "LoLFlavor Sync " & Properties.VersionLocal
                popup.BalloonTipText = "New version available." & Environment.NewLine & "Click here to download LoLFlavor Sync " & Properties.VersionOnline
                popup.BalloonTipIcon = ToolTipIcon.Info
                popup.Icon = Me.Icon
                popup.Visible = True
                popup.ShowBalloonTip(10000)
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            DelFolderContent(Properties.TempDirVersion, True)
        End Try
    End Sub

    Private Sub Settings()
        Dim frm As New frmFlavorSyncSettings
        frmState = False
        frm.ShowDialog()
        If frm.RenewChampions Then initializeClbChamps(True)
        If frm.Quit Then Environment.Exit(0)
        frm.Dispose()
        frmState = True
    End Sub

    Private Sub DownloadBuilds()
        Dim buildsChecked As Func(Of CheckBox(), Integer) = _
            Function(x)
                Dim num As Integer = 0
                For Each obj In x
                    If obj.Checked Then
                        num += 1
                    End If
                Next
                Return num
            End Function

        If Not Properties.ValidLoLPath(Properties.LoLPath) Then
            MessageBox.Show("Incorrect League of Legends directory specified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If clbChamps.CheckedIndices.Count <= 0 Then
            MessageBox.Show("Please select at least one champion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If buildsChecked({chkDownloadLane, chkDownloadJungle, chkDownloadSupport, chkDownloadARAM}) <= 0 Then
            MessageBox.Show("Please select at least one build type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("You are about to download " & If(clbChamps.CheckedIndices.Count <= 1 And buildsChecked({chkDownloadLane, chkDownloadJungle, chkDownloadSupport, chkDownloadARAM}) <= 1, "a build", "builds") & " for " & clbChamps.CheckedIndices.Count & " " & If(clbChamps.CheckedIndices.Count > 1, "champions", "champion") & ", are you sure?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim champsToDownload As New List(Of Champion)
        For Each obj As Integer In clbChamps.CheckedIndices
            champsToDownload.Add(Properties.AllChampions.ElementAt(obj))
        Next

        Dim buildTypesToDownload As New List(Of DownloadChampion.laneType)
        If chkDownloadLane.Checked Then buildTypesToDownload.Add(DownloadChampion.laneType.lane)
        If chkDownloadJungle.Checked Then buildTypesToDownload.Add(DownloadChampion.laneType.jungle)
        If chkDownloadSupport.Checked Then buildTypesToDownload.Add(DownloadChampion.laneType.support)
        If chkDownloadARAM.Checked Then buildTypesToDownload.Add(DownloadChampion.laneType.aram)

        Properties.OptionLastUsed = DateTime.Now
        frmState = False

        Dim frmDownload As New frmFlavorSyncDownload(champsToDownload, buildTypesToDownload)
        frmDownload.ShowDialog()
        frmDownload.Dispose()
        frmDownload = Nothing

        frmState = True
    End Sub

    Private Sub CheckAllItems()
        For i = 0 To clbChamps.Items.Count - 1
            clbChamps.SetItemCheckState(i, CheckState.Checked)
        Next
    End Sub

    Private Sub UncheckAllItems()
        For i = 0 To clbChamps.Items.Count - 1
            clbChamps.SetItemCheckState(i, CheckState.Unchecked)
        Next
    End Sub

#Region "Event Handlers"
    Private Sub frmFlavorSync_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormLoad()
    End Sub

    Private Sub btnDownloadBuilds_Click(sender As Object, e As EventArgs) Handles btnDownloadBuilds.Click
        DownloadBuilds()
    End Sub

    Private Sub DownloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadToolStripMenuItem.Click
        DownloadBuilds()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Settings()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Environment.Exit(0)
    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        CheckAllItems()
    End Sub

    Private Sub btnDeselectAll_Click(sender As Object, e As EventArgs) Handles btnDeselectAll.Click
        UncheckAllItems()
    End Sub

    Private Sub frmFlavorSync_Close() Handles MyBase.FormClosed
        Environment.Exit(0)
    End Sub
#End Region
End Class
