Public Class frmFlavorSyncLoad
    Private LoLPath As String
    Public version As String = "1.6.1"

    Public champs() As String = {"Aatrox", "Ahri", "Akali", "Alistar", "Amumu", "Anivia", "Annie", "Ashe", "Azir", "Blitzcrank", "Brand", "Braum", "Caitlyn", "Cassiopeia", "Chogath", "Corki", "Darius", "Diana", "DrMundo", "Draven", "Elise", "Evelynn", "Ezreal", "FiddleSticks", "Fiora", "Fizz", "Galio", "Gangplank", "Garen", "Gnar", "Gragas", "Graves", "Hecarim", "Heimerdinger", "Irelia", "Janna", "JarvanIV", "Jax", "Jayce", "Jinx", "Kalista", "Karma", "Karthus", "Kassadin", "Katarina", "Kayle", "Kennen", "Khazix", "KogMaw", "Leblanc", "LeeSin", "Leona", "Lissandra", "Lucian", "Lulu", "Lux", "Malphite", "Malzahar", "Maokai", "MasterYi", "MissFortune", "MonkeyKing", "Mordekaiser", "Morgana", "Nami", "Nasus", "Nautilus", "Nidalee", "Nocturne", "Nunu", "Olaf", "Orianna", "Pantheon", "Poppy", "Quinn", "Rammus", "Renekton", "Rengar", "Riven", "Rumble", "Ryze", "Sejuani", "Shaco", "Shen", "Shyvana", "Singed", "Sion", "Sivir", "Skarner", "Sona", "Soraka", "Swain", "Syndra", "Talon", "Taric", "Teemo", "Thresh", "Tristana", "Trundle", "Tryndamere", "TwistedFate", "Twitch", "Udyr", "Urgot", "Varus", "Vayne", "Veigar", "Velkoz", "Vi", "Viktor", "Vladimir", "Volibear", "Warwick", "Xerath", "XinZhao", "Yasuo", "Yorick", "Zac", "Zed", "Ziggs", "Zilean", "Zyra"}

    Public Property sourceLoLFlavor As Boolean
        Get
            If String.IsNullOrWhiteSpace(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\FlavorSync", "sourceLoLFlavor", "")) Then
                Return True
            Else
                Return My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\FlavorSync", "sourceLoLFlavor", "")
            End If
        End Get
        Set(value As Boolean)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\FlavorSync", "sourceLoLFlavor", value, Microsoft.Win32.RegistryValueKind.String)
        End Set
    End Property

    Public Property getLoLPath As String
        Get
            Return LoLPath
        End Get
        Set(value As String)
            LoLPath = value
            fbdLoLPath.SelectedPath = value
            txtLoLPath.Text = value
        End Set
    End Property

    Public Property skipForm As Boolean
        Get
            If String.IsNullOrWhiteSpace(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\FlavorSync", "skip", "")) OrElse Not CBool(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\FlavorSync", "skip", "")) Then
                Return False
            Else
                Return CBool(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\FlavorSync", "skip", ""))
            End If
        End Get
        Set(value As Boolean)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\FlavorSync", "skip", value, Microsoft.Win32.RegistryValueKind.String)
        End Set
    End Property

    Private Sub frmFlavorSyncLoad_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If detectLoLPath() Then
            If skipForm Then
                Me.Hide()
                frmFlavorSyncMain.Show()
                frmFlavorSyncMain.Focus()
            Else
                chkSkip.Enabled = True
                ActiveControl = btnConfirm
            End If
        Else
            ActiveControl = btnBrowse
        End If
    End Sub

    Public Function checkLoLPath(ByVal path As String) As Boolean
        If My.Computer.FileSystem.DirectoryExists(path & "\RADS") And (My.Computer.FileSystem.DirectoryExists(path & "\Config") Or My.Computer.FileSystem.FileExists(path & "\lol.launcher.exe") Or My.Computer.FileSystem.FileExists(path & "\lol.launcher.admin.exe")) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function detectLoLPath() As Boolean
        Dim LoLpth1 As String
        Dim LoLpth2 As String
        Dim LoLpth3 As String
        Dim LoLpth4 As String
        If Environment.Is64BitOperatingSystem Then
            'Keyname: Path, Value: C:\Riot Games\League of Legends\
            LoLpth1 = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Riot Games\League of Legends", "Path", Nothing)
            'Keyname: LocalRootFolder, Value: C:/Riot Games/League of Legends/RADS
            LoLpth2 = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Riot Games\RADS", "LocalRootFolder", Nothing)
            'Keyname: LocalRootFolder, Value: C:/Riot Games/League of Legends/RADS
            LoLpth3 = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Classes\VirtualStore\MACHINE\SOFTWARE\Wow6432Node\Riot Games\RADS", "LocalRootFolder", Nothing)
            'Keyname: LocalRootFolder, Value: C:/Riot Games/League of Legends/RADS
            LoLpth4 = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Wow6432Node\Riot Games\RADS", "LocalRootFolder", Nothing)
        Else
            'Keyname: Path, Value: C:\Riot Games\League of Legends\
            LoLpth1 = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Riot Games\League of Legends", "Path", Nothing)
            'Keyname: LocalRootFolder, Value: C:/Riot Games/League of Legends/RADS
            LoLpth2 = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Riot Games\RADS", "LocalRootFolder", Nothing)
            'Keyname: LocalRootFolder, Value: C:/Riot Games/League of Legends/RADS
            LoLpth3 = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Classes\VirtualStore\MACHINE\SOFTWARE\Riot Games\RADS", "LocalRootFolder", Nothing)
            'Keyname: LocalRootFolder, Value: C:/Riot Games/League of Legends/RADS
            LoLpth4 = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Riot Games\RADS", "LocalRootFolder", Nothing)
        End If
        If Not String.IsNullOrWhiteSpace(LoLpth1) Then
            LoLpth1 = LoLpth1.Replace("League of Legends\", "League of Legends")
        End If
        If Not String.IsNullOrWhiteSpace(LoLpth2) Then
            LoLpth2 = LoLpth2.Replace("/", "\")
            LoLpth2 = LoLpth2.Replace("\RADS", "\")
        End If
        If Not String.IsNullOrWhiteSpace(LoLpth3) Then
            LoLpth3 = LoLpth3.Replace("/", "\")
            LoLpth3 = LoLpth3.Replace("\RADS", "\")
        End If
        If Not String.IsNullOrWhiteSpace(LoLpth4) Then
            LoLpth4 = LoLpth4.Replace("/", "\")
            LoLpth4 = LoLpth4.Replace("\RADS", "\")
        End If
        If checkLoLPath("C:\Riot Games\League of Legends") Then
            getLoLPath = "C:\Riot Games\League of Legends"
            Return True
        ElseIf Not String.IsNullOrWhiteSpace(LoLpth1) AndAlso checkLoLPath(LoLpth1) Then
            getLoLPath = LoLpth1
            Return True
        ElseIf Not String.IsNullOrWhiteSpace(LoLpth2) AndAlso checkLoLPath(LoLpth2) Then
            getLoLPath = LoLpth2
            Return True
        ElseIf Not String.IsNullOrWhiteSpace(LoLpth3) AndAlso checkLoLPath(LoLpth3) Then
            getLoLPath = LoLpth3
            Return True
        ElseIf Not String.IsNullOrWhiteSpace(LoLpth4) AndAlso checkLoLPath(LoLpth4) Then
            getLoLPath = LoLpth4
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        If String.IsNullOrWhiteSpace(getLoLPath) Then fbdLoLPath.SelectedPath = ""
        fbdLoLPath.ShowDialog()
        getLoLPath = fbdLoLPath.SelectedPath
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If checkLoLPath(getLoLPath) Then
            If chkSkip.Checked Then
                skipForm = True
            ElseIf Not chkSkip.Checked Then
                skipForm = False
            End If
            Me.Hide()
            frmFlavorSyncMain.Show()
        Else
            MessageBox.Show("Incorrect directory specified. Please make sure you are selecting your League of Legends directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub frmFlavorSyncLoad_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Environment.Exit(0)
    End Sub

    Private Sub frmFlavorSyncLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class