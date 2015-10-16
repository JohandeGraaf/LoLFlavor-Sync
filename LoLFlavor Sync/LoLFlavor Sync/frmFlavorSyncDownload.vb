Imports LoLFlavor_Sync.Lib
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Threading
Imports LoLFlavor_Sync.DLBuilds

Public Class frmFlavorSyncDownload
    Public Property mode As modes = modes.Remove

    Public Enum modes As Integer
        Remove
        Overwrite
        RemoveOnly
    End Enum

    Private downloading As Boolean
    Private wrkThread As Thread
    Private _GetBuilds As GetBuilds
    Private baseText As String = ""

    Sub New(ByVal DL As GetBuilds)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me._GetBuilds = DL
    End Sub

    Private Sub formLoad()
        If Properties.Garena Then
            Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " (Garena)"
        Else
            Me.Text = "LoLFlavor Sync " & Properties.VersionLocal
        End If
        Me.Cursor = Cursors.AppStarting
        Me.ActiveControl = btnCancel
        Me.txtStatus.Visible = False
        wrkThread = New Thread(AddressOf Me.Start)
        downloading = True
        If String.IsNullOrEmpty(Thread.CurrentThread.Name) Then Thread.CurrentThread.Name = "Main Thread"
        If String.IsNullOrEmpty(wrkThread.Name) Then wrkThread.Name = "Worker Thread"
        If mode < modes.Remove Or mode > modes.RemoveOnly Then mode = modes.Remove
    End Sub

    Private Sub formShown()
        wrkThread.Start()
    End Sub

    Private Sub addPb(ByVal increment As Integer)
        If pbStatus.InvokeRequired Then
            pbStatus.Invoke(New Action(Sub() addPb(increment)))
        Else
            If Not pbStatus.Value + increment > pbStatus.Maximum Then
                pbStatus.Value = pbStatus.Value + increment
            Else
                pbStatus.Value = pbStatus.Maximum
            End If
            Text = baseText & "  |  " & Math.Round((pbStatus.Value / pbStatus.Maximum) * 100).ToString() & "%"
            pbStatus.Refresh()
        End If
    End Sub

    Private Sub addPbPercentage(ByVal percentage As Double)
        If pbStatus.InvokeRequired Then
            pbStatus.Invoke(New Action(Sub() addPbPercentage(percentage)))
        Else
            If percentage < 1 Or percentage > 100 Then Exit Sub
            addPb(Math.Round(pbStatus.Maximum * (percentage / 100)))
        End If
    End Sub

    Private Sub txtStatusToBottom(Optional refresh As Boolean = True)
        If txtStatus.InvokeRequired Then
            txtStatus.Invoke(New Action(Sub() txtStatusToBottom(refresh)))
        Else
            txtStatus.Select(txtStatus.TextLength, 0)
            txtStatus.ScrollToCaret()
            If refresh Then txtStatus.Refresh()
        End If
    End Sub

    Private Sub addStatus(ByVal status As String, Optional ByVal updateLabel As Boolean = False, Optional ByVal onlyLabel As Boolean = False)
        If txtStatus.InvokeRequired Then
            txtStatus.Invoke(New Action(Sub() addStatus(status, updateLabel, onlyLabel)))
        Else
            If updateLabel Then
                lblStatus.Text = "Status: " & status
                lblStatus.Refresh()
            End If
            If Not onlyLabel Then
                txtStatus.AppendText(status & Environment.NewLine)
                txtStatusToBottom(False)
            End If
        End If
    End Sub

    Private Sub Start()
        If mode = modes.RemoveOnly Then
            pRemove()
            StartRemove()
        Else
            pCheckConnectivity()
            startCheckConnectivity()

            pDownload()
            startDownload()

            pInstall()
            startInstall()

            pComplete()
        End If
    End Sub

    Private Sub pRemove()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf pRemove))
        Else
            pbStatus.Maximum = 100000
            pbStatus.Value = 0
            If Properties.Garena Then
                Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " (Garena)" & " - Removing"
            Else
                Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " - Removing"
            End If
            addStatus("Removing all builds, please wait..", True)
            Me.Refresh()
        End If
    End Sub

    Private Sub StartRemove()
        _GetBuilds.RemoveAllBuilds()
        pComplete()
    End Sub

    Private Sub pCheckConnectivity()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf pCheckConnectivity))
        Else
            pbStatus.Value = 0

            If Properties.Garena Then
                Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " (Garena)" & " - Checking Connectivity"
            Else
                Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " - Checking Connectivity"
            End If
            addStatus("Checking connectivity..", True)
            Me.Refresh()
        End If
    End Sub
    Private Sub startCheckConnectivity()
        Dim tries As Integer = 1
        Dim maxtries As Integer = 10
        Dim intervalms As Integer = 10000
        Dim connectedToInternet As Func(Of Boolean) =
            Function()
                If My.Computer.Network.IsAvailable Then
                    Try
                        Using client = New System.Net.WebClient()
                            Using stream = client.OpenRead("http://google.com")
                                Return True
                            End Using
                        End Using
                    Catch
                        Dim hosts As String() = {"8.8.8.8", "8.8.4.4", "4.2.2.2", "208.67.222.222", "208.67.220.220"}
                        Dim success = 0

                        For Each host In hosts
                            Try
                                Dim p As New Ping
                                Dim po As New PingOptions
                                Dim buffer(32) As Byte
                                Const timeout As Integer = 1000
                                Dim pr As PingReply = p.Send(host, timeout, buffer, po)
                                success += 1
                            Catch e As Exception
                                Continue For
                            End Try
                        Next

                        If success > 0 Then
                            Return True
                        Else
                            Return False
                        End If
                    End Try
                Else
                    Return False
                End If
            End Function

        While Not connectedToInternet()
            If tries > maxtries Then
                addStatus("Not connected after " & maxtries & " tries, canceling..")
                Me.BeginInvoke(Sub() Me.Close())
                Thread.Sleep(1000)
                Exit Sub
            Else
                addStatus("Not connected, try " & tries & " of " & maxtries)
                addStatus("Please connect to the internet", True, True)
                tries += 1
                Thread.Sleep(intervalms)
            End If
        End While

        addStatus("Connected!", True)
    End Sub

    Private Sub pDownload()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf pDownload))
        Else
            pbStatus.Maximum = 100000
            pbStatus.Value = 0

            If Properties.Garena Then
                baseText = "LoLFlavor Sync " & Properties.VersionLocal & " (Garena)" & " - Downloading [1/2]"
            Else
                baseText = "LoLFlavor Sync " & Properties.VersionLocal & " - Downloading [1/2]"
            End If
            Text = baseText
            addStatus(" ")
            addStatus("Downloading..", True, True)
            Me.Refresh()
        End If
    End Sub
    Private Sub startDownload()
        Dim pbIncrement As Integer = pbStatus.Invoke(Function() pbStatus.Maximum) / _GetBuilds.GetChampsToDownload.Count / _GetBuilds.GetBuildsToDownload.Count
        Dim updateStatus As Action(Of String) = _
            Sub(text As String)
                addStatus(text)
            End Sub
        Dim updateLabel As Action(Of String) = _
            Sub(text As String)
                addStatus(text, True, True)
            End Sub
        Dim updatePB As Action = _
            Sub()
                addPb(pbIncrement)
            End Sub

        _GetBuilds.SetUpdateLabel(updateLabel)
        _GetBuilds.SetUpdateStatus(updateStatus)
        _GetBuilds.SetUpdatePB(updatePB)

        _GetBuilds.Download()

        addPbPercentage(100)
        System.Threading.Thread.Sleep(250)
    End Sub

    Private Sub pInstall()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf pInstall))
        Else
            pbStatus.Maximum = 100000
            pbStatus.Value = 0

            If Properties.Garena Then
                baseText = "LoLFlavor Sync " & Properties.VersionLocal & " (Garena)" & " - Saving [2/2]"
            Else
                baseText = "LoLFlavor Sync " & Properties.VersionLocal & " - Saving [2/2]"
            End If
            Me.Text = baseText
            addStatus("Saving..", True)
            Me.Refresh()
        End If
    End Sub
    Private Sub startInstall()
        Dim pbIncrement As Integer = pbStatus.Invoke(Function() pbStatus.Maximum) \ _GetBuilds.GetDownloadedBuilds.Count
        Dim updatePB As Action = _
            Sub()
                addPb(pbIncrement)
            End Sub

        _GetBuilds.SetUpdatePB(updatePB)
        _GetBuilds.Save(CBool(mode = modes.Remove))

        addPbPercentage(100)
        System.Threading.Thread.Sleep(250)
    End Sub

    Private Sub pComplete()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf pComplete))
        Else
            pbStatus.Maximum = 100
            pbStatus.Value = 100

            If Properties.Garena Then
                Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " (Garena)"
            Else
                Me.Text = "LoLFlavor Sync " & Properties.VersionLocal
            End If
            addStatus(" ")
            addStatus("Completed!", True)

            Me.Cursor = Cursors.Arrow
            btnCancel.Text = "Quit"
            downloading = False
            Me.Refresh()
        End If
    End Sub

    Private Sub pCancel()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf pCancel))
        Else
            pbStatus.Maximum = 100
            pbStatus.Value = 0

            If Properties.Garena Then
                Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " (Garena)" & " - Canceling"
            Else
                Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " - Canceling"
            End If
            addStatus(" ")
            addStatus("Canceling.. Please wait..", True)
            Me.Refresh()
        End If
    End Sub
    Private Sub startCancel()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf startCancel))
        Else
            pCancel()
            _GetBuilds.Cancel()
            Thread.Sleep(750)
            wrkThread.Abort()
        End If
    End Sub

#Region "Event Handlers"
    Private Sub frmFlavorSyncDownload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formLoad()
    End Sub

    Private Sub frmFlavorSyncDownload_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        formShown()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnDisplayOutput_Click(sender As Object, e As EventArgs) Handles btnDisplayOutput.Click
        txtStatus.Visible = Not txtStatus.Visible
        If txtStatus.Visible Then
            Me.Size = New Size(Me.Size.Width, 392)
            btnDisplayOutput.Text = "Fewer details"
            txtStatusToBottom()
        Else
            Me.Size = New Size(Me.Size.Width, 195)
            btnDisplayOutput.Text = "More details"
        End If
    End Sub

    Private Sub frmFlavorSyncDownload_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If downloading Then
            startCancel()
            While wrkThread.IsAlive()
                Application.DoEvents()
            End While
        End If
    End Sub

    Private Sub frmFlavorSyncDownload_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Not downloading Then
            Application.Exit()
        End If
    End Sub
#End Region
End Class
