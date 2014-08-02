Public Class frmFlavorSyncMain
    Public champsToDownload() As String

    Public Property getLoLPath As String
        Get
            Return frmFlavorSyncLoad.getLoLPath
        End Get
        Set(value As String)
            frmFlavorSyncLoad.GetLoLPath = value
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

    Private Sub frmFlavorSync_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initializeClbChamps()
        ActiveControl = btnDownloadBuilds
        If lastUsed = Nothing Then lblLastUsed.Text = "Never" Else lblLastUsed.Text = lastUsed.ToShortDateString & " - " & lastUsed.ToShortTimeString
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