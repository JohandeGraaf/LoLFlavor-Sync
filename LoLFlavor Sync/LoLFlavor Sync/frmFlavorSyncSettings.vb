Imports LoLFlavor_Sync.Library
Public Class frmFlavorSyncSettings

    Public Property RenewChampions As Boolean
    Public Property Quit As Boolean

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If Properties.Garena Then
            Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " (Garena)"
        Else
            Me.Text = "LoLFlavor Sync " & Properties.VersionLocal
        End If
        Me.AcceptButton = btnOk
        Me.CancelButton = btnCancel
        Me.txtLoLPath.Text = Properties.LoLPath
        Me.chkHide.Checked = Not Properties.OptionSkipForm
        Me.chkCheckNewVersion.Checked = Not Properties.OptionVersionCheckDisabled
        Me.txtChangelog.Text = Properties.Changelog
        Me.txtAbout.Text = Properties.About
        Me.btnApply.Enabled = False
    End Sub

    Private Sub LoadSettings()

    End Sub

    Private Sub SaveSettings(ByVal save As Boolean, ByVal close As Boolean)
        If Not save Then
            Me.Close()
        Else
            Properties.OptionSkipForm = Not chkHide.Checked
            Properties.OptionVersionCheckDisabled = Not chkCheckNewVersion.Checked

            If Properties.OptionSkipForm Then
                Properties.OptionLoLPath = Properties.LoLPath
            Else
                Properties.OptionLoLPath = ""
            End If

            If close Then
                Me.Close()
            Else
                btnApply.Enabled = False
            End If
        End If
    End Sub

    Private Sub DefaultSettings()
        If MessageBox.Show("Restore default settings? This will restart LoLFlavor Sync.", "Restore defaults", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Properties.DeleteRegistryKeys()
            If System.IO.File.Exists(Environment.GetCommandLineArgs(0)) Then
                Process.Start(Environment.GetCommandLineArgs(0))
            End If
            Quit = True
            Me.Close()
        End If
    End Sub

    Private Sub ChangeLoLPath()
        fbdLoLPath.SelectedPath = Properties.LoLPath
        If fbdLoLPath.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        If Properties.ValidLoLPath(fbdLoLPath.SelectedPath) Then
            Properties.LoLPath = fbdLoLPath.SelectedPath
            txtLoLPath.Text = Properties.LoLPath
        Else
            MessageBox.Show("Incorrect directory specified. Please make sure you are selecting your League of Legends directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Properties.Garena Then Properties.DetectGarenaPath()
    End Sub

    Private Sub AddChampion(ByVal Name As String, Optional ByVal DisplayName As String = Nothing)
        For Each obj As Champion In Properties.AllChampions
            If obj.Name.ToLower() = Name.ToLower() Then
                MessageBox.Show("Champion already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Next
        If String.IsNullOrWhiteSpace(DisplayName) Then
            Properties.AllChampions.Add(New Champion(Name))
        Else
            Properties.AllChampions.Add(New Champion(Name, DisplayName))
        End If
        RenewChampions = True
        MessageBox.Show("Champion added!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub moveItemToEndOfArray(ByRef Ar As Array, ByVal Indextomove As Integer)
        Dim Index = Indextomove
        Dim PlacesToMove As Integer = (Ar.Length - 1) - Index
        If PlacesToMove <> 0 Then
            For i = 1 To PlacesToMove
                Dim temp As Object = Ar(Index + 1)
                Ar(Index + 1) = Ar(Index)
                Ar(Index) = temp
                Index = Index + 1
            Next
        End If
    End Sub

#Region "Event Handlers"
    Private Sub frmFlavorSyncSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettings()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        'About tab
        If TabControl1.SelectedIndex = 1 Then
            txtChangelog.Select(txtChangelog.TextLength, 0)
            txtChangelog.ScrollToCaret()
        End If
    End Sub

    Private Sub chkHide_Click(sender As Object, e As EventArgs) Handles chkHide.Click
        btnApply.Enabled = True
    End Sub

    Private Sub chkCheckNewVersion_CheckedChanged(sender As Object, e As EventArgs) Handles chkCheckNewVersion.CheckedChanged
        btnApply.Enabled = True
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        ChangeLoLPath()
    End Sub

    Private Sub btnAddChamp_Click(sender As Object, e As EventArgs) Handles btnAddChamp.Click
        If String.IsNullOrWhiteSpace(txtAddChamp.Text) Then
            MessageBox.Show("Please enter a valid champion name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            AddChampion(txtAddChamp.Text)
            txtAddChamp.Clear()
        End If
    End Sub

    Private Sub txtAddChamp_Enter(sender As Object, e As EventArgs) Handles txtAddChamp.Enter
        Me.AcceptButton = btnAddChamp
    End Sub

    Private Sub txtAddChamp_Leave(sender As Object, e As EventArgs) Handles txtAddChamp.Leave
        Me.AcceptButton = btnOk
    End Sub

    Private Sub lblGetLatestVersion_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblGetLatestVersion.LinkClicked
        Process.Start(Properties.UrlExecutable)
    End Sub

    Private Sub lblBoLProfile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblBoLProfile.LinkClicked
        Process.Start(Properties.UrlBoLProfile)
    End Sub

    Private Sub lblSkype_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblSkype.LinkClicked
        Process.Start(Properties.UrlSkype)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblGithub.LinkClicked
        Process.Start(Properties.UrlGitHub)
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        SaveSettings(True, True)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        SaveSettings(False, True)
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        SaveSettings(True, False)
    End Sub

    Private Sub btnRestoreDefaults_Click(sender As Object, e As EventArgs) Handles btnRestoreDefaults.Click
        DefaultSettings()
    End Sub
#End Region
End Class