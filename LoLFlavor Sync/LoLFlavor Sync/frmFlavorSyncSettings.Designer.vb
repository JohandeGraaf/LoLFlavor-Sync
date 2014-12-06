<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFlavorSyncSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFlavorSyncSettings))
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabGeneral = New System.Windows.Forms.TabPage()
        Me.grpAddChampions = New System.Windows.Forms.GroupBox()
        Me.btnAddChamp = New System.Windows.Forms.Button()
        Me.txtAddChamp = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grpGeneral = New System.Windows.Forms.GroupBox()
        Me.chkCheckNewVersion = New System.Windows.Forms.CheckBox()
        Me.chkHide = New System.Windows.Forms.CheckBox()
        Me.grpLoLPath = New System.Windows.Forms.GroupBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtLoLPath = New System.Windows.Forms.TextBox()
        Me.tabAdvanced = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFileFormat = New System.Windows.Forms.TextBox()
        Me.txtUrlFormat = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.clbSource = New System.Windows.Forms.CheckedListBox()
        Me.tabAbout = New System.Windows.Forms.TabPage()
        Me.txtChangelog = New System.Windows.Forms.TextBox()
        Me.lblGithub = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSkype = New System.Windows.Forms.LinkLabel()
        Me.lblBoLProfile = New System.Windows.Forms.LinkLabel()
        Me.lblGetLatestVersion = New System.Windows.Forms.LinkLabel()
        Me.txtAbout = New System.Windows.Forms.TextBox()
        Me.fbdLoLPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnRestoreDefaults = New System.Windows.Forms.Button()
        Me.lblChangelogInfo = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.tabGeneral.SuspendLayout()
        Me.grpAddChampions.SuspendLayout()
        Me.grpGeneral.SuspendLayout()
        Me.grpLoLPath.SuspendLayout()
        Me.tabAdvanced.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.tabAbout.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(215, 352)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Enabled = False
        Me.btnApply.Location = New System.Drawing.Point(377, 352)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 2
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabGeneral)
        Me.TabControl1.Controls.Add(Me.tabAdvanced)
        Me.TabControl1.Controls.Add(Me.tabAbout)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(440, 334)
        Me.TabControl1.TabIndex = 3
        '
        'tabGeneral
        '
        Me.tabGeneral.BackColor = System.Drawing.SystemColors.Control
        Me.tabGeneral.Controls.Add(Me.grpAddChampions)
        Me.tabGeneral.Controls.Add(Me.grpGeneral)
        Me.tabGeneral.Controls.Add(Me.grpLoLPath)
        Me.tabGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGeneral.Size = New System.Drawing.Size(432, 308)
        Me.tabGeneral.TabIndex = 0
        Me.tabGeneral.Text = "General"
        '
        'grpAddChampions
        '
        Me.grpAddChampions.Controls.Add(Me.btnAddChamp)
        Me.grpAddChampions.Controls.Add(Me.txtAddChamp)
        Me.grpAddChampions.Controls.Add(Me.Label4)
        Me.grpAddChampions.Location = New System.Drawing.Point(6, 141)
        Me.grpAddChampions.Name = "grpAddChampions"
        Me.grpAddChampions.Size = New System.Drawing.Size(419, 88)
        Me.grpAddChampions.TabIndex = 3
        Me.grpAddChampions.TabStop = False
        Me.grpAddChampions.Text = "Add champions"
        '
        'btnAddChamp
        '
        Me.btnAddChamp.Location = New System.Drawing.Point(164, 53)
        Me.btnAddChamp.Name = "btnAddChamp"
        Me.btnAddChamp.Size = New System.Drawing.Size(75, 20)
        Me.btnAddChamp.TabIndex = 2
        Me.btnAddChamp.Text = "Add"
        Me.btnAddChamp.UseVisualStyleBackColor = True
        '
        'txtAddChamp
        '
        Me.txtAddChamp.Location = New System.Drawing.Point(10, 53)
        Me.txtAddChamp.Name = "txtAddChamp"
        Me.txtAddChamp.Size = New System.Drawing.Size(147, 20)
        Me.txtAddChamp.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(386, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "This allows you to add champions that aren't implemented yet in LoLFlavor Sync."
        '
        'grpGeneral
        '
        Me.grpGeneral.Controls.Add(Me.chkCheckNewVersion)
        Me.grpGeneral.Controls.Add(Me.chkHide)
        Me.grpGeneral.Location = New System.Drawing.Point(6, 6)
        Me.grpGeneral.Name = "grpGeneral"
        Me.grpGeneral.Size = New System.Drawing.Size(419, 65)
        Me.grpGeneral.TabIndex = 2
        Me.grpGeneral.TabStop = False
        Me.grpGeneral.Text = "General"
        '
        'chkCheckNewVersion
        '
        Me.chkCheckNewVersion.AutoSize = True
        Me.chkCheckNewVersion.Location = New System.Drawing.Point(10, 42)
        Me.chkCheckNewVersion.Name = "chkCheckNewVersion"
        Me.chkCheckNewVersion.Size = New System.Drawing.Size(146, 17)
        Me.chkCheckNewVersion.TabIndex = 1
        Me.chkCheckNewVersion.Text = "Show update notification."
        Me.chkCheckNewVersion.UseVisualStyleBackColor = True
        '
        'chkHide
        '
        Me.chkHide.AutoSize = True
        Me.chkHide.Location = New System.Drawing.Point(10, 19)
        Me.chkHide.Name = "chkHide"
        Me.chkHide.Size = New System.Drawing.Size(136, 17)
        Me.chkHide.TabIndex = 0
        Me.chkHide.Text = "Show welcome screen."
        Me.chkHide.UseVisualStyleBackColor = True
        '
        'grpLoLPath
        '
        Me.grpLoLPath.Controls.Add(Me.btnBrowse)
        Me.grpLoLPath.Controls.Add(Me.txtLoLPath)
        Me.grpLoLPath.Location = New System.Drawing.Point(6, 77)
        Me.grpLoLPath.Name = "grpLoLPath"
        Me.grpLoLPath.Size = New System.Drawing.Size(419, 58)
        Me.grpLoLPath.TabIndex = 1
        Me.grpLoLPath.TabStop = False
        Me.grpLoLPath.Text = "League of Legends Path"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(326, 28)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(86, 20)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtLoLPath
        '
        Me.txtLoLPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtLoLPath.Location = New System.Drawing.Point(10, 28)
        Me.txtLoLPath.Name = "txtLoLPath"
        Me.txtLoLPath.ReadOnly = True
        Me.txtLoLPath.Size = New System.Drawing.Size(310, 20)
        Me.txtLoLPath.TabIndex = 0
        '
        'tabAdvanced
        '
        Me.tabAdvanced.BackColor = System.Drawing.SystemColors.Control
        Me.tabAdvanced.Controls.Add(Me.GroupBox3)
        Me.tabAdvanced.Location = New System.Drawing.Point(4, 22)
        Me.tabAdvanced.Name = "tabAdvanced"
        Me.tabAdvanced.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAdvanced.Size = New System.Drawing.Size(432, 308)
        Me.tabAdvanced.TabIndex = 3
        Me.tabAdvanced.Text = "Advanced"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnSave)
        Me.GroupBox3.Controls.Add(Me.btnDelete)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.txtFileFormat)
        Me.GroupBox3.Controls.Add(Me.txtUrlFormat)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.btnNew)
        Me.GroupBox3.Controls.Add(Me.clbSource)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(423, 296)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Source"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(153, 107)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(78, 251)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(69, 26)
        Me.btnDelete.TabIndex = 15
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Location = New System.Drawing.Point(153, 145)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(264, 100)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Variables"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(326, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Gets replaced with one of the following: lane, jungle, support, aram. "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(194, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Gets replaced with the champion name."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "{Champion}"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "{Lane}"
        '
        'txtFileFormat
        '
        Me.txtFileFormat.BackColor = System.Drawing.SystemColors.Window
        Me.txtFileFormat.Location = New System.Drawing.Point(153, 72)
        Me.txtFileFormat.Name = "txtFileFormat"
        Me.txtFileFormat.ReadOnly = True
        Me.txtFileFormat.Size = New System.Drawing.Size(260, 20)
        Me.txtFileFormat.TabIndex = 11
        '
        'txtUrlFormat
        '
        Me.txtUrlFormat.BackColor = System.Drawing.SystemColors.Window
        Me.txtUrlFormat.Location = New System.Drawing.Point(153, 33)
        Me.txtUrlFormat.Name = "txtUrlFormat"
        Me.txtUrlFormat.ReadOnly = True
        Me.txtUrlFormat.Size = New System.Drawing.Size(260, 20)
        Me.txtUrlFormat.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(150, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Filename format: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(150, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Download URL format: "
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(6, 251)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(69, 26)
        Me.btnNew.TabIndex = 6
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'clbSource
        '
        Me.clbSource.FormattingEnabled = True
        Me.clbSource.Location = New System.Drawing.Point(6, 16)
        Me.clbSource.Name = "clbSource"
        Me.clbSource.Size = New System.Drawing.Size(141, 229)
        Me.clbSource.TabIndex = 5
        '
        'tabAbout
        '
        Me.tabAbout.BackColor = System.Drawing.SystemColors.Control
        Me.tabAbout.Controls.Add(Me.lblChangelogInfo)
        Me.tabAbout.Controls.Add(Me.txtChangelog)
        Me.tabAbout.Controls.Add(Me.lblGithub)
        Me.tabAbout.Controls.Add(Me.Label1)
        Me.tabAbout.Controls.Add(Me.lblSkype)
        Me.tabAbout.Controls.Add(Me.lblBoLProfile)
        Me.tabAbout.Controls.Add(Me.lblGetLatestVersion)
        Me.tabAbout.Controls.Add(Me.txtAbout)
        Me.tabAbout.Location = New System.Drawing.Point(4, 22)
        Me.tabAbout.Name = "tabAbout"
        Me.tabAbout.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAbout.Size = New System.Drawing.Size(432, 308)
        Me.tabAbout.TabIndex = 2
        Me.tabAbout.Text = "About"
        '
        'txtChangelog
        '
        Me.txtChangelog.BackColor = System.Drawing.SystemColors.Control
        Me.txtChangelog.Location = New System.Drawing.Point(6, 35)
        Me.txtChangelog.Multiline = True
        Me.txtChangelog.Name = "txtChangelog"
        Me.txtChangelog.ReadOnly = True
        Me.txtChangelog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtChangelog.Size = New System.Drawing.Size(420, 212)
        Me.txtChangelog.TabIndex = 6
        Me.txtChangelog.Text = "Changelog"
        '
        'lblGithub
        '
        Me.lblGithub.AutoSize = True
        Me.lblGithub.Location = New System.Drawing.Point(258, 287)
        Me.lblGithub.Name = "lblGithub"
        Me.lblGithub.Size = New System.Drawing.Size(38, 13)
        Me.lblGithub.TabIndex = 5
        Me.lblGithub.TabStop = True
        Me.lblGithub.Text = "Github"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(294, 270)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Johan_degraaf95"
        '
        'lblSkype
        '
        Me.lblSkype.AutoSize = True
        Me.lblSkype.Location = New System.Drawing.Point(258, 270)
        Me.lblSkype.Name = "lblSkype"
        Me.lblSkype.Size = New System.Drawing.Size(40, 13)
        Me.lblSkype.TabIndex = 3
        Me.lblSkype.TabStop = True
        Me.lblSkype.Text = "Skype:"
        '
        'lblBoLProfile
        '
        Me.lblBoLProfile.AutoSize = True
        Me.lblBoLProfile.Location = New System.Drawing.Point(258, 253)
        Me.lblBoLProfile.Name = "lblBoLProfile"
        Me.lblBoLProfile.Size = New System.Drawing.Size(58, 13)
        Me.lblBoLProfile.TabIndex = 2
        Me.lblBoLProfile.TabStop = True
        Me.lblBoLProfile.Text = "BoL Profile"
        '
        'lblGetLatestVersion
        '
        Me.lblGetLatestVersion.AutoSize = True
        Me.lblGetLatestVersion.Location = New System.Drawing.Point(136, 12)
        Me.lblGetLatestVersion.Name = "lblGetLatestVersion"
        Me.lblGetLatestVersion.Size = New System.Drawing.Size(290, 13)
        Me.lblGetLatestVersion.TabIndex = 1
        Me.lblGetLatestVersion.TabStop = True
        Me.lblGetLatestVersion.Text = "Click here to download the latest version of LoLFlavor Sync."
        '
        'txtAbout
        '
        Me.txtAbout.BackColor = System.Drawing.SystemColors.Control
        Me.txtAbout.Location = New System.Drawing.Point(6, 253)
        Me.txtAbout.Multiline = True
        Me.txtAbout.Name = "txtAbout"
        Me.txtAbout.ReadOnly = True
        Me.txtAbout.Size = New System.Drawing.Size(246, 49)
        Me.txtAbout.TabIndex = 0
        Me.txtAbout.Text = "About"
        '
        'fbdLoLPath
        '
        Me.fbdLoLPath.Description = "Please select your League of Legends directory."
        Me.fbdLoLPath.ShowNewFolderButton = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(296, 352)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnRestoreDefaults
        '
        Me.btnRestoreDefaults.Location = New System.Drawing.Point(12, 352)
        Me.btnRestoreDefaults.Name = "btnRestoreDefaults"
        Me.btnRestoreDefaults.Size = New System.Drawing.Size(119, 23)
        Me.btnRestoreDefaults.TabIndex = 5
        Me.btnRestoreDefaults.Text = "Restore defaults"
        Me.btnRestoreDefaults.UseVisualStyleBackColor = True
        '
        'lblChangelogInfo
        '
        Me.lblChangelogInfo.AutoSize = True
        Me.lblChangelogInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChangelogInfo.Location = New System.Drawing.Point(6, 12)
        Me.lblChangelogInfo.Name = "lblChangelogInfo"
        Me.lblChangelogInfo.Size = New System.Drawing.Size(67, 13)
        Me.lblChangelogInfo.TabIndex = 7
        Me.lblChangelogInfo.Text = "Changelog"
        '
        'frmFlavorSyncSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 387)
        Me.Controls.Add(Me.btnRestoreDefaults)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmFlavorSyncSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "LoLFlavor Sync: Settings"
        Me.TabControl1.ResumeLayout(False)
        Me.tabGeneral.ResumeLayout(False)
        Me.grpAddChampions.ResumeLayout(False)
        Me.grpAddChampions.PerformLayout()
        Me.grpGeneral.ResumeLayout(False)
        Me.grpGeneral.PerformLayout()
        Me.grpLoLPath.ResumeLayout(False)
        Me.grpLoLPath.PerformLayout()
        Me.tabAdvanced.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.tabAbout.ResumeLayout(False)
        Me.tabAbout.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabGeneral As System.Windows.Forms.TabPage
    Friend WithEvents tabAbout As System.Windows.Forms.TabPage
    Friend WithEvents grpLoLPath As System.Windows.Forms.GroupBox
    Friend WithEvents txtLoLPath As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents fbdLoLPath As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents grpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents chkHide As System.Windows.Forms.CheckBox
    Friend WithEvents txtAbout As System.Windows.Forms.TextBox
    Friend WithEvents lblGetLatestVersion As System.Windows.Forms.LinkLabel
    Friend WithEvents lblSkype As System.Windows.Forms.LinkLabel
    Friend WithEvents lblBoLProfile As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblGithub As System.Windows.Forms.LinkLabel
    Friend WithEvents tabAdvanced As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents clbSource As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents txtFileFormat As System.Windows.Forms.TextBox
    Friend WithEvents txtUrlFormat As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpAddChampions As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddChamp As System.Windows.Forms.Button
    Friend WithEvents txtAddChamp As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtChangelog As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents chkCheckNewVersion As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnRestoreDefaults As System.Windows.Forms.Button
    Friend WithEvents lblChangelogInfo As System.Windows.Forms.Label
End Class
