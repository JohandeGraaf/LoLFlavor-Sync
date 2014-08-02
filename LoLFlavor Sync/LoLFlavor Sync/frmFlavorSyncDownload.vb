Imports System.IO
Imports System.Threading
Public Class frmFlavorSyncDownload
    Private LoLPath As String = frmFlavorSyncLoad.getLoLPath
    Private tempDirectory As String = Environment.GetEnvironmentVariable("TEMP") & "\tempFlavorSync"

    Private champsToDownload As New Queue

    Private prepareThread As Thread = New Thread(AddressOf Me.prepare)
    Private downloadThread As Thread = New Thread(AddressOf Me.download)
    Private installThread As Thread = New Thread(AddressOf Me.install)
    Private cleanupThread As Thread = New Thread(AddressOf Me.cleanup)

    Private downloadLane As Boolean = frmFlavorSyncMain.downloadLane
    Private downloadJungle As Boolean = frmFlavorSyncMain.downloadJungle
    Private downloadSupport As Boolean = frmFlavorSyncMain.downloadSupport
    Private downloadARAM As Boolean = frmFlavorSyncMain.downloadARAM

    Private finished As Boolean = False

    Private Sub frmFlavorSyncDownload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each champion In frmFlavorSyncMain.champsToDownload
            champsToDownload.Enqueue(champion)
        Next
        Control.CheckForIllegalCrossThreadCalls = False
        ActiveControl = btnCancel
        txtStatus.Visible = False
        Me.Cursor = Cursors.WaitCursor
        setStage(1)
    End Sub

    Private Sub addPb(ByVal increment As Integer)
        If Not pbStatus.Value + increment > pbStatus.Maximum Then
            pbStatus.Value = pbStatus.Value + increment
        Else
            pbStatus.Value = pbStatus.Maximum
        End If
        lblpbStatusPercent.Text = Math.Round((pbStatus.Value / pbStatus.Maximum) * 100).ToString() & "%"
        pbStatus.Refresh()
        lblpbStatusPercent.Refresh()
    End Sub

    Private Sub addPbPercentage(ByVal percentage As Double)
        If percentage < 1 Or percentage > 100 Then Exit Sub
        addPb(Math.Round(pbStatus.Maximum * (percentage / 100)))
    End Sub

    Private Sub addStatus(ByVal status As String, Optional ByVal updateLabel As Boolean = False)
        txtStatus.AppendText(status & Environment.NewLine)
        txtStatus.Select(txtStatus.TextLength, 0)
        txtStatus.ScrollToCaret()
        txtStatus.Refresh()
        If updateLabel Then
            lblStatus.Text = "Status: " & status
            lblStatus.Refresh()
        End If
    End Sub

    Private Sub deleteFilesAndDirectories(ByVal path As String, Optional ByVal pbControl As Boolean = False, Optional ByVal pbPercent As Integer = 100, Optional ByVal displayStatus As Boolean = True)
        Dim pbIncrement As Integer = 0
        If pbControl Then
            addStatus("Preparing to delete " & path)
            If pbPercent < 1 Or pbPercent > 99 Then pbPercent = 100
            Dim numberOfFiles As Integer = 0
            Dim numberOfFolders As Integer = 0
            For Each i As String In My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchAllSubDirectories)
                numberOfFiles = numberOfFiles + 1
            Next
            For Each i As String In My.Computer.FileSystem.GetDirectories(path, FileIO.SearchOption.SearchAllSubDirectories)
                numberOfFolders = numberOfFolders + 1
            Next
            If numberOfFiles + numberOfFolders <= 0 Then
                pbStatus.Value = pbStatus.Maximum * (pbPercent / 100)
            Else
                pbIncrement = Math.Floor((pbStatus.Maximum / (numberOfFiles + numberOfFolders)) * (pbPercent / 100))
            End If
        End If

        For Each foundFile As String In Enumerable.Reverse(My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchAllSubDirectories))
            My.Computer.FileSystem.DeleteFile(foundFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            If displayStatus Then addStatus("Deleted file: " & foundFile)
            addPb(pbIncrement)
        Next

        For Each foundFolder As String In Enumerable.Reverse(My.Computer.FileSystem.GetDirectories(path, FileIO.SearchOption.SearchAllSubDirectories))
            My.Computer.FileSystem.DeleteDirectory(foundFolder, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            If displayStatus Then addStatus("Deleted folder: " & foundFolder)
            addPb(pbIncrement)
        Next
    End Sub

    Private Sub prepare()
        If Directory.Exists(tempDirectory) Then
            deleteFilesAndDirectories(tempDirectory, True, 100, False)
        Else
            My.Computer.FileSystem.CreateDirectory(tempDirectory)
            addStatus("Creating temp directory: " & tempDirectory)
        End If

        My.Computer.FileSystem.CreateDirectory(tempDirectory & "\Config")
        My.Computer.FileSystem.CreateDirectory(tempDirectory & "\Config\Champions")

        For Each champion In champsToDownload
            My.Computer.FileSystem.CreateDirectory(tempDirectory & "\Config\Champions\" & champion)
            My.Computer.FileSystem.CreateDirectory(tempDirectory & "\Config\Champions\" & champion & "\Recommended")
        Next

        addPbPercentage(100)
        System.Threading.Thread.Sleep(250)
        setStage(2)
        prepareThread.Abort()
    End Sub

    Private Sub download()
        Dim errorAll As New Queue
        Dim pbIncrement As Integer = 0
        pbIncrement = Math.Floor(pbStatus.Maximum / If(champsToDownload.Count = 1, champsToDownload.Count, champsToDownload.Count - 1 / 4))

        If downloadLane Then
            addStatus("Downloading Lane Builds.", True)
            Using Download As New Download.DownloadHandler(tempDirectory)
                errorAll.Enqueue(Download.DownloadChamps(champsToDownload, LoLFlavor_Sync.Download.DownloadHandler.laneTypes.lane))
            End Using
        End If

        addPbPercentage(25)

        If downloadJungle Then
            addStatus("Downloading Jungle Builds.", True)
            Using Download As New Download.DownloadHandler(tempDirectory)
                errorAll.Enqueue(Download.DownloadChamps(champsToDownload, LoLFlavor_Sync.Download.DownloadHandler.laneTypes.jungle))
            End Using
        End If

        addPbPercentage(25)

        If downloadSupport Then
            addStatus("Downloading Support Builds.", True)
            Using Download As New Download.DownloadHandler(tempDirectory)
                errorAll.Enqueue(Download.DownloadChamps(champsToDownload, LoLFlavor_Sync.Download.DownloadHandler.laneTypes.support))
            End Using
        End If

        addPbPercentage(25)

        If downloadARAM Then
            addStatus("Downloading ARAM Builds.", True)
            Using Download As New Download.DownloadHandler(tempDirectory)
                errorAll.Enqueue(Download.DownloadChamps(champsToDownload, LoLFlavor_Sync.Download.DownloadHandler.laneTypes.aram))
            End Using
        End If

        addStatus(" ")

        For Each q As Queue In errorAll
            For Each s As String In q
                If Not String.IsNullOrWhiteSpace(s) Then
                    addStatus(s)
                End If
            Next
        Next

        addPbPercentage(100)
        System.Threading.Thread.Sleep(250)
        setStage(3)
        downloadThread.Abort()
    End Sub

    Private Sub install()
        If Not My.Computer.FileSystem.DirectoryExists(LoLPath & "\Config") Then
            My.Computer.FileSystem.CreateDirectory(LoLPath & "\Config")
            addPbPercentage(75)
        ElseIf My.Computer.FileSystem.DirectoryExists(LoLPath & "\Config\Champions") Then
            deleteFilesAndDirectories(LoLPath & "\Config\Champions", True, 80, False)
            My.Computer.FileSystem.DeleteDirectory(LoLPath & "\Config\Champions", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If

        addStatus("Copying files from: " & tempDirectory & "\Config\Champions to " & LoLPath & "\Config\Champions")
        My.Computer.FileSystem.CopyDirectory(tempDirectory & "\Config", LoLPath & "\Config", True)

        addPbPercentage(100)
        System.Threading.Thread.Sleep(250)
        setStage(4)
        installThread.Abort()
    End Sub

    Private Sub cleanup()
        deleteFilesAndDirectories(tempDirectory, True, 95, False)

        System.Threading.Thread.Sleep(250)
        addPbPercentage(100)
        setStage(5)
        cleanupThread.Abort()
    End Sub

    Private Sub setStage(ByVal stage As Integer)
        pbOverallStatus.Maximum = 50
        Select Case stage
            Case 1 'Prepare
                pbStatus.Value = 0
                pbStatus.Maximum = 100000
                lblpbStatusPercent.Text = "0%"
                pbOverallStatus.Value = 10
                lblpbOverallStatusPercent.Text = "20%"
                addStatus("Preparing...", True)
                Me.Text = "LoLFlavor Sync: Preparing"
                prepareThread.Start()
            Case 2 'Downloading
                pbStatus.Value = 0
                pbStatus.Maximum = 100000
                lblpbStatusPercent.Text = "0%"
                pbOverallStatus.Value = 20
                lblpbOverallStatusPercent.Text = "40%"
                addStatus(" ")
                Me.Text = "LoLFlavor Sync: Downloading"
                downloadThread.Start()
            Case 3 'Installing
                pbStatus.Value = 0
                pbStatus.Maximum = 100000
                lblpbStatusPercent.Text = "0%"
                pbOverallStatus.Value = 30
                lblpbOverallStatusPercent.Text = "60%"
                addStatus(" ")
                addStatus("Installing builds...", True)
                Me.Text = "LoLFlavor Sync: Installing"
                installThread.Start()
            Case 4 'Cleanup
                pbStatus.Value = 0
                pbStatus.Maximum = 100000
                lblpbStatusPercent.Text = "0%"
                pbOverallStatus.Value = 40
                lblpbOverallStatusPercent.Text = "80%"
                addStatus(" ")
                addStatus("Finalizing...", True)
                Me.Text = "LoLFlavor Sync: Finalizing"
                cleanupThread.Start()
            Case 5 'Complete
                finished = True
                pbStatus.Value = 100
                pbStatus.Maximum = 100
                lblpbStatusPercent.Text = "100%"
                pbOverallStatus.Value = 50
                lblpbOverallStatusPercent.Text = "100%"
                addStatus(" ")
                addStatus("Builds Installed!", True)
                Me.Text = "LoLFlavor Sync"
                Me.Cursor = Cursors.Arrow
                btnCancel.Text = "Quit"
            Case Else
                Exit Sub
        End Select
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
        prepareThread.Abort()
        downloadThread.Abort()
        installThread.Abort()
        cleanupThread.Abort()
    End Sub

    Private Sub frmFlavorSyncDownload_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If finished Then
            Environment.Exit(0)
        Else
            frmFlavorSyncMain.formFlavorSyncMainEnabled = True
        End If
    End Sub
End Class