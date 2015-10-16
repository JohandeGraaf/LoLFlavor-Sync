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
        Me.lblSkype = New System.Windows.Forms.LinkLabel()
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
        Me.btnOk.Location = New System.Drawing.Point(287, 433)
        Me.btnOk.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(100, 28)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Enabled = False
        Me.btnApply.Location = New System.Drawing.Point(503, 433)
        Me.btnApply.Margin = New System.Windows.Forms.Padding(4)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(100, 28)
        Me.btnApply.TabIndex = 2
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabGeneral)
        Me.TabControl1.Controls.Add(Me.tabAbout)
        Me.TabControl1.Location = New System.Drawing.Point(16, 15)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(587, 411)
        Me.TabControl1.TabIndex = 3
        '
        'tabGeneral
        '
        Me.tabGeneral.BackColor = System.Drawing.SystemColors.Control
        Me.tabGeneral.Controls.Add(Me.grpAddChampions)
        Me.tabGeneral.Controls.Add(Me.grpGeneral)
        Me.tabGeneral.Controls.Add(Me.grpLoLPath)
        Me.tabGeneral.Location = New System.Drawing.Point(4, 25)
        Me.tabGeneral.Margin = New System.Windows.Forms.Padding(4)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Padding = New System.Windows.Forms.Padding(4)
        Me.tabGeneral.Size = New System.Drawing.Size(579, 382)
        Me.tabGeneral.TabIndex = 0
        Me.tabGeneral.Text = "General"
        '
        'grpAddChampions
        '
        Me.grpAddChampions.Controls.Add(Me.btnAddChamp)
        Me.grpAddChampions.Controls.Add(Me.txtAddChamp)
        Me.grpAddChampions.Location = New System.Drawing.Point(8, 174)
        Me.grpAddChampions.Margin = New System.Windows.Forms.Padding(4)
        Me.grpAddChampions.Name = "grpAddChampions"
        Me.grpAddChampions.Padding = New System.Windows.Forms.Padding(4)
        Me.grpAddChampions.Size = New System.Drawing.Size(559, 76)
        Me.grpAddChampions.TabIndex = 3
        Me.grpAddChampions.TabStop = False
        Me.grpAddChampions.Text = "Add champions that aren't implemented yet in LoLFlavor Sync"
        '
        'btnAddChamp
        '
        Me.btnAddChamp.Location = New System.Drawing.Point(214, 35)
        Me.btnAddChamp.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddChamp.Name = "btnAddChamp"
        Me.btnAddChamp.Size = New System.Drawing.Size(100, 25)
        Me.btnAddChamp.TabIndex = 2
        Me.btnAddChamp.Text = "Add"
        Me.btnAddChamp.UseVisualStyleBackColor = True
        '
        'txtAddChamp
        '
        Me.txtAddChamp.Location = New System.Drawing.Point(8, 35)
        Me.txtAddChamp.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAddChamp.Name = "txtAddChamp"
        Me.txtAddChamp.Size = New System.Drawing.Size(195, 22)
        Me.txtAddChamp.TabIndex = 1
        '
        'grpGeneral
        '
        Me.grpGeneral.Controls.Add(Me.chkCheckNewVersion)
        Me.grpGeneral.Controls.Add(Me.chkHide)
        Me.grpGeneral.Location = New System.Drawing.Point(8, 7)
        Me.grpGeneral.Margin = New System.Windows.Forms.Padding(4)
        Me.grpGeneral.Name = "grpGeneral"
        Me.grpGeneral.Padding = New System.Windows.Forms.Padding(4)
        Me.grpGeneral.Size = New System.Drawing.Size(559, 80)
        Me.grpGeneral.TabIndex = 2
        Me.grpGeneral.TabStop = False
        Me.grpGeneral.Text = "General"
        '
        'chkCheckNewVersion
        '
        Me.chkCheckNewVersion.AutoSize = True
        Me.chkCheckNewVersion.Location = New System.Drawing.Point(13, 52)
        Me.chkCheckNewVersion.Margin = New System.Windows.Forms.Padding(4)
        Me.chkCheckNewVersion.Name = "chkCheckNewVersion"
        Me.chkCheckNewVersion.Size = New System.Drawing.Size(195, 21)
        Me.chkCheckNewVersion.TabIndex = 1
        Me.chkCheckNewVersion.Text = "Show update notifications."
        Me.chkCheckNewVersion.UseVisualStyleBackColor = True
        '
        'chkHide
        '
        Me.chkHide.AutoSize = True
        Me.chkHide.Location = New System.Drawing.Point(13, 23)
        Me.chkHide.Margin = New System.Windows.Forms.Padding(4)
        Me.chkHide.Name = "chkHide"
        Me.chkHide.Size = New System.Drawing.Size(173, 21)
        Me.chkHide.TabIndex = 0
        Me.chkHide.Text = "Show welcome screen."
        Me.chkHide.UseVisualStyleBackColor = True
        '
        'grpLoLPath
        '
        Me.grpLoLPath.Controls.Add(Me.btnBrowse)
        Me.grpLoLPath.Controls.Add(Me.txtLoLPath)
        Me.grpLoLPath.Location = New System.Drawing.Point(8, 95)
        Me.grpLoLPath.Margin = New System.Windows.Forms.Padding(4)
        Me.grpLoLPath.Name = "grpLoLPath"
        Me.grpLoLPath.Padding = New System.Windows.Forms.Padding(4)
        Me.grpLoLPath.Size = New System.Drawing.Size(559, 71)
        Me.grpLoLPath.TabIndex = 1
        Me.grpLoLPath.TabStop = False
        Me.grpLoLPath.Text = "League of Legends Path"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(435, 34)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(115, 25)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtLoLPath
        '
        Me.txtLoLPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtLoLPath.Location = New System.Drawing.Point(13, 34)
        Me.txtLoLPath.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLoLPath.Name = "txtLoLPath"
        Me.txtLoLPath.ReadOnly = True
        Me.txtLoLPath.Size = New System.Drawing.Size(412, 22)
        Me.txtLoLPath.TabIndex = 0
        '
        'tabAbout
        '
        Me.tabAbout.BackColor = System.Drawing.SystemColors.Control
        Me.tabAbout.Controls.Add(Me.lblChangelogInfo)
        Me.tabAbout.Controls.Add(Me.txtChangelog)
        Me.tabAbout.Controls.Add(Me.lblGithub)
        Me.tabAbout.Controls.Add(Me.lblSkype)
        Me.tabAbout.Controls.Add(Me.lblGetLatestVersion)
        Me.tabAbout.Controls.Add(Me.txtAbout)
        Me.tabAbout.Location = New System.Drawing.Point(4, 25)
        Me.tabAbout.Margin = New System.Windows.Forms.Padding(4)
        Me.tabAbout.Name = "tabAbout"
        Me.tabAbout.Padding = New System.Windows.Forms.Padding(4)
        Me.tabAbout.Size = New System.Drawing.Size(579, 382)
        Me.tabAbout.TabIndex = 2
        Me.tabAbout.Text = "About"
        '
        'lblChangelogInfo
        '
        Me.lblChangelogInfo.AutoSize = True
        Me.lblChangelogInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChangelogInfo.Location = New System.Drawing.Point(8, 15)
        Me.lblChangelogInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblChangelogInfo.Name = "lblChangelogInfo"
        Me.lblChangelogInfo.Size = New System.Drawing.Size(85, 17)
        Me.lblChangelogInfo.TabIndex = 7
        Me.lblChangelogInfo.Text = "Changelog"
        '
        'txtChangelog
        '
        Me.txtChangelog.BackColor = System.Drawing.SystemColors.Control
        Me.txtChangelog.Location = New System.Drawing.Point(8, 43)
        Me.txtChangelog.Margin = New System.Windows.Forms.Padding(4)
        Me.txtChangelog.Multiline = True
        Me.txtChangelog.Name = "txtChangelog"
        Me.txtChangelog.ReadOnly = True
        Me.txtChangelog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtChangelog.Size = New System.Drawing.Size(559, 260)
        Me.txtChangelog.TabIndex = 6
        Me.txtChangelog.Text = "Changelog"
        '
        'lblGithub
        '
        Me.lblGithub.AutoSize = True
        Me.lblGithub.Location = New System.Drawing.Point(515, 314)
        Me.lblGithub.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGithub.Name = "lblGithub"
        Me.lblGithub.Size = New System.Drawing.Size(50, 17)
        Me.lblGithub.TabIndex = 5
        Me.lblGithub.TabStop = True
        Me.lblGithub.Text = "Github"
        '
        'lblSkype
        '
        Me.lblSkype.AutoSize = True
        Me.lblSkype.Location = New System.Drawing.Point(515, 341)
        Me.lblSkype.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSkype.Name = "lblSkype"
        Me.lblSkype.Size = New System.Drawing.Size(47, 17)
        Me.lblSkype.TabIndex = 3
        Me.lblSkype.TabStop = True
        Me.lblSkype.Text = "Skype"
        '
        'lblGetLatestVersion
        '
        Me.lblGetLatestVersion.AutoSize = True
        Me.lblGetLatestVersion.Location = New System.Drawing.Point(181, 15)
        Me.lblGetLatestVersion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGetLatestVersion.Name = "lblGetLatestVersion"
        Me.lblGetLatestVersion.Size = New System.Drawing.Size(385, 17)
        Me.lblGetLatestVersion.TabIndex = 1
        Me.lblGetLatestVersion.TabStop = True
        Me.lblGetLatestVersion.Text = "Click here to download the latest release of LoLFlavor Sync."
        '
        'txtAbout
        '
        Me.txtAbout.BackColor = System.Drawing.SystemColors.Control
        Me.txtAbout.Location = New System.Drawing.Point(8, 311)
        Me.txtAbout.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAbout.Multiline = True
        Me.txtAbout.Name = "txtAbout"
        Me.txtAbout.ReadOnly = True
        Me.txtAbout.Size = New System.Drawing.Size(499, 59)
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
        Me.btnCancel.Location = New System.Drawing.Point(395, 433)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnRestoreDefaults
        '
        Me.btnRestoreDefaults.Location = New System.Drawing.Point(16, 433)
        Me.btnRestoreDefaults.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRestoreDefaults.Name = "btnRestoreDefaults"
        Me.btnRestoreDefaults.Size = New System.Drawing.Size(159, 28)
        Me.btnRestoreDefaults.TabIndex = 5
        Me.btnRestoreDefaults.Text = "Restore defaults"
        Me.btnRestoreDefaults.UseVisualStyleBackColor = True
        '
        'frmFlavorSyncSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 476)
        Me.Controls.Add(Me.btnRestoreDefaults)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
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
    Friend WithEvents lblGithub As System.Windows.Forms.LinkLabel
    Friend WithEvents grpAddChampions As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddChamp As System.Windows.Forms.Button
    Friend WithEvents txtAddChamp As System.Windows.Forms.TextBox
    Friend WithEvents txtChangelog As System.Windows.Forms.TextBox
    Friend WithEvents chkCheckNewVersion As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnRestoreDefaults As System.Windows.Forms.Button
    Friend WithEvents lblChangelogInfo As System.Windows.Forms.Label
End Class
