Imports System.Drawing.Text
Imports System.IO
Imports LoLFlavor_Sync.Domain
Imports Microsoft.Win32

Public Class LoLPath
    Public Shared ReadOnly EMPTY As LoLPath = New LoLPath("")

    Public Shared Function Detect() As LoLPath
        Dim lolpath1 As LoLPath = New LoLPath(GlobalVars.OptionLoLPath)
        Dim lolpath2 As LoLPath = DetectPath()

        If lolpath1.IsValid() Then
            Return lolpath1
        ElseIf lolpath2.IsValid() Then
            Return lolpath2
        End If

        Return EMPTY
    End Function

    Private Shared Function DetectPath() As LoLPath
        If GlobalVars.Garena Then
            Return DetectGarenaPath()
        Else
            Return DetectLoLPath()
        End If
    End Function

    Private Shared Function DetectGarenaPath() As LoLPath
        Dim lolPath32 = ReadRegistry("SOFTWARE\Garena")

        If lolPath32.IsValid() Then
            Return lolPath32
        End If

        If Environment.Is64BitOperatingSystem Then
            Dim lolPath64 = ReadRegistry("SOFTWARE\Wow6432Node\Garena")

            If lolPath64.IsValid() Then
                Return lolPath64
            End If
        End If
        Return EMPTY
    End Function

    Private Shared Function ReadRegistry(root As String) As LoLPath
        Try
            For Each subKey In Registry.LocalMachine.OpenSubKey(root).GetSubKeyNames
                Using sk As RegistryKey = Registry.LocalMachine.OpenSubKey(root & subKey)
                    Dim val As String = sk.GetValue("Path")
                    Dim beginIndex As Integer = val.IndexOf("\GameData\Apps")
                    If beginIndex < 0 Then Continue For
                    Dim pt As String = val.Remove(beginIndex)

                    Dim lolPath = New LoLPath(pt)

                    If lolPath.IsValid() Then
                        Return lolPath
                    End If
                End Using
            Next
        Catch
        End Try
        Return EMPTY
    End Function

    Private Shared Function DetectLoLPath() As LoLPath
        Dim keys32 = New List(Of Func(Of String))({
            Function() Registry.LocalMachine.OpenSubKey("SOFTWARE\Riot Games\League of Legends").GetValue("Path").Replace("League of Legends\", "League of Legends"),
            Function() Registry.LocalMachine.OpenSubKey("SOFTWARE\Riot Games\RADS").GetValue("LocalRootFolder").Replace("/", "\").Replace("\RADS", "\"),
            Function() Registry.CurrentUser.OpenSubKey("Software\Classes\VirtualStore\MACHINE\SOFTWARE\Riot Games\RAD").GetValue("LocalRootFolder").Replace("/", "\").Replace("\RADS", "\"),
            Function() Registry.CurrentUser.OpenSubKey("Software\Riot Games\RADS").GetValue("LocalRootFolder").Replace("/", "\").Replace("\RADS", "\")})

        Dim keys64 = New List(Of Func(Of String))({
            Function() Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Riot Games\League of Legends").GetValue("Path").Replace("League of Legends\", "League of Legends"),
            Function() Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Riot Games\RADS").GetValue("LocalRootFolder").Replace("/", "\").Replace("\RADS", "\"),
            Function() Registry.CurrentUser.OpenSubKey("Software\Classes\VirtualStore\MACHINE\SOFTWARE\Wow6432Node\Riot Games\RADS").GetValue("LocalRootFolder").Replace("/", "\").Replace("\RADS", "\"),
            Function() Registry.CurrentUser.OpenSubKey("Software\Wow6432Node\Riot Games\RADS").GetValue("LocalRootFolder").Replace("/", "\").Replace("\RADS", "\")})

        Dim lolPath = New LoLPath("C:\Riot Games\League of Legends")

        If lolPath.IsValid() Then
            Return lolPath
        End If

        For Each objFunc As Func(Of String) In keys32
            Try
                Dim str As String = objFunc()
                If Not String.IsNullOrWhiteSpace(str) Then
                    str = str.TrimEnd({Convert.ToChar("\")})
                    Dim path = New LoLPath(str)
                    If path.IsValid() Then
                        Return path
                    End If
                End If
            Catch
            End Try
        Next

        If Environment.Is64BitOperatingSystem Then
            For Each objFunc As Func(Of String) In keys64
                Try
                    Dim str As String = objFunc()
                    If Not String.IsNullOrWhiteSpace(str) Then
                        str = str.TrimEnd({Convert.ToChar("\")})
                        Dim path = New LoLPath(str)
                        If path.IsValid() Then
                            Return path
                        End If
                    End If
                Catch
                End Try
            Next
        End If
        Return EMPTY
    End Function

    Public ReadOnly Property Path As String

    Public Sub New(path As String)
        Me.Path = path
    End Sub

    Public Function IsValid() As Boolean
        If String.IsNullOrWhiteSpace(Path) Then
            Return False
        End If

        If GlobalVars.Garena Then
            Return Directory.Exists(Path & "\GameData") And (File.Exists(Path & "\im_installer.exe") Or File.Exists(Path & "\LoLLauncher.exe") Or File.Exists(Path & "\uninst.exe"))
        Else
            Return Directory.Exists(Path & "\RADS") And (Directory.Exists(Path & "\Config") Or File.Exists(Path & "\lol.launcher.exe") Or File.Exists(Path & "\lol.launcher.admin.exe"))
        End If
    End Function
End Class
