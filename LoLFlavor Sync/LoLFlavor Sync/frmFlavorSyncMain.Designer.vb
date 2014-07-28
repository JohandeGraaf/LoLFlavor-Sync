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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblLastUsed = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnDownloadBuilds
        '
        Me.btnDownloadBuilds.Location = New System.Drawing.Point(328, 105)
        Me.btnDownloadBuilds.Name = "btnDownloadBuilds"
        Me.btnDownloadBuilds.Size = New System.Drawing.Size(146, 41)
        Me.btnDownloadBuilds.TabIndex = 8
        Me.btnDownloadBuilds.Text = "Download builds"
        Me.btnDownloadBuilds.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
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
        Me.chkDownloadLane.Location = New System.Drawing.Point(354, 268)
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
        Me.chkDownloadJungle.Location = New System.Drawing.Point(354, 292)
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
        Me.chkDownloadSupport.Location = New System.Drawing.Point(354, 316)
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
        Me.chkDownloadARAM.Location = New System.Drawing.Point(354, 339)
        Me.chkDownloadARAM.Name = "chkDownloadARAM"
        Me.chkDownloadARAM.Size = New System.Drawing.Size(88, 17)
        Me.chkDownloadARAM.TabIndex = 14
        Me.chkDownloadARAM.Text = "ARAM Builds"
        Me.chkDownloadARAM.UseVisualStyleBackColor = True
        '
        'clbChamps
        '
        Me.clbChamps.FormattingEnabled = True
        Me.clbChamps.Location = New System.Drawing.Point(15, 105)
        Me.clbChamps.Name = "clbChamps"
        Me.clbChamps.Size = New System.Drawing.Size(307, 304)
        Me.clbChamps.TabIndex = 15
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(15, 76)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(96, 23)
        Me.btnSelectAll.TabIndex = 16
        Me.btnSelectAll.Text = "Select all"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnDeselectAll
        '
        Me.btnDeselectAll.Location = New System.Drawing.Point(117, 76)
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.Size = New System.Drawing.Size(96, 23)
        Me.btnDeselectAll.TabIndex = 17
        Me.btnDeselectAll.Text = "Deselect all"
        Me.btnDeselectAll.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(340, 234)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Build types to download:"
        '
        'btnSettings
        '
        Me.btnSettings.Location = New System.Drawing.Point(354, 21)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(117, 28)
        Me.btnSettings.TabIndex = 20
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(328, 171)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Last used on: "
        '
        'lblLastUsed
        '
        Me.lblLastUsed.AutoSize = True
        Me.lblLastUsed.Location = New System.Drawing.Point(328, 193)
        Me.lblLastUsed.Name = "lblLastUsed"
        Me.lblLastUsed.Size = New System.Drawing.Size(53, 13)
        Me.lblLastUsed.TabIndex = 22
        Me.lblLastUsed.Text = "Unknown"
        '
        'frmFlavorSyncMain
        '
        Me.AcceptButton = Me.btnDownloadBuilds
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 423)
        Me.Controls.Add(Me.lblLastUsed)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnDeselectAll)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.clbChamps)
        Me.Controls.Add(Me.chkDownloadARAM)
        Me.Controls.Add(Me.chkDownloadSupport)
        Me.Controls.Add(Me.chkDownloadJungle)
        Me.Controls.Add(Me.chkDownloadLane)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnDownloadBuilds)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmFlavorSyncMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LoLFlavor Sync"
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblLastUsed As System.Windows.Forms.Label
End Class
