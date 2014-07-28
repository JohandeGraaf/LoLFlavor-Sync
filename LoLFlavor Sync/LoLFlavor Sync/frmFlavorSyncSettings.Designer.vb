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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabGeneral = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkLoLFlavor = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkHide = New System.Windows.Forms.CheckBox()
        Me.grpLoLPath = New System.Windows.Forms.GroupBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtLoLPath = New System.Windows.Forms.TextBox()
        Me.tabAbout = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSkype = New System.Windows.Forms.LinkLabel()
        Me.lblBoLProfile = New System.Windows.Forms.LinkLabel()
        Me.lblGetLatestVersion = New System.Windows.Forms.LinkLabel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.fbdLoLPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.TabControl1.SuspendLayout()
        Me.tabGeneral.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(296, 352)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
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
        Me.tabGeneral.Controls.Add(Me.GroupBox2)
        Me.tabGeneral.Controls.Add(Me.GroupBox1)
        Me.tabGeneral.Controls.Add(Me.grpLoLPath)
        Me.tabGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGeneral.Size = New System.Drawing.Size(432, 308)
        Me.tabGeneral.TabIndex = 0
        Me.tabGeneral.Text = "General"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkLoLFlavor)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 55)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(419, 44)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Source"
        '
        'chkLoLFlavor
        '
        Me.chkLoLFlavor.AutoSize = True
        Me.chkLoLFlavor.Location = New System.Drawing.Point(6, 19)
        Me.chkLoLFlavor.Name = "chkLoLFlavor"
        Me.chkLoLFlavor.Size = New System.Drawing.Size(96, 17)
        Me.chkLoLFlavor.TabIndex = 0
        Me.chkLoLFlavor.Text = "LoLFlavor.com"
        Me.chkLoLFlavor.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkHide)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(419, 42)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "General"
        '
        'chkHide
        '
        Me.chkHide.AutoSize = True
        Me.chkHide.Location = New System.Drawing.Point(6, 19)
        Me.chkHide.Name = "chkHide"
        Me.chkHide.Size = New System.Drawing.Size(118, 17)
        Me.chkHide.TabIndex = 0
        Me.chkHide.Text = "Hide first dialogbox."
        Me.chkHide.UseVisualStyleBackColor = True
        '
        'grpLoLPath
        '
        Me.grpLoLPath.Controls.Add(Me.btnBrowse)
        Me.grpLoLPath.Controls.Add(Me.txtLoLPath)
        Me.grpLoLPath.Location = New System.Drawing.Point(6, 105)
        Me.grpLoLPath.Name = "grpLoLPath"
        Me.grpLoLPath.Size = New System.Drawing.Size(419, 69)
        Me.grpLoLPath.TabIndex = 1
        Me.grpLoLPath.TabStop = False
        Me.grpLoLPath.Text = "League of Legends Path"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(323, 33)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(90, 20)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtLoLPath
        '
        Me.txtLoLPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtLoLPath.Location = New System.Drawing.Point(6, 33)
        Me.txtLoLPath.Name = "txtLoLPath"
        Me.txtLoLPath.ReadOnly = True
        Me.txtLoLPath.Size = New System.Drawing.Size(310, 20)
        Me.txtLoLPath.TabIndex = 0
        '
        'tabAbout
        '
        Me.tabAbout.BackColor = System.Drawing.SystemColors.Control
        Me.tabAbout.Controls.Add(Me.LinkLabel1)
        Me.tabAbout.Controls.Add(Me.Label1)
        Me.tabAbout.Controls.Add(Me.lblSkype)
        Me.tabAbout.Controls.Add(Me.lblBoLProfile)
        Me.tabAbout.Controls.Add(Me.lblGetLatestVersion)
        Me.tabAbout.Controls.Add(Me.TextBox1)
        Me.tabAbout.Location = New System.Drawing.Point(4, 22)
        Me.tabAbout.Name = "tabAbout"
        Me.tabAbout.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAbout.Size = New System.Drawing.Size(432, 308)
        Me.tabAbout.TabIndex = 2
        Me.tabAbout.Text = "About"
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
        Me.lblGetLatestVersion.Location = New System.Drawing.Point(6, 92)
        Me.lblGetLatestVersion.Name = "lblGetLatestVersion"
        Me.lblGetLatestVersion.Size = New System.Drawing.Size(290, 13)
        Me.lblGetLatestVersion.TabIndex = 1
        Me.lblGetLatestVersion.TabStop = True
        Me.lblGetLatestVersion.Text = "Click here to download the latest version of LoLFlavor Sync."
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.Location = New System.Drawing.Point(6, 253)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(246, 49)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "LoLFlavor Sync - Version 1.5" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Copyright © 2014 - Johan de Graaf"
        '
        'fbdLoLPath
        '
        Me.fbdLoLPath.Description = "Please select your League of Legends directory."
        Me.fbdLoLPath.ShowNewFolderButton = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(258, 287)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(38, 13)
        Me.LinkLabel1.TabIndex = 5
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Github"
        '
        'frmFlavorSyncSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 387)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFlavorSyncSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LoLFlavor Sync: Settings"
        Me.TabControl1.ResumeLayout(False)
        Me.tabGeneral.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpLoLPath.ResumeLayout(False)
        Me.grpLoLPath.PerformLayout()
        Me.tabAbout.ResumeLayout(False)
        Me.tabAbout.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabGeneral As System.Windows.Forms.TabPage
    Friend WithEvents tabAbout As System.Windows.Forms.TabPage
    Friend WithEvents grpLoLPath As System.Windows.Forms.GroupBox
    Friend WithEvents txtLoLPath As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents fbdLoLPath As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkHide As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lblGetLatestVersion As System.Windows.Forms.LinkLabel
    Friend WithEvents lblSkype As System.Windows.Forms.LinkLabel
    Friend WithEvents lblBoLProfile As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkLoLFlavor As System.Windows.Forms.CheckBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
End Class
