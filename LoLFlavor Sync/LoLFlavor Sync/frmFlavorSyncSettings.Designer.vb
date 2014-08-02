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
        Me.btnAddChamp = New System.Windows.Forms.Button()
        Me.txtAddChamp = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
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
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSkype = New System.Windows.Forms.LinkLabel()
        Me.lblBoLProfile = New System.Windows.Forms.LinkLabel()
        Me.lblGetLatestVersion = New System.Windows.Forms.LinkLabel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.fbdLoLPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.TabControl1.SuspendLayout()
        Me.tabGeneral.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
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
        Me.GroupBox2.Controls.Add(Me.btnAddChamp)
        Me.GroupBox2.Controls.Add(Me.txtAddChamp)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(419, 88)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Add champions"
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
        Me.chkHide.Size = New System.Drawing.Size(144, 17)
        Me.chkHide.TabIndex = 0
        Me.chkHide.Text = "Hide welcome dialogbox."
        Me.chkHide.UseVisualStyleBackColor = True
        '
        'grpLoLPath
        '
        Me.grpLoLPath.Controls.Add(Me.btnBrowse)
        Me.grpLoLPath.Controls.Add(Me.txtLoLPath)
        Me.grpLoLPath.Location = New System.Drawing.Point(6, 54)
        Me.grpLoLPath.Name = "grpLoLPath"
        Me.grpLoLPath.Size = New System.Drawing.Size(419, 58)
        Me.grpLoLPath.TabIndex = 1
        Me.grpLoLPath.TabStop = False
        Me.grpLoLPath.Text = "League of Legends Path"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(322, 28)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(90, 20)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtLoLPath
        '
        Me.txtLoLPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtLoLPath.Location = New System.Drawing.Point(6, 28)
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
        Me.tabAbout.Controls.Add(Me.TextBox2)
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
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox2.Location = New System.Drawing.Point(6, 45)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(420, 202)
        Me.TextBox2.TabIndex = 6
        Me.TextBox2.Text = resources.GetString("TextBox2.Text")
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
        Me.lblGetLatestVersion.Location = New System.Drawing.Point(6, 16)
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
        Me.TextBox1.Text = "LoLFlavor Sync - Version 1.6" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Copyright © 2014 - Johan de Graaf"
        '
        'fbdLoLPath
        '
        Me.fbdLoLPath.Description = "Please select your League of Legends directory."
        Me.fbdLoLPath.ShowNewFolderButton = False
        '
        'frmFlavorSyncSettings
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(464, 387)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lblGetLatestVersion As System.Windows.Forms.LinkLabel
    Friend WithEvents lblSkype As System.Windows.Forms.LinkLabel
    Friend WithEvents lblBoLProfile As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents tabAdvanced As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents clbSource As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents txtFileFormat As System.Windows.Forms.TextBox
    Friend WithEvents txtUrlFormat As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddChamp As System.Windows.Forms.Button
    Friend WithEvents txtAddChamp As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
