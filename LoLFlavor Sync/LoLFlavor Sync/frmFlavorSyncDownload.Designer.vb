<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFlavorSyncDownload
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFlavorSyncDownload))
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.pbStatus = New System.Windows.Forms.ProgressBar()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pbOverallStatus = New System.Windows.Forms.ProgressBar()
        Me.lblpbStatusPercent = New System.Windows.Forms.Label()
        Me.lblpbOverallStatusPercent = New System.Windows.Forms.Label()
        Me.btnDisplayOutput = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.SystemColors.Window
        Me.txtStatus.Location = New System.Drawing.Point(12, 181)
        Me.txtStatus.Multiline = True
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStatus.Size = New System.Drawing.Size(525, 142)
        Me.txtStatus.TabIndex = 0
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(9, 27)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(56, 17)
        Me.lblStatus.TabIndex = 1
        Me.lblStatus.Text = "Status: "
        '
        'pbStatus
        '
        Me.pbStatus.Location = New System.Drawing.Point(13, 71)
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(524, 23)
        Me.pbStatus.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(442, 21)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(95, 29)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'pbOverallStatus
        '
        Me.pbOverallStatus.Location = New System.Drawing.Point(12, 113)
        Me.pbOverallStatus.Name = "pbOverallStatus"
        Me.pbOverallStatus.Size = New System.Drawing.Size(525, 23)
        Me.pbOverallStatus.TabIndex = 5
        '
        'lblpbStatusPercent
        '
        Me.lblpbStatusPercent.AutoSize = True
        Me.lblpbStatusPercent.BackColor = System.Drawing.SystemColors.Control
        Me.lblpbStatusPercent.Location = New System.Drawing.Point(264, 55)
        Me.lblpbStatusPercent.Name = "lblpbStatusPercent"
        Me.lblpbStatusPercent.Size = New System.Drawing.Size(21, 13)
        Me.lblpbStatusPercent.TabIndex = 6
        Me.lblpbStatusPercent.Text = "0%"
        '
        'lblpbOverallStatusPercent
        '
        Me.lblpbOverallStatusPercent.AutoSize = True
        Me.lblpbOverallStatusPercent.BackColor = System.Drawing.SystemColors.Control
        Me.lblpbOverallStatusPercent.Location = New System.Drawing.Point(264, 97)
        Me.lblpbOverallStatusPercent.Name = "lblpbOverallStatusPercent"
        Me.lblpbOverallStatusPercent.Size = New System.Drawing.Size(21, 13)
        Me.lblpbOverallStatusPercent.TabIndex = 7
        Me.lblpbOverallStatusPercent.Text = "0%"
        '
        'btnDisplayOutput
        '
        Me.btnDisplayOutput.Location = New System.Drawing.Point(12, 147)
        Me.btnDisplayOutput.Name = "btnDisplayOutput"
        Me.btnDisplayOutput.Size = New System.Drawing.Size(94, 23)
        Me.btnDisplayOutput.TabIndex = 8
        Me.btnDisplayOutput.Text = "Show output"
        Me.btnDisplayOutput.UseVisualStyleBackColor = True
        '
        'frmFlavorSyncDownload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 176)
        Me.Controls.Add(Me.btnDisplayOutput)
        Me.Controls.Add(Me.lblpbOverallStatusPercent)
        Me.Controls.Add(Me.lblpbStatusPercent)
        Me.Controls.Add(Me.pbOverallStatus)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.pbStatus)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.txtStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmFlavorSyncDownload"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "LoLFlavor Sync"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents pbStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pbOverallStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents lblpbStatusPercent As System.Windows.Forms.Label
    Friend WithEvents lblpbOverallStatusPercent As System.Windows.Forms.Label
    Friend WithEvents btnDisplayOutput As System.Windows.Forms.Button
End Class
