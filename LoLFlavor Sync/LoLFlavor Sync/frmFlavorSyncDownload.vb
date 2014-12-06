Imports LoLFlavor_Sync.Library
Imports System.IO
Imports System.Threading
Public Class frmFlavorSyncDownload
    Private downloading As Boolean
    Private cancel As Boolean

    Private champsToDownload As List(Of Champion)
    Private buildsToDownload As List(Of DownloadChampion.laneType)
    Private wrkThread As Thread

    Sub New(ByVal chTD As List(Of Champion), ByVal bTD As List(Of DownloadChampion.laneType))
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.champsToDownload = chTD
        Me.buildsToDownload = bTD
    End Sub

    Private Sub formLoad()
        Me.Text = "LoLFlavor Sync " & Properties.VersionLocal
        Me.Cursor = Cursors.WaitCursor
        Me.ActiveControl = btnCancel
        Me.txtStatus.Visible = False
        wrkThread = New Thread(AddressOf Me.Start)
        downloading = True
        If String.IsNullOrEmpty(Thread.CurrentThread.Name) Then Thread.CurrentThread.Name = "Main Thread"
        If String.IsNullOrEmpty(wrkThread.Name) Then wrkThread.Name = "Worker Thread"
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

    Private Sub deleteFilesAndDirectories(ByVal path As String, ByVal deleteRootDirectory As Boolean, Optional ByVal pbControl As Boolean = False, Optional ByVal pbPercent As Integer = 100, Optional ByVal displayStatus As Boolean = True)
        If pbControl Then
            addStatus("Deleting: " & path)
            If pbPercent < 1 Or pbPercent > 99 Then pbPercent = 100
            Dim items As Integer = My.Computer.FileSystem.GetDirectories(path, FileIO.SearchOption.SearchAllSubDirectories).Count + My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchAllSubDirectories).Count
            If items <= 0 Then
                addPbPercentage(pbPercent / 100)
                Properties.DelFolderContent(path, deleteRootDirectory)
            Else
                Properties.DelFolderContent(path, deleteRootDirectory, True, Math.Floor((pbStatus.Invoke(Function() pbStatus.Maximum) / items) * (pbPercent / 100)), AddressOf addPb, displayStatus, AddressOf addStatus)
            End If
        Else
            Properties.DelFolderContent(path, deleteRootDirectory)
        End If
    End Sub

    Private Sub Start()
        pPrepare()
        startPrepare()

        pCheckConnectivity()
        startCheckConnectivity()

        pDownload()
        startDownload()

        pInstall()
        startInstall()

        pCleanup()
        startCleanup()

        pComplete()
    End Sub

    Private Sub pPrepare()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf pPrepare))
        Else
            pbStatus.Maximum = 100000
            pbStatus.Value = 0
            pbOverallStatus.Value = 0
            lblpbStatusPercent.Text = pbStatus.Value.ToString & "%"
            lblpbOverallStatusPercent.Text = pbOverallStatus.Value.ToString & "%"

            Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " - Preparing"
            addStatus("Preparing..", True)
            Me.Refresh()
        End If
    End Sub
    Private Sub startPrepare()
        If Directory.Exists(Properties.TempDirBuilds) Then
            deleteFilesAndDirectories(Properties.TempDirBuilds, False, True, 100, False)
        Else
            My.Computer.FileSystem.CreateDirectory(Properties.TempDirBuilds)
            addStatus("Creating temp directory: " & Properties.TempDirBuilds)
            addPbPercentage(90)
        End If

        My.Computer.FileSystem.CreateDirectory(Properties.TempDirBuilds & "\Config")
        My.Computer.FileSystem.CreateDirectory(Properties.TempDirBuilds & "\Config\Champions")

        For Each obj As Champion In champsToDownload
            My.Computer.FileSystem.CreateDirectory(Properties.TempDirBuilds & "\Config\Champions\" & obj.Name)
            My.Computer.FileSystem.CreateDirectory(Properties.TempDirBuilds & "\Config\Champions\" & obj.Name & "\Recommended")
        Next

        addPbPercentage(100)
        System.Threading.Thread.Sleep(250)
        If cancel Then
            startCancel()
            Exit Sub
        End If
    End Sub

    Private Sub pCheckConnectivity()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf pCheckConnectivity))
        Else
            pbStatus.Value = 0
            pbOverallStatus.Value = 0
            lblpbStatusPercent.Text = pbStatus.Value.ToString & "%"
            lblpbOverallStatusPercent.Text = pbOverallStatus.Value.ToString & "%"

            Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " - Checking Connectivity"
            addStatus(" ")
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

            Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " - Downloading"
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
            Using dl As New DownloadChampion(objChampion, Properties.TempDirBuilds)
                For Each objBuild As DownloadChampion.laneType In buildsToDownload
                    Dim ln As String = objBuild.ToString
                    Dim lnf As String = ln.ElementAt(0)
                    ln = lnf.ToUpper & ln.Remove(0, 1)
                    Try
                        dl.DownloadBuild(objBuild)
                        addStatus(ln & " Success")
                    Catch ex As Exception
                        addStatus(ln & " Failed: " & ex.Message)
                    End Try
                    addPb(pbIncrement)
                Next
            End Using
            addStatus(" ")
        Next

        addPbPercentage(100)
        System.Threading.Thread.Sleep(250)
    End Sub

    Private Sub pInstall()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf pInstall))
        Else
            pbStatus.Maximum = 100000
            pbStatus.Value = 0
            pbOverallStatus.Value = 50
            lblpbStatusPercent.Text = pbStatus.Value.ToString & "%"
            lblpbOverallStatusPercent.Text = pbOverallStatus.Value.ToString & "%"

            Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " - Installing"
            addStatus("Installing..", True)
            Me.Refresh()
        End If
    End Sub
    Private Sub startInstall()
        If Not My.Computer.FileSystem.DirectoryExists(Properties.LoLPath & "\Config") Then
            My.Computer.FileSystem.CreateDirectory(Properties.LoLPath & "\Config")
            addPbPercentage(95)
        ElseIf My.Computer.FileSystem.DirectoryExists(Properties.LoLPath & "\Config\Champions") Then
            deleteFilesAndDirectories(Properties.LoLPath & "\Config\Champions", False, True, 95, False)
            My.Computer.FileSystem.DeleteDirectory(Properties.LoLPath & "\Config\Champions", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If

        addStatus("Copying files from: " & Properties.TempDirBuilds & "\Config\Champions to " & LoLPath & "\Config\Champions")
        My.Computer.FileSystem.CopyDirectory(Properties.TempDirBuilds & "\Config", Properties.LoLPath & "\Config", True)

        addPbPercentage(100)
        System.Threading.Thread.Sleep(250)
        If cancel Then
            startCancel()
            Exit Sub
        End If
    End Sub

    Private Sub pCleanup()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf pCleanup))
        Else
            pbStatus.Maximum = 100000
            pbStatus.Value = 0
            pbOverallStatus.Value = 75
            lblpbStatusPercent.Text = pbStatus.Value.ToString & "%"
            lblpbOverallStatusPercent.Text = pbOverallStatus.Value.ToString & "%"

            Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " - Finalizing"
            addStatus(" ")
            addStatus("Finalizing..", True)
            Me.Refresh()
        End If
    End Sub
    Private Sub startCleanup(Optional ByVal cancel As Boolean = False)
        deleteFilesAndDirectories(Properties.TempDirBuilds, True, Not cancel, 99, False)
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

            Me.Text = "LoLFlavor Sync " & Properties.VersionLocal
            addStatus(" ")
            addStatus("Builds Installed!", True)

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

            Me.Text = "LoLFlavor Sync " & Properties.VersionLocal & " - Canceling"
            addStatus(" ")
            addStatus("Canceling.. Please wait..", True)
            Me.Refresh()
        End If
    End Sub
    Private Sub startCancel()
        pCancel()
        startCleanup(True)
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
