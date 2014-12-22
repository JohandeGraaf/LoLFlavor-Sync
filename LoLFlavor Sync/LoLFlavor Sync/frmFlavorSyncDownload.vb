Imports LoLFlavor_Sync.Library
Imports System.IO
Imports System.Threading
Public Class frmFlavorSyncDownload
    Public Property mode As modes = modes.Remove

    Public Enum modes As Integer
        Remove
        Overwrite
        RemoveOnly
    End Enum

    Private downloading As Boolean
    Private cancel As Boolean

    Private champsToDownload As List(Of Champion)
    Private buildsToDownload As List(Of DownloadChampion.laneType)
    Private builds As New List(Of DownloadChampion)
    Private wrkThread As Thread

    Sub New(ByVal chTD As List(Of Champion), ByVal bTD As List(Of DownloadChampion.laneType))
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.champsToDownload = chTD
        Me.buildsToDownload = bTD
    End Sub

    Private Sub formLoad()
        If Properties.Garena Then
            Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " (Garena)"
        Else
            Me.Text = "LoLFlavor Sync " & Properties.VersionLocal
        End If
        Me.Cursor = Cursors.WaitCursor
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
            lblpbStatusPercent.Text = Math.Round((pbStatus.Value / pbStatus.Maximum) * 100).ToString() & "%"
            pbStatus.Refresh()
            lblpbStatusPercent.Refresh()
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
                txtStatus.Select(txtStatus.TextLength, 0)
                txtStatus.ScrollToCaret()
                txtStatus.Refresh()
            End If
        End If
    End Sub

    Private Sub Start()
        If mode = modes.RemoveOnly Then
            pRemove()
            StartRemove()
            Exit Sub
        Else
            pCheckConnectivity()
            startCheckConnectivity()

            pDownload()
            startDownload()

            pPrepareInstall()
            startPrepareInstall()

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
            pbOverallStatus.Value = 0
            lblpbStatusPercent.Text = pbStatus.Value.ToString & "%"
            lblpbOverallStatusPercent.Text = pbOverallStatus.Value.ToString & "%"

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
        startPrepareInstall()
        pComplete()
    End Sub

    Private Sub pCheckConnectivity()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf pCheckConnectivity))
        Else
            pbStatus.Value = 0
            pbOverallStatus.Value = 0
            lblpbStatusPercent.Text = pbStatus.Value.ToString & "%"
            lblpbOverallStatusPercent.Text = pbOverallStatus.Value.ToString & "%"

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
        Dim connectedToInternet As Func(Of Boolean) = _
            Function()
                If My.Computer.Network.IsAvailable Then
                    Try
                        Using client = New System.Net.WebClient()
                            Using stream = client.OpenRead("http://google.com")
                                Return True
                            End Using
                        End Using
                    Catch
                        Return False
                    End Try
                Else
                    Return False
                End If
            End Function

        While Not connectedToInternet()
            If tries > maxtries Then
                addStatus("Not connected after " & maxtries & " tries, canceling..")
                Me.BeginInvoke(Sub() Me.Close())
                startCancel()
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
            pbOverallStatus.Value = 25
            lblpbStatusPercent.Text = pbStatus.Value.ToString & "%"
            lblpbOverallStatusPercent.Text = pbOverallStatus.Value.ToString & "%"

            If Properties.Garena Then
                Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " (Garena)" & " - Downloading"
            Else
                Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " - Downloading"
            End If
            addStatus(" ")
            addStatus("Downloading..", True, True)
            Me.Refresh()
        End If
    End Sub
    Private Sub startDownload()
        Dim pbIncrement As Integer = pbStatus.Invoke(Function() pbStatus.Maximum) / champsToDownload.Count / buildsToDownload.Count
        For Each objChampion As Champion In champsToDownload
            If cancel Then
                startCancel()
                Exit Sub
            End If
            addStatus("Downloading builds for: " & objChampion.DisplayName, True)
            Dim objDL As DownloadChampion
            If Properties.Garena Then
                objDL = New DownloadChampion(objChampion, Properties.LoLFlavorSourceUrlFormat, Properties.LoLPath, Properties.GarenaDestinationPath, Properties.GarenaDestinationFile)
            Else
                objDL = New DownloadChampion(objChampion, Properties.LoLFlavorSourceUrlFormat, Properties.LoLPath, Properties.RiotDestinationPath, Properties.RiotDestinationFile)
            End If

            For Each objBuild As DownloadChampion.laneType In buildsToDownload
                Dim lStrF As String = objBuild.ToString.ElementAt(0)
                Dim lStr As String = lStrF.ToUpper & objBuild.ToString.Remove(0, 1)
                Try
                    objDL.DownloadBuild(objBuild)
                    addStatus(lStr & " Success")
                Catch ex As Exception
                    addStatus(lStr & " Failed: " & ex.Message)
                End Try
                addPb(pbIncrement)
            Next
            builds.Add(objDL)
            addStatus(" ")
        Next
        addPbPercentage(100)
        System.Threading.Thread.Sleep(250)
    End Sub

    Private Sub pPrepareInstall()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf pPrepareInstall))
        Else
            pbStatus.Maximum = 100000
            pbStatus.Value = 0
            pbOverallStatus.Value = 50
            lblpbStatusPercent.Text = pbStatus.Value.ToString & "%"
            lblpbOverallStatusPercent.Text = pbOverallStatus.Value.ToString & "%"

            If Properties.Garena Then
                Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " (Garena)" & " - Preparing"
            Else
                Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " - Preparing"
            End If
            addStatus("Preparing..", True)
            Me.Refresh()
        End If
    End Sub

    Private Sub startPrepareInstall()
        Dim path As String
        Dim del As New List(Of String)

        If Properties.Garena Then
            path = Properties.LoLPath & Properties.GarenaDestinationPathB
        Else
            path = Properties.LoLPath & Properties.RiotDestinationPathB
        End If

        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
            mode = modes.Overwrite
        End If

        For Each objChampion As Champion In Properties.AllChampions
            Dim path2 As String = path & "\" & objChampion.Name()
            If Directory.Exists(path2) Then
                If Directory.Exists(path2 & "\Recommended") Then
                    del.Add(path2 & "\Recommended")
                Else
                    Directory.CreateDirectory(path2 & "\Recommended")
                End If
            Else
                Directory.CreateDirectory(path2 & "\Recommended")
            End If
        Next

        If mode = modes.Remove Or mode = modes.RemoveOnly Then
            Dim pbIncrement As Integer = pbStatus.Invoke(Function() pbStatus.Maximum) \ If(del.Count <= 0, 1, del.Count)
            For Each objStr As String In del
                Properties.DelFolderContent(objStr, False, True, pbIncrement, AddressOf addPb, False, Sub(x) x = x)
            Next
        End If

        addPbPercentage(100)
    End Sub

    Private Sub pInstall()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf pInstall))
        Else
            pbStatus.Maximum = 100000
            pbStatus.Value = 0
            pbOverallStatus.Value = 75
            lblpbStatusPercent.Text = pbStatus.Value.ToString & "%"
            lblpbOverallStatusPercent.Text = pbOverallStatus.Value.ToString & "%"

            If Properties.Garena Then
                Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " (Garena)" & " - Saving"
            Else
                Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " - Saving"
            End If
            addStatus(" ")
            addStatus("Saving..", True)
            Me.Refresh()
        End If
    End Sub
    Private Sub startInstall()
        Dim pbIncrement As Integer = pbStatus.Invoke(Function() pbStatus.Maximum) \ builds.Count

        For Each objDlCh As DownloadChampion In builds
            objDlCh.SaveBuilds()
            addPb(pbIncrement)
        Next

        addPbPercentage(100)
        System.Threading.Thread.Sleep(250)
    End Sub

    Private Sub pComplete()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf pComplete))
        Else
            pbStatus.Maximum = 100
            pbStatus.Value = 100
            pbOverallStatus.Value = 100
            lblpbStatusPercent.Text = pbStatus.Value.ToString & "%"
            lblpbOverallStatusPercent.Text = pbOverallStatus.Value.ToString & "%"

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
            pbOverallStatus.Value = 0
            lblpbStatusPercent.Text = pbStatus.Value.ToString & "%"
            lblpbOverallStatusPercent.Text = pbOverallStatus.Value.ToString & "%"

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
        pCancel()
        Thread.CurrentThread.Abort()
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
        If txtStatus.Visible Then
            Me.Height = 219
            btnDisplayOutput.Text = "Show output"
        Else
            Me.Height = 378
            btnDisplayOutput.Text = "Hide output"
        End If
        txtStatus.Visible = Not txtStatus.Visible
    End Sub

    Private Sub frmFlavorSyncDownload_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        cancel = True
        While wrkThread.IsAlive()
            Application.DoEvents()
        End While
    End Sub

    Private Sub frmFlavorSyncDownload_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Not downloading Then
            Environment.Exit(0)
        End If
    End Sub
#End Region
End Class
