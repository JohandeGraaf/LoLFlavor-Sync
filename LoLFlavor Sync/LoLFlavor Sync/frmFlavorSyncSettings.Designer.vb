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
        Me.tabAbout = New System.Windows.Forms.TabPage()
        Me.lblChangelogInfo = New System.Windows.Forms.Label()
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
        Me.TabControl1.SuspendLayout()
        Me.tabGeneral.SuspendLayout()
        Me.grpAddChampions.SuspendLayout()
        Me.grpGeneral.SuspendLayout()
        Me.grpLoLPath.SuspendLayout()
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
        'txtChangelog
        '
        Me.txtChangelog.BackColor = System.Drawing.SystemColors.Control
        Me.txtChangelog.Location = New System.Drawing.Point(6, 35)
        Me.txtChangelog.Multiline = True
        Me.txtChangelog.Name = "txtChangelog"
        Me.txtChangelog.ReadOnly = True
        Me.txtChangelog.ScrollBars = System.Windows.Forms.ScrollBars.Both
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
        Me.ShowInTaskbar = False
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
    Friend WithEvents grpAddChampions As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddChamp As System.Windows.Forms.Button
    Friend WithEvents txtAddChamp As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtChangelog As System.Windows.Forms.TextBox
    Friend WithEvents chkCheckNewVersion As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnRestoreDefaults As System.Windows.Forms.Button
    Friend WithEvents lblChangelogInfo As System.Windows.Forms.Label
End Class
