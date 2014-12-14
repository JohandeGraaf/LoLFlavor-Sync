Imports Microsoft.Win32
Namespace Global.LoLFlavor_Sync.Library
    Module Properties
        Public Property AllChampions As List(Of Champion)

        Public Property VersionLocal As String = "1.7.0"
        Public Property VersionOnline As String
        Public Property VersionUrl As String = "https://raw.githubusercontent.com/Ampersand0/LoLFlavor-Sync/master/LoLFlavor%20Sync.version?rand=" & (New Random).Next(0, 9999)
        Public Property VersionFileName As String = "LoLFlavorSync.version"

        Public Property LoLPath As String

        Public Property RegKey As RegistryKey = Registry.CurrentUser
        Public Property RegPath As String = "Software\FlavorSync"

        Public Property TempDirBuilds As String = Environment.GetEnvironmentVariable("TEMP") & "\FlavorSyncTemp"
        Public Property TempDirVersion As String = Environment.GetEnvironmentVariable("TEMP") & "\FlavorSyncVersion"

        Public Property UrlExecutable As String = "http://lolflavorsync.mcpvp.eu"
        Public Property UrlBoLProfile As String = "http://botoflegends.com/forum/user/59209-ampersand/"
        Public Property UrlSkype As String = "skype:Johan_degraaf95?chat"
        Public Property UrlGitHub As String = "https://github.com/Ampersand0"

        Public Property Changelog As String = _
            "1.0.0 - Release." & Environment.NewLine & _
            "1.1.0 - Fixed some bugs." & Environment.NewLine & _
            "1.2.0 - Added some settings." & Environment.NewLine & _
            Environment.NewLine & _
            "1.5.0 - Changed the download method to improve performance." & Environment.NewLine & _
            "1.6.0 - Added settings to add champions and add a custom source for builds." & Environment.NewLine & _
            "1.6.1 - Added Azir and Gnar." & Environment.NewLine & _
            "1.6.2 - Added update message." & Environment.NewLine & _
            "1.6.3 - Added Kalista." & Environment.NewLine & _
            "1.6.4 - Added Rek'Sai." & Environment.NewLine & _
            "1.7.0 - Recoded almost everything; improved performance; less bugs."
        Public Property About As String = _
            "LoLFlavor Sync - Version " & VersionLocal & Environment.NewLine & _
            Environment.NewLine & _
            "Copyright © 2014 - Johan de Graaf"

        Public Property OptionSkipForm As Boolean
            Get
                Try
                    Using key As RegistryKey = RegKey.OpenSubKey(RegPath)
                        Return Convert.ToBoolean(key.GetValue("skip"))
                    End Using
                Catch ex As Exception
                    Return Nothing
                End Try
            End Get
            Set(value As Boolean)
                CreateSubKey()
                Try
                    Using key As RegistryKey = RegKey.OpenSubKey(RegPath, True)
                        key.SetValue("skip", value.ToString(), RegistryValueKind.String)
                    End Using
                Catch ex As UnauthorizedAccessException
                    MessageBox.Show("Error: Not enough permissions to write to " & RegKey.ToString() & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End Set
        End Property

        Public Property OptionLastUsed As Date
            Get
                Try
                    Using key As RegistryKey = RegKey.OpenSubKey(RegPath)
                        Return Date.FromBinary(key.GetValue("lastUsedBinary"))
                    End Using
                Catch ex As Exception
                    Return Nothing
                End Try
            End Get
            Set(value As Date)
                CreateSubKey()
                Try
                    Using key As RegistryKey = RegKey.OpenSubKey(RegPath, True)
                        key.SetValue("lastUsedBinary", value.ToBinary(), RegistryValueKind.QWord)
                    End Using
                Catch ex As UnauthorizedAccessException
                    MessageBox.Show("Error: Not enough permissions to write to " & RegKey.ToString() & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End Set
        End Property

        Public Property OptionVersionCheckDisabled As Boolean
            Get
                Try
                    Using key As RegistryKey = RegKey.OpenSubKey(RegPath)
                        Return Convert.ToBoolean(key.GetValue("versionCheckDisabled"))
                    End Using
                Catch ex As Exception
                    Return Nothing
                End Try
            End Get
            Set(value As Boolean)
                CreateSubKey()
                Try
                    Using key As RegistryKey = RegKey.OpenSubKey(RegPath, True)
                        key.SetValue("versionCheckDisabled", value.ToString(), RegistryValueKind.String)
                    End Using
                Catch ex As UnauthorizedAccessException
                    MessageBox.Show("Error: Not enough permissions to write to " & RegKey.ToString() & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End Set
        End Property

        Public Property OptionLoLPath As String
            Get
                Try
                    Using key As RegistryKey = RegKey.OpenSubKey(RegPath)
                        Return key.GetValue("loLPath")
                    End Using
                Catch ex As Exception
                    Return Nothing
                End Try
            End Get
            Set(value As String)
                CreateSubKey()
                Try
                    Using key As RegistryKey = RegKey.OpenSubKey(RegPath, True)
                        key.SetValue("loLPath", value, RegistryValueKind.String)
                    End Using
                Catch ex As UnauthorizedAccessException
                    MessageBox.Show("Error: Not enough permissions to write to " & RegKey.ToString() & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End Set
        End Property

        Private Sub CreateSubKey()
            Using key As RegistryKey = RegKey
                key.CreateSubKey(RegPath, RegistryKeyPermissionCheck.ReadWriteSubTree)
            End Using
        End Sub

        Public Sub DeleteRegistryKeys()
            Using key As RegistryKey = RegKey
                key.DeleteSubKeyTree(RegPath, False)
            End Using
        End Sub

        Public Sub DelFolderContent(ByVal path As String)
            DelFolderContent(path, False)
        End Sub

        Public Sub DelFolderContent(ByVal path As String, ByVal deleteRootDirectory As Boolean)
            DelFolderContent(path, deleteRootDirectory, False, 0, Sub(x As Integer) x = x, False, Sub(x As String) x = x)
        End Sub

        Public Sub DelFolderContent(ByVal path As String, ByVal deleteRootDirectory As Boolean, ByVal withProgressBar As Boolean, ByVal pbIncrement As Integer, ByRef addPB As Action(Of Integer), ByVal withStatus As Boolean, ByRef addStatus As Action(Of String))
            If System.IO.Directory.Exists(path) Then
                For Each foundFile As String In Enumerable.Reverse(My.Computer.FileSystem.GetFiles(path, FileIO.SearchOption.SearchAllSubDirectories))
                    My.Computer.FileSystem.DeleteFile(foundFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                    If withStatus Then addStatus("Deleted file: " & foundFile)
                    If withProgressBar Then addPB(pbIncrement)
                Next
                For Each foundFolder As String In Enumerable.Reverse(My.Computer.FileSystem.GetDirectories(path, FileIO.SearchOption.SearchAllSubDirectories))
                    My.Computer.FileSystem.DeleteDirectory(foundFolder, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                    If withStatus Then addStatus("Deleted folder: " & foundFolder)
                    If withProgressBar Then addPB(pbIncrement)
                Next
                If deleteRootDirectory Then
                    My.Computer.FileSystem.DeleteDirectory(path, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                    If withStatus Then addStatus("Deleted folder: " & path)
                End If
            End If
        End Sub

        Public Function ReadFile(ByVal path As String) As String
            Dim fs As New System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate)
            Dim fileBuffer(fs.Length - 1) As Byte
            fs.Read(fileBuffer, 0, fs.Length)
            fs.Dispose()
            fs.Close()
            Return System.Text.Encoding.UTF8.GetString(fileBuffer)
        End Function

        Public Function ValidLoLPath(ByVal path As String) As Boolean
            If My.Computer.FileSystem.DirectoryExists(path & "\RADS") And (My.Computer.FileSystem.DirectoryExists(path & "\Config") Or My.Computer.FileSystem.FileExists(path & "\lol.launcher.exe") Or My.Computer.FileSystem.FileExists(path & "\lol.launcher.admin.exe")) Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function DetectLoLPath() As String
            Dim keys32 As List(Of Func(Of String)) = New List(Of Func(Of String))({ _
            Function() Registry.LocalMachine.OpenSubKey("SOFTWARE\Riot Games\League of Legends").GetValue("Path").Replace("League of Legends\", "League of Legends"), _
            Function() Registry.LocalMachine.OpenSubKey("SOFTWARE\Riot Games\RADS").GetValue("LocalRootFolder").Replace("/", "\").Replace("\RADS", "\"), _
            Function() Registry.CurrentUser.OpenSubKey("Software\Classes\VirtualStore\MACHINE\SOFTWARE\Riot Games\RAD").GetValue("LocalRootFolder").Replace("/", "\").Replace("\RADS", "\"), _
            Function() Registry.CurrentUser.OpenSubKey("Software\Riot Games\RADS").GetValue("LocalRootFolder").Replace("/", "\").Replace("\RADS", "\")})

            Dim keys64 As List(Of Func(Of String)) = New List(Of Func(Of String))({ _
            Function() Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Riot Games\League of Legends").GetValue("Path").Replace("League of Legends\", "League of Legends"), _
            Function() Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Riot Games\RADS").GetValue("LocalRootFolder").Replace("/", "\").Replace("\RADS", "\"), _
            Function() Registry.CurrentUser.OpenSubKey("Software\Classes\VirtualStore\MACHINE\SOFTWARE\Wow6432Node\Riot Games\RADS").GetValue("LocalRootFolder").Replace("/", "\").Replace("\RADS", "\"), _
            Function() Registry.CurrentUser.OpenSubKey("Software\Wow6432Node\Riot Games\RADS").GetValue("LocalRootFolder").Replace("/", "\").Replace("\RADS", "\")})

            If ValidLoLPath("C:\Riot Games\League of Legends") Then
                Return "C:\Riot Games\League of Legends"
            End If

            For Each objFunc As Func(Of String) In keys32
                Try
                    Dim str As String = objFunc()
                    If Not String.IsNullOrWhiteSpace(str) Then
                        str = str.TrimEnd({Convert.ToChar("\")})
                        If ValidLoLPath(str) Then Return str
                    End If
                Catch : End Try
            Next

            If Environment.Is64BitOperatingSystem Then
                For Each objFunc As Func(Of String) In keys64
                    Try
                        Dim str As String = objFunc()
                        If Not String.IsNullOrWhiteSpace(str) Then
                            str = str.TrimEnd({Convert.ToChar("\")})
                            If ValidLoLPath(str) Then Return str
                        End If
                    Catch : End Try
                Next
            End If

            Return Nothing
        End Function
    End Module
End Namespace
