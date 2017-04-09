Imports LoLFlavor_Sync.Domain
Imports System.IO
Imports LoLFlavor_Sync.Domain.Listeners

Public Class frmFlavorSyncLoad
    Implements IStateChanged
    Private lfs As LoLFlavorSync

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lfs = New LoLFlavorSync()
        lfs.AddStateChangedListener(Me)

        Me.AcceptButton = btnConfirm
    End Sub

    Private Sub FormShown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Application.DoEvents()

        If lfs.LoLPath.IsValid() And GlobalVars.OptionSkipForm Then
            Me.Hide()
            Dim mainForm As New frmFlavorSyncMain(lfs)
            mainForm.Show()
            mainForm.Focus()
        End If

        lfs.Notify()
    End Sub

    Public Sub OnTitleChange(title As String) Implements IStateChanged.OnTitleChange
        Me.Text = title
    End Sub

    Public Sub OnRegionChange(garena As Boolean) Implements IStateChanged.OnRegionChange
        RemoveHandler chkGarena.CheckedChanged, AddressOf chkGarena_CheckedChanged
        chkGarena.Checked = garena
        AddHandler chkGarena.CheckedChanged, AddressOf chkGarena_CheckedChanged

        If garena Then
            If Environment.Is64BitOperatingSystem Then
                Label2.Text = "Example: C:\Program Files (x86)\GarenaLoL"
            Else
                Label2.Text = "Example: C:\Program Files\GarenaLoL"
            End If
        Else
            Label2.Text = "Example: C:\Riot Games\League of Legends"
        End If

        Dim lolPath As LoLPath = LoLPath.Detect()
        lfs.LoLPath = lolPath
    End Sub

    Public Sub OnLoLPathChange(lolpath As LoLPath) Implements IStateChanged.OnLoLPathChange
        If lolpath.IsValid() Then
            fbdLoLPath.SelectedPath = lolpath.Path
            txtLoLPath.Text = lolpath.Path

            ActiveControl = btnConfirm
            chkSkip.Enabled = True
        Else
            fbdLoLPath.SelectedPath = LoLPath.EMPTY.Path
            txtLoLPath.Text = LoLPath.EMPTY.Path

            ActiveControl = btnBrowse
            chkSkip.Enabled = False
        End If
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        fbdLoLPath.SelectedPath = lfs.LoLPath.Path

        If fbdLoLPath.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        Dim lolPath = New LoLPath(fbdLoLPath.SelectedPath)

        If lolPath.IsValid() Then
            lfs.LoLPath = lolPath
        Else
            MessageBox.Show("Please select your League of Legends directory.", "Invalid directory", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If lfs.LoLPath.IsValid() Then
            GlobalVars.OptionSkipForm = chkSkip.Checked

            If chkSkip.Checked Then
                GlobalVars.OptionLoLPath = lfs.LoLPath.Path
            End If

            Me.Hide()
            Dim mainForm As New frmFlavorSyncMain(lfs)
            mainForm.Show()
            mainForm.Focus()
        Else
            MessageBox.Show("Please select your League of Legends directory.", "Invalid directory", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub chkGarena_CheckedChanged(sender As Object, e As EventArgs) Handles chkGarena.CheckedChanged
        lfs.Garena = chkGarena.Checked
    End Sub
End Class
