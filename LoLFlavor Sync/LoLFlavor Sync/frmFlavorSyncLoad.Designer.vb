<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFlavorSyncLoad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFlavorSyncLoad))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.fbdLoLPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtLoLPath = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.chkSkip = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(330, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Please specify your League of Legends directory and press 'Confirm'."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(220, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Example: C:\Riot Games\League of Legends"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Welcome to LoLFlavor Sync."
        '
        'fbdLoLPath
        '
        Me.fbdLoLPath.Description = "Please select your League of Legends directory."
        Me.fbdLoLPath.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'txtLoLPath
        '
        Me.txtLoLPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtLoLPath.Location = New System.Drawing.Point(13, 97)
        Me.txtLoLPath.Name = "txtLoLPath"
        Me.txtLoLPath.ReadOnly = True
        Me.txtLoLPath.Size = New System.Drawing.Size(337, 20)
        Me.txtLoLPath.TabIndex = 4
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(356, 95)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 5
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(96, 133)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirm.TabIndex = 6
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'chkSkip
        '
        Me.chkSkip.AutoSize = True
        Me.chkSkip.Enabled = False
        Me.chkSkip.Location = New System.Drawing.Point(177, 137)
        Me.chkSkip.Name = "chkSkip"
        Me.chkSkip.Size = New System.Drawing.Size(154, 17)
        Me.chkSkip.TabIndex = 7
        Me.chkSkip.Text = "Hide this window next time."
        Me.chkSkip.UseVisualStyleBackColor = True
        '
        'frmFlavorSyncLoad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 171)
        Me.Controls.Add(Me.chkSkip)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtLoLPath)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmFlavorSyncLoad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LoLFlavor Sync"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents fbdLoLPath As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtLoLPath As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents chkSkip As System.Windows.Forms.CheckBox

End Class
