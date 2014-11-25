Public Class frmFlavorSyncSettings

    Public srcArray(0) As Sources

    Public Structure Sources
        Public Name As String
        Public SourceUrlFormat As String
        Public DestinationPathFormat As String
    End Structure

    Public WriteOnly Property SaveLoLPath As String
        Set(value As String)
            frmFlavorSyncLoad.getLoLPath = value
        End Set
    End Property

    Private Sub AddSources(ByVal Name As String, ByVal SourceUrlFormat As String, ByVal DestinationPathFormat As String)
        Dim src As New Sources
        src.Name = Name
        src.SourceUrlFormat = SourceUrlFormat
        src.DestinationPathFormat = DestinationPathFormat
        ReDim Preserve srcArray(srcArray.Length)
        srcArray(srcArray.Length - 1) = src
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

    Private Sub DeleteSources(ByVal Index As Integer)
        If Not Index = srcArray.Length - 1 Then moveItemToEndOfArray(srcArray, Index)
        ReDim Preserve srcArray(srcArray.Length - 2)
        LoadClb()
    End Sub

    Private Sub LoadBuitinSources()
        Dim src As New Sources
        src.Name = "LoLFlavor.com"
        src.SourceUrlFormat = "http://www.lolflavor.com/champions/{Champion}/Recommended/{Champion}_{Lane}_scrape.json"
        src.DestinationPathFormat = "{Champion}_{Lane}_scrape.json"
        srcArray(0) = src
    End Sub

    Private Sub LoadClb()
        clbSource.Items.Clear()
        For Each obj In srcArray
            clbSource.Items.Add(obj.Name)
        Next
        clbSource.SetItemChecked(0, True)
        clbSource.SelectedIndex = 0
    End Sub

    Private Sub LoadSettings()
        LoadBuitinSources()
        LoadClb()
        txtLoLPath.Text = frmFlavorSyncLoad.getLoLPath
        chkHide.Checked = frmFlavorSyncLoad.skipForm
    End Sub

    Private Sub SaveSettings(ByVal btn As String)
        If btn = "Cancel" Then
            Me.Close()
            Exit Sub
        End If
        Dim CheckedCount As Integer = 0
        For i = 0 To clbSource.Items.Count - 1
            If clbSource.GetItemChecked(i) Then
                CheckedCount = CheckedCount + 1
            End If
        Next
        If CheckedCount = 0 Then
            MessageBox.Show("Please select at least one source.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf CheckedCount > 1 Then
            MessageBox.Show("Please select only one source.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        SaveLoLPath = txtLoLPath.Text
        frmFlavorSyncLoad.skipForm = chkHide.Checked
        If btn = "OK" Then
            Me.Close()
        ElseIf btn = "Apply" Then
            btnApply.Enabled = False
        End If
    End Sub

#Region "Event Handlers"
    Private Sub frmFlavorSyncSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "LoLFlavor Sync " & frmFlavorSyncMain.localVersion
        LoadSettings()
        txtChangelog.Text = _
            "Changelog" & _
            Environment.NewLine & _
            "1.0 - Release." & Environment.NewLine & _
            "1.1 - Fixed some bugs." & Environment.NewLine & _
            "1.2 - Added some settings." & Environment.NewLine & _
            Environment.NewLine & _
            "1.5 - Changed the download method to improve performance." & Environment.NewLine & _
            "1.6 - Added settings to add champions and add a custom source for builds." & Environment.NewLine & _
            "1.6.1 - Added Azir and Gnar." & Environment.NewLine & _
            "1.6.2 - Added update message." & Environment.NewLine & _
            "1.6.3 - Added Kalista" & Environment.NewLine & _
            "1.6.4 - Added Rek'Sai"
        txtAbout.Text = _
        "LoLFlavor Sync - Version " & frmFlavorSyncMain.localVersion & Environment.NewLine & _
        Environment.NewLine & _
        "Copyright © 2014 - Johan de Graaf"
    End Sub

    Private Sub clbSource_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clbSource.SelectedIndexChanged
        If clbSource.SelectedIndex = -1 Or clbSource.SelectedIndex = 0 Then
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
        End If
        If TabControl1.SelectedIndex = 2 Then
            txtChangelog.Select(txtChangelog.TextLength, 0)
            txtChangelog.ScrollToCaret()
        End If
    End Sub

    Private Sub chkHide_Click(sender As Object, e As EventArgs) Handles chkHide.Click
        btnApply.Enabled = True
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        fbdLoLPath.SelectedPath = txtLoLPath.Text
        If fbdLoLPath.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Exit Sub
        If frmFlavorSyncLoad.checkLoLPath(fbdLoLPath.SelectedPath) Then
            txtLoLPath.Text = fbdLoLPath.SelectedPath
            btnApply.Enabled = True
        Else
            MessageBox.Show("Incorrect directory specified. Please make sure you are selecting your League of Legends directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnAddChamp_Click(sender As Object, e As EventArgs) Handles btnAddChamp.Click
        If String.IsNullOrWhiteSpace(txtAddChamp.Text) Then
            MessageBox.Show("Please enter a valid champion name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            For Each champ In frmFlavorSyncLoad.champs
                If txtAddChamp.Text = champ Then
                    MessageBox.Show("Champion already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next
            ReDim Preserve frmFlavorSyncLoad.champs(frmFlavorSyncLoad.champs.Length)
            frmFlavorSyncLoad.champs(frmFlavorSyncLoad.champs.Length - 1) = txtAddChamp.Text
            frmFlavorSyncMain.initializeClbChamps()
            MessageBox.Show("Champion added!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtAddChamp.Clear()
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

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblGithub.LinkClicked
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