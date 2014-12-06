Imports LoLFlavor_Sync.Library
Public Class frmFlavorSyncSettings

    Public Property RenewChampions As Boolean
    Public Property Quit As Boolean

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = "LoLFlavor Sync " & Properties.VersionLocal
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
        LoadBuitinSources()
    End Sub

    Private Sub SaveSettings(ByVal save As Boolean, ByVal close As Boolean)
        If Not save Then
            Me.Close()
        Else
            If clbSource.CheckedIndices.Count <= 0 Then
                MessageBox.Show("Select at least one source.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            ElseIf clbSource.CheckedIndices.Count >= 2 Then
                MessageBox.Show("Please select only one source.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

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

    Public srcArray(0) As Sources
    Public Structure Sources
        Public Name As String
        Public SourceUrlFormat As String
        Public DestinationPathFormat As String
    End Structure
    Private Sub LoadBuitinSources()
        Dim src As New Sources
        src.Name = "LoLFlavor.com"
        src.SourceUrlFormat = "http://www.lolflavor.com/champions/{Champion}/Recommended/{Champion}_{Lane}_scrape.json"
        src.DestinationPathFormat = "{Champion}_{Lane}_scrape.json"
        srcArray(0) = src
        LoadClb()
    End Sub

    Private Sub LoadClb()
        clbSource.Items.Clear()
        For Each obj In srcArray
            clbSource.Items.Add(obj.Name)
        Next
        clbSource.SetItemChecked(0, True)
        clbSource.SelectedIndex = 0
    End Sub

    Private Sub AddSources(ByVal Name As String, ByVal SourceUrlFormat As String, ByVal DestinationPathFormat As String)
        Dim src As New Sources
        src.Name = Name
        src.SourceUrlFormat = SourceUrlFormat
        src.DestinationPathFormat = DestinationPathFormat
        ReDim Preserve srcArray(srcArray.Length)
        srcArray(srcArray.Length - 1) = src
        LoadClb()
    End Sub

    Private Sub DeleteSources(ByVal Index As Integer)
        If Not Index = srcArray.Length - 1 Then moveItemToEndOfArray(srcArray, Index)
        ReDim Preserve srcArray(srcArray.Length - 2)
        LoadClb()
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

    Private Sub clbSource_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clbSource.SelectedIndexChanged
        If clbSource.SelectedIndex <= 0 Then
            btnSave.Visible = False
            btnSave.Enabled = False
            btnDelete.Enabled = False
        Else
            btnSave.Visible = True
            btnSave.Enabled = False
            btnDelete.Enabled = True
        End If
        txtUrlFormat.Text = srcArray(clbSource.SelectedIndex).SourceUrlFormat
        txtFileFormat.Text = srcArray(clbSource.SelectedIndex).DestinationPathFormat
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim Name As String = InputBox("Name: ")
        Dim SourceUrlFormat As String = InputBox("Download URL format: ")
        Dim DestinationPathFormat As String = InputBox("Filename format: ")
        AddSources(Name, SourceUrlFormat, DestinationPathFormat)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim Index As Integer = clbSource.SelectedIndex
        DeleteSources(Index)
        clbSource.SelectedIndex = Index - 1
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        btnSave.Enabled = False
    End Sub

    Private Sub txtClick(sender As Object, e As EventArgs) Handles txtUrlFormat.Click, txtFileFormat.Click
        btnSave.Enabled = True
    End Sub

    Private Sub clbSource_Click(sender As Object, e As EventArgs) Handles clbSource.Click
        btnApply.Enabled = True
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            'Advanced tab
            Me.Width = 620
            Me.TabControl1.Width = 576
            Me.tabAdvanced.Width = 568
            Me.GroupBox3.Width = 559
            Me.GroupBox4.Width = 400
            Me.txtUrlFormat.Width = 392
            Me.txtFileFormat.Width = 392
            Me.btnOk.Location = New System.Drawing.Point(351, 352)
            Me.btnCancel.Location = New System.Drawing.Point(432, 352)
            Me.btnApply.Location = New System.Drawing.Point(513, 352)
        Else
            'General or about tab
            Me.Width = 484
            Me.TabControl1.Width = 440
            Me.tabAdvanced.Width = 432
            Me.GroupBox3.Width = 423
            Me.GroupBox4.Width = 264
            Me.txtUrlFormat.Width = 260
            Me.txtFileFormat.Width = 260
            Me.btnOk.Location = New System.Drawing.Point(215, 352)
            Me.btnCancel.Location = New System.Drawing.Point(296, 352)
            Me.btnApply.Location = New System.Drawing.Point(377, 352)
            'About tab
            If TabControl1.SelectedIndex = 2 Then
                txtChangelog.Select(txtChangelog.TextLength, 0)
                txtChangelog.ScrollToCaret()
            End If
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