Public Class frmFlavorSyncSettings
    Public WriteOnly Property SaveLoLPath As String
        Set(value As String)
            frmFlavorSyncLoad.getLoLPath = value
        End Set
    End Property

    Private Sub LoadSettings()
        txtLoLPath.Text = frmFlavorSyncLoad.getLoLPath
        chkHide.Checked = frmFlavorSyncLoad.skipForm
        chkLoLFlavor.Checked = frmFlavorSyncLoad.sourceLoLFlavor
    End Sub

    Private Sub SaveSettings(ByVal btn As String)
        If btn = "Cancel" Then
            Me.Close()
            Exit Sub
        End If
        If Not chkLoLFlavor.Checked Then
            MessageBox.Show("Please select at least one source.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        SaveLoLPath = txtLoLPath.Text
        frmFlavorSyncLoad.skipForm = chkHide.Checked
        frmFlavorSyncLoad.sourceLoLFlavor = chkLoLFlavor.Checked
        If btn = "OK" Then
            Me.Close()
        ElseIf btn = "Apply" Then
            btnApply.Enabled = False
        End If
    End Sub

#Region "Event Handlers"
    Private Sub frmFlavorSyncSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettings()
    End Sub

    Private Sub chkHide_CheckedChanged(sender As Object, e As EventArgs) Handles chkHide.CheckedChanged
        btnApply.Enabled = True
    End Sub

    Private Sub chkLoLFlavor_CheckedChanged(sender As Object, e As EventArgs) Handles chkLoLFlavor.CheckedChanged
        btnApply.Enabled = True
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        fbdLoLPath.SelectedPath = txtLoLPath.Text
        fbdLoLPath.ShowDialog()
        If frmFlavorSyncLoad.checkLoLPath(fbdLoLPath.SelectedPath) Then
            txtLoLPath.Text = fbdLoLPath.SelectedPath
            btnApply.Enabled = True
        Else
            MessageBox.Show("Incorrect directory specified. Please make sure you are selecting your League of Legends directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub lblGetLatestVersion_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblGetLatestVersion.LinkClicked
        Process.Start("http://lolflavorsync.mcpvp.eu")
    End Sub

    Private Sub lblBoLProfile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblBoLProfile.LinkClicked
        Process.Start("http://botoflegends.com/forum/user/59209-ampersand/")
    End Sub

    Private Sub lblSkype_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblSkype.LinkClicked
        Process.Start("skype:Johan_degraaf95?chat")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://github.com/Ampersand0")
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        SaveSettings("OK")
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        SaveSettings("Cancel")
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        SaveSettings("Apply")
    End Sub

    Private Sub frmFlavorSyncSettings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmFlavorSyncMain.formFlavorSyncMainEnabled = True
    End Sub
#End Region
End Class