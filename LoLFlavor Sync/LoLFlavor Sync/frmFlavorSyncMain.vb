Imports LoLFlavor_Sync.Lib
Imports System.IO
Imports LoLFlavor_Sync.DLBuilds

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
        If Properties.Garena Then
            Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " (Garena)"
        Else
            Me.Text = "LoLFlavor Sync " & Properties.VersionLocal
        End If
        Me.MenuStrip1.BackColor = Color.FromArgb(130, 186, 201, 212)
        Me.cmbMode.SelectedIndex = 0
        If Properties.OptionLastUsed = Nothing Then
            lblLastUsed.Text = "Never"
        Else
            lblLastUsed.Text = Properties.OptionLastUsed.ToShortDateString() & " - " & Properties.OptionLastUsed.ToShortTimeString()
        End If
        initializeClbChamps(True)
        ActiveControl = btnDownloadBuilds
    End Sub

    Private Sub FormShown()
        Application.DoEvents()
        Me.lblLoLFlavorUpdated.Text = LFVersion()
        CheckNewVersion()
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
            Dim cl As New System.Net.WebClient
            Dim str As New StreamReader(cl.OpenRead(Properties.VersionUrl))

            Properties.VersionOnline = str.ReadToEnd()
            str.Close()
            cl.Dispose()

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
            If Properties.Verbose > 0 Then MessageBox.Show(ex.Message() & Environment.NewLine & ex.ToString() & Environment.NewLine & ex.HResult())
            Exit Sub
        End Try
    End Sub

    Private Function LFVersion() As String
        Dim dt As DateTime
        Try
            Dim cl As New System.Net.WebClient
            Dim stread As New StreamReader(cl.OpenRead(Properties.VersionLFS))
            Dim rawData As String = stread.ReadToEnd()
            stread.Close()
            Dim firstIndex As Integer = rawData.IndexOf("""createDate""") + ("""createDate""").Count + 2
            Dim lastIndex As Integer = rawData.Substring(firstIndex).IndexOf("""")
            Dim rawDate As String = rawData.Substring(firstIndex, lastIndex)
            dt = Date.Parse(rawDate)
        Catch ex As Exception
            If Properties.Verbose > 0 Then MessageBox.Show(ex.Message() & Environment.NewLine & ex.ToString() & Environment.NewLine & ex.HResult())
            Return "Error"
        End Try

        If dt = Nothing OrElse dt = (New DateTime) Then
            Return "Unknown"
        Else
            Return dt.ToShortDateString() & " - " & dt.ToShortTimeString()
        End If
    End Function

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

        If cmbMode.SelectedIndex <> 2 Then
            If MessageBox.Show("You are about to download " & If(clbChamps.CheckedIndices.Count <= 1 And buildsChecked({chkDownloadLane, chkDownloadJungle, chkDownloadSupport, chkDownloadARAM}) <= 1, "a build", "builds") & " for " & clbChamps.CheckedIndices.Count & " " & If(clbChamps.CheckedIndices.Count > 1, "champions", "champion") & ", are you sure?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        Else
            If MessageBox.Show("Remove all builds?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        End If

        Dim champsToDownload As New List(Of Champion)
        For Each obj As Integer In clbChamps.CheckedIndices
            champsToDownload.Add(Properties.AllChampions.ElementAt(obj))
        Next

        Dim buildTypesToDownload As New List(Of IDownloadInfo.laneType)
        If chkDownloadLane.Checked Then buildTypesToDownload.Add(IDownloadInfo.laneType.lane)
        If chkDownloadJungle.Checked Then buildTypesToDownload.Add(IDownloadInfo.laneType.jungle)
        If chkDownloadSupport.Checked Then buildTypesToDownload.Add(IDownloadInfo.laneType.support)
        If chkDownloadARAM.Checked Then buildTypesToDownload.Add(IDownloadInfo.laneType.aram)

        Properties.OptionLastUsed = DateTime.Now
        frmState = False

        Dim frmDownload As New frmFlavorSyncDownload(New GetBuilds(GetBuilds.Source.LoLFlavor, champsToDownload, buildTypesToDownload))

        If cmbMode.SelectedIndex = 0 Then
            frmDownload.mode = frmFlavorSyncDownload.modes.Remove
        ElseIf cmbMode.SelectedIndex = 1 Then
            frmDownload.mode = frmFlavorSyncDownload.modes.Overwrite
        ElseIf cmbMode.SelectedIndex = 2 Then
            frmDownload.mode = frmFlavorSyncDownload.modes.RemoveOnly
        End If

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

    Private Sub frmFlavorSyncMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FormShown()
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
