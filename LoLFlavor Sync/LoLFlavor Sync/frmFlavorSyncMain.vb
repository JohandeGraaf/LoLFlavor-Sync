Imports System.IO
Public Class frmFlavorSyncMain
    Public champsToDownload() As String
    Public localVersion As String = "1.6.2"
    Public onlineVersion As String
    Public versionUrl As String = "https://raw.githubusercontent.com/Ampersand0/LoLFlavor-Sync/master/LoLFlavor%20Sync.version?rand=" & (New Random).Next(0, 9999)
    Public versionFileName As String = "LoLFlavorSync.version"

    Public Property getLoLPath As String
        Get
            Return frmFlavorSyncLoad.getLoLPath
        End Get
        Set(value As String)
            frmFlavorSyncLoad.getLoLPath = value
        End Set
    End Property

    Public Property downloadLane As Boolean
        Get
            Return chkDownloadLane.Checked
        End Get
        Set(value As Boolean)
            chkDownloadLane.Checked = value
        End Set
    End Property

    Public Property downloadJungle As Boolean
        Get
            Return chkDownloadJungle.Checked
        End Get
        Set(value As Boolean)
            chkDownloadJungle.Checked = value
        End Set
    End Property

    Public Property downloadSupport As Boolean
        Get
            Return chkDownloadSupport.Checked
        End Get
        Set(value As Boolean)
            chkDownloadSupport.Checked = value
        End Set
    End Property

    Public Property downloadARAM As Boolean
        Get
            Return chkDownloadARAM.Checked
        End Get
        Set(value As Boolean)
            chkDownloadARAM.Checked = value
        End Set
    End Property

    Public WriteOnly Property formFlavorSyncMainEnabled As Boolean
        Set(value As Boolean)
            clbChamps.Enabled = value
            btnDownloadBuilds.Enabled = value
            btnSettings.Enabled = value
            btnSelectAll.Enabled = value
            btnDeselectAll.Enabled = value
            chkDownloadLane.Enabled = value
            chkDownloadJungle.Enabled = value
            chkDownloadSupport.Enabled = value
            chkDownloadARAM.Enabled = value
        End Set
    End Property

    Private Property lastUsed As Date
        Get
            If String.IsNullOrWhiteSpace(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\FlavorSync", "lastUsed", "")) Then
                Return Nothing
            Else
                Return Date.Parse(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\FlavorSync", "lastUsed", ""))
            End If
        End Get
        Set(value As Date)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\FlavorSync", "lastUsed", value.ToString(), Microsoft.Win32.RegistryValueKind.String)
        End Set
    End Property

    Private Sub frmFlavorSync_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "LoLFlavor Sync " & localVersion
        initializeClbChamps()
        If lastUsed = Nothing Then lblLastUsed.Text = "Never" Else lblLastUsed.Text = lastUsed.ToShortDateString & " - " & lastUsed.ToShortTimeString
        ActiveControl = btnDownloadBuilds
        CheckNewVersion()
    End Sub

    Public Sub initializeClbChamps(Optional ByVal SelectAll As Boolean = True)
        clbChamps.Items.Clear()
        For Each i As String In frmFlavorSyncLoad.champs
            clbChamps.Items.Add(i)
        Next
        If SelectAll Then
            btnSelectAll.Enabled = True
            btnSelectAll.PerformClick()
        End If
    End Sub

    Private Sub CheckNewVersion()
        Dim tmpDir As String = Environment.GetEnvironmentVariable("TEMP") & "\FlavorSyncVersion"
        Try
            DelFolderContent(tmpDir)
            DownloadFile(versionUrl, tmpDir & "\" & versionFileName)
            If File.Exists(tmpDir & "\" & versionFileName) Then
                ReadVersion(tmpDir & "\" & versionFileName)
            End If
            If String.Compare(localVersion, onlineVersion) <> 0 Then
                Dim popup As New NotifyIcon
                AddHandler popup.BalloonTipClicked, AddressOf popup_Clicked
                popup.BalloonTipTitle = "LoLFlavor Sync " & localVersion
                popup.BalloonTipText = "New version available." & Environment.NewLine & "Click here to download LoLFlavor Sync " & onlineVersion
                popup.BalloonTipIcon = ToolTipIcon.Info
                popup.Icon = Me.Icon
                popup.Visible = True
                popup.ShowBalloonTip(10000)
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            DelFolderContent(tmpDir)
            My.Computer.FileSystem.DeleteDirectory(tmpDir, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        End Try
    End Sub

    Private Sub popup_Clicked(sender As Object, e As EventArgs)
        Process.Start("http://lolflavorsync.mcpvp.eu")
    End Sub

    Private Sub ReadVersion(ByVal path As String)
        Dim fs As New System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate)
        Dim fileBuffer(fs.Length - 1) As Byte
        fs.Read(fileBuffer, 0, fs.Length)
        fs.Dispose()
        fs.Close()
        onlineVersion = System.Text.Encoding.UTF8.GetString(fileBuffer)
    End Sub

    Private Sub DownloadFile(ByVal url As String, ByVal path As String)
        My.Computer.Network.DownloadFile(url, path, "", "", False, 4000, True)
    End Sub

    Private Sub DelFolderContent(ByVal path As String)
        If System.IO.Directory.Exists(path) Then
            For Each foundFile As String In Enumerable.Reverse(My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchAllSubDirectories))
                My.Computer.FileSystem.DeleteFile(foundFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Next
            For Each foundFolder As String In Enumerable.Reverse(My.Computer.FileSystem.GetDirectories(path, FileIO.SearchOption.SearchAllSubDirectories))
                My.Computer.FileSystem.DeleteDirectory(foundFolder, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Next
        Else
            My.Computer.FileSystem.CreateDirectory(path)
        End If
    End Sub


    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        For i = 0 To clbChamps.Items.Count - 1
            clbChamps.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub btnDeselectAll_Click(sender As Object, e As EventArgs) Handles btnDeselectAll.Click
        For i = 0 To clbChamps.Items.Count - 1
            clbChamps.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Dim frmSettings As New frmFlavorSyncSettings
        formFlavorSyncMainEnabled = False
        frmSettings.ShowDialog()
        frmSettings.Focus()
    End Sub

    Private Sub btnDownloadBuilds_Click(sender As Object, e As EventArgs) Handles btnDownloadBuilds.Click
        Dim CheckedCount As Integer = 0
        Dim count As Integer = 0
        For i = 0 To clbChamps.Items.Count - 1
            If clbChamps.GetItemChecked(i) Then
                CheckedCount = CheckedCount + 1
            End If
        Next
        If CheckedCount = 0 Then
            MessageBox.Show("Select at least one champion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If chkDownloadLane.Checked = False And chkDownloadJungle.Checked = False And chkDownloadSupport.Checked = False And chkDownloadARAM.Checked = False Then
            MessageBox.Show("Select at least one build type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Not frmFlavorSyncLoad.checkLoLPath(getLoLPath) Then
            MessageBox.Show("Incorrect League of Legends directory specified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show("You are about to download builds for " & CheckedCount & " champion(s), are you sure?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        ReDim Preserve champsToDownload(CheckedCount - 1)

        For Each i In clbChamps.CheckedIndices
            champsToDownload(count) = frmFlavorSyncLoad.champs(i)
            count = count + 1
        Next
        lastUsed = DateTime.Now
        formFlavorSyncMainEnabled = False

        Dim frmDownload As New frmFlavorSyncDownload
        frmDownload.ShowDialog()
        frmDownload.Focus()
    End Sub

    Private Sub frmFlavorSync_Close() Handles MyBase.FormClosed
        Environment.Exit(0)
    End Sub
End Class