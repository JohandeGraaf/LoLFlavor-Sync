Imports LoLFlavor_Sync.Domain
Public Class frmFlavorSyncSettings

    Public Property RenewChampions As Boolean
    Public Property Quit As Boolean

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If GlobalVars.Garena Then
            Me.Text = "LoLFlavor Sync " & GlobalVars.VersionLocal & " (Garena)"
        Else
            Me.Text = "LoLFlavor Sync " & GlobalVars.VersionLocal
        End If
        Me.AcceptButton = btnOk
        Me.CancelButton = btnCancel
        Me.txtLoLPath.Text = GlobalVars.LoLPath.Path
        Me.chkHide.Checked = Not GlobalVars.OptionSkipForm
        Me.chkCheckNewVersion.Checked = Not GlobalVars.OptionVersionCheckDisabled
        Me.txtChangelog.Text = GlobalVars.Changelog
        Me.txtAbout.Text = GlobalVars.About
        Me.btnApply.Enabled = False
    End Sub

    Private Sub LoadSettings()

    End Sub

    Private Sub SaveSettings(ByVal save As Boolean, ByVal close As Boolean)
        If Not save Then
            Me.Close()
        Else
            GlobalVars.OptionSkipForm = Not chkHide.Checked
            GlobalVars.OptionVersionCheckDisabled = Not chkCheckNewVersion.Checked

            If GlobalVars.OptionSkipForm Then
                GlobalVars.OptionLoLPath = GlobalVars.LoLPath.Path
            Else
                GlobalVars.OptionLoLPath = ""
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
            GlobalVars.DeleteRegistryKeys()
            If System.IO.File.Exists(Environment.GetCommandLineArgs(0)) Then
                Process.Start(Environment.GetCommandLineArgs(0))
            End If
            Quit = True
            Me.Close()
        End If
    End Sub

    Private Sub ChangeLoLPath()
        fbdLoLPath.SelectedPath = GlobalVars.LoLPath.Path

        If fbdLoLPath.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        Dim lolPath = New LoLPath(fbdLoLPath.SelectedPath)

        If lolPath.IsValid() Then
            GlobalVars.LoLPath = lolPath
            txtLoLPath.Text = lolPath.Path
        Else
            MessageBox.Show("Incorrect directory specified. Please make sure you are selecting your League of Legends directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If GlobalVars.Garena Then
            GlobalVars.DetectGarenaPath()
        End If
    End Sub

    Private Sub AddChampion(ByVal Name As String, Optional ByVal DisplayName As String = Nothing)
        For Each obj As Champion In GlobalVars.AllChampions
            If obj.Name.ToLower() = Name.ToLower() Then
                MessageBox.Show("Champion already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Next
        If String.IsNullOrWhiteSpace(DisplayName) Then
            GlobalVars.AllChampions.Add(New Champion(Name))
        Else
            GlobalVars.AllChampions.Add(New Champion(Name, DisplayName))
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
        Process.Start(GlobalVars.UrlExecutable)
    End Sub

    Private Sub lblBoLProfile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Process.Start(GlobalVars.UrlBoLProfile)
    End Sub

    Private Sub lblSkype_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblSkype.LinkClicked
        Process.Start(GlobalVars.UrlSkype)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblGithub.LinkClicked
        Process.Start(GlobalVars.UrlGitHub)
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