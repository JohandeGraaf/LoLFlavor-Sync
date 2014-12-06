<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFlavorSyncMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFlavorSyncMain))
        Me.btnDownloadBuilds = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkDownloadLane = New System.Windows.Forms.CheckBox()
        Me.chkDownloadJungle = New System.Windows.Forms.CheckBox()
        Me.chkDownloadSupport = New System.Windows.Forms.CheckBox()
        Me.chkDownloadARAM = New System.Windows.Forms.CheckBox()
        Me.clbChamps = New System.Windows.Forms.CheckedListBox()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnDeselectAll = New System.Windows.Forms.Button()
        Me.lblLastUsed = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.LoLFlavorSyncToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpBuildTypes = New System.Windows.Forms.GroupBox()
        Me.grpBuildsLastUpdated = New System.Windows.Forms.GroupBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStrip1.SuspendLayout()
        Me.grpBuildTypes.SuspendLayout()
        Me.grpBuildsLastUpdated.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDownloadBuilds
        '
        Me.btnDownloadBuilds.Location = New System.Drawing.Point(328, 91)
        Me.btnDownloadBuilds.Name = "btnDownloadBuilds"
        Me.btnDownloadBuilds.Size = New System.Drawing.Size(146, 41)
        Me.btnDownloadBuilds.TabIndex = 8
        Me.btnDownloadBuilds.Text = "Download builds"
        Me.btnDownloadBuilds.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(328, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Please select the champions for which you want to download builds."
        '
        'chkDownloadLane
        '
        Me.chkDownloadLane.AutoSize = True
        Me.chkDownloadLane.Checked = True
        Me.chkDownloadLane.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDownloadLane.Location = New System.Drawing.Point(15, 19)
        Me.chkDownloadLane.Name = "chkDownloadLane"
        Me.chkDownloadLane.Size = New System.Drawing.Size(81, 17)
        Me.chkDownloadLane.TabIndex = 11
        Me.chkDownloadLane.Text = "Lane Builds"
        Me.chkDownloadLane.UseVisualStyleBackColor = True
        '
        'chkDownloadJungle
        '
        Me.chkDownloadJungle.AutoSize = True
        Me.chkDownloadJungle.Checked = True
        Me.chkDownloadJungle.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDownloadJungle.Location = New System.Drawing.Point(15, 43)
        Me.chkDownloadJungle.Name = "chkDownloadJungle"
        Me.chkDownloadJungle.Size = New System.Drawing.Size(88, 17)
        Me.chkDownloadJungle.TabIndex = 12
        Me.chkDownloadJungle.Text = "Jungle Builds"
        Me.chkDownloadJungle.UseVisualStyleBackColor = True
        '
        'chkDownloadSupport
        '
        Me.chkDownloadSupport.AutoSize = True
        Me.chkDownloadSupport.Checked = True
        Me.chkDownloadSupport.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDownloadSupport.Location = New System.Drawing.Point(15, 67)
        Me.chkDownloadSupport.Name = "chkDownloadSupport"
        Me.chkDownloadSupport.Size = New System.Drawing.Size(94, 17)
        Me.chkDownloadSupport.TabIndex = 13
        Me.chkDownloadSupport.Text = "Support Builds"
        Me.chkDownloadSupport.UseVisualStyleBackColor = True
        '
        'chkDownloadARAM
        '
        Me.chkDownloadARAM.AutoSize = True
        Me.chkDownloadARAM.Checked = True
        Me.chkDownloadARAM.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDownloadARAM.Location = New System.Drawing.Point(15, 90)
        Me.chkDownloadARAM.Name = "chkDownloadARAM"
        Me.chkDownloadARAM.Size = New System.Drawing.Size(88, 17)
        Me.chkDownloadARAM.TabIndex = 14
        Me.chkDownloadARAM.Text = "ARAM Builds"
        Me.chkDownloadARAM.UseVisualStyleBackColor = True
        '
        'clbChamps
        '
        Me.clbChamps.FormattingEnabled = True
        Me.clbChamps.Location = New System.Drawing.Point(15, 91)
        Me.clbChamps.Name = "clbChamps"
        Me.clbChamps.Size = New System.Drawing.Size(307, 304)
        Me.clbChamps.TabIndex = 15
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(15, 62)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(96, 23)
        Me.btnSelectAll.TabIndex = 16
        Me.btnSelectAll.Text = "Select all"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnDeselectAll
        '
        Me.btnDeselectAll.Location = New System.Drawing.Point(117, 62)
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.Size = New System.Drawing.Size(96, 23)
        Me.btnDeselectAll.TabIndex = 17
        Me.btnDeselectAll.Text = "Deselect all"
        Me.btnDeselectAll.UseVisualStyleBackColor = True
        '
        'lblLastUsed
        '
        Me.lblLastUsed.AutoSize = True
        Me.lblLastUsed.Location = New System.Drawing.Point(12, 18)
        Me.lblLastUsed.Name = "lblLastUsed"
        Me.lblLastUsed.Size = New System.Drawing.Size(53, 13)
        Me.lblLastUsed.TabIndex = 22
        Me.lblLastUsed.Text = "Unknown"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoLFlavorSyncToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(483, 24)
        Me.MenuStrip1.TabIndex = 23
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'LoLFlavorSyncToolStripMenuItem
        '
        Me.LoLFlavorSyncToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DownloadToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.LoLFlavorSyncToolStripMenuItem.Name = "LoLFlavorSyncToolStripMenuItem"
        Me.LoLFlavorSyncToolStripMenuItem.Size = New System.Drawing.Size(98, 20)
        Me.LoLFlavorSyncToolStripMenuItem.Text = "LoLFlavor Sync"
        '
        'DownloadToolStripMenuItem
        '
        Me.DownloadToolStripMenuItem.Name = "DownloadToolStripMenuItem"
        Me.DownloadToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DownloadToolStripMenuItem.Text = "Download"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "Exit (Alt + F4)"
        '
        'grpBuildTypes
        '
        Me.grpBuildTypes.Controls.Add(Me.chkDownloadLane)
        Me.grpBuildTypes.Controls.Add(Me.chkDownloadJungle)
        Me.grpBuildTypes.Controls.Add(Me.chkDownloadSupport)
        Me.grpBuildTypes.Controls.Add(Me.chkDownloadARAM)
        Me.grpBuildTypes.Location = New System.Drawing.Point(328, 189)
        Me.grpBuildTypes.Name = "grpBuildTypes"
        Me.grpBuildTypes.Size = New System.Drawing.Size(146, 115)
        Me.grpBuildTypes.TabIndex = 24
        Me.grpBuildTypes.TabStop = False
        Me.grpBuildTypes.Text = "Builds"
        '
        'grpBuildsLastUpdated
        '
        Me.grpBuildsLastUpdated.Controls.Add(Me.lblLastUsed)
        Me.grpBuildsLastUpdated.Location = New System.Drawing.Point(328, 146)
        Me.grpBuildsLastUpdated.Name = "grpBuildsLastUpdated"
        Me.grpBuildsLastUpdated.Size = New System.Drawing.Size(146, 37)
        Me.grpBuildsLastUpdated.TabIndex = 25
        Me.grpBuildsLastUpdated.TabStop = False
        Me.grpBuildsLastUpdated.Text = "Last updated"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'frmFlavorSyncMain
        '
        Me.AcceptButton = Me.btnDownloadBuilds
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 403)
        Me.Controls.Add(Me.grpBuildsLastUpdated)
        Me.Controls.Add(Me.grpBuildTypes)
        Me.Controls.Add(Me.btnDeselectAll)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.clbChamps)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnDownloadBuilds)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmFlavorSyncMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LoLFlavor Sync"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpBuildTypes.ResumeLayout(False)
        Me.grpBuildTypes.PerformLayout()
        Me.grpBuildsLastUpdated.ResumeLayout(False)
        Me.grpBuildsLastUpdated.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDownloadBuilds As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkDownloadLane As System.Windows.Forms.CheckBox
    Friend WithEvents chkDownloadJungle As System.Windows.Forms.CheckBox
    Friend WithEvents chkDownloadSupport As System.Windows.Forms.CheckBox
    Friend WithEvents chkDownloadARAM As System.Windows.Forms.CheckBox
    Friend WithEvents clbChamps As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnDeselectAll As System.Windows.Forms.Button
    Friend WithEvents lblLastUsed As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents LoLFlavorSyncToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpBuildTypes As System.Windows.Forms.GroupBox
    Friend WithEvents grpBuildsLastUpdated As System.Windows.Forms.GroupBox
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
