Imports System.IO
Namespace Global.LoLFlavor_Sync.Library
    Public Class DownloadChampion : Implements IDisposable
        Private _Champ As Champion
        Private srcUrl As String
        Private destPathBase As String
        Private destPath As String
        Private destFile As String
        Private builds As New List(Of Array)

        Public Enum laneType As Integer
            lane
            jungle
            support
            aram
        End Enum

        Sub New(ByRef _ch As Champion, ByVal _SourceUrl As String, ByVal _DestinationPathBase As String, ByVal _DestinationPath As String, ByVal _DestinationFile As String)
            Me._Champ = _ch
            Me.srcUrl = _SourceUrl
            Me.destPathBase = _DestinationPathBase
            Me.destPath = _DestinationPath
            Me.destFile = _DestinationFile
        End Sub

        Public ReadOnly Property Champ As Champion
            Get
                Return _Champ
            End Get
        End Property

        Public Function GetSourceUrl() As String
            Return Me.srcUrl.Replace(Properties.ChampionVar, _Champ.Name)
        End Function

        Public Function GetSourceUrl(ByVal lane As laneType) As String
            Return GetSourceUrl().Replace(Properties.LaneVar, lane.ToString())
        End Function

        Public Function GetDestinationPathBase() As String
            Return Me.destPathBase.Replace(Properties.ChampionVar, _Champ.Name)
        End Function

        Public Function GetDestinationPathBase(ByVal lane As laneType) As String
            Return GetDestinationPathBase().Replace(Properties.LaneVar, lane.ToString())
        End Function

        Public Function GetDestinationPath() As String
            Return Me.destPath.Replace(Properties.ChampionVar, _Champ.Name)
        End Function

        Public Function GetDestinationPath(ByVal lane As laneType) As String
            Return GetDestinationPath().Replace(Properties.LaneVar, lane.ToString())
        End Function

        Public Function GetDestinationFile() As String
            Return Me.destFile.Replace(Properties.ChampionVar, _Champ.Name)
        End Function

        Public Function GetDestinationFile(ByVal lane As laneType) As String
            Return GetDestinationFile().Replace(Properties.LaneVar, lane.ToString())
        End Function

        Public Function GetFullPath() As String
            Return GetDestinationPathBase() & GetDestinationPath() & GetDestinationFile()
        End Function

        Public Function GetFullPath(ByVal lane As laneType) As String
            Return GetFullPath().Replace(Properties.LaneVar, lane.ToString())
        End Function

        Public Sub DownloadBuild(ByVal lane As laneType)
            Dim URI As New System.Uri(GetSourceUrl(lane), System.UriKind.Absolute)
            Using client As New System.Net.WebClient
                Using stream As New StreamReader(client.OpenRead(URI), System.Text.Encoding.UTF8)
                    Dim bld As String = stream.ReadToEnd()
                    builds.Add({lane, bld})
                End Using
            End Using
        End Sub

        Public Sub SaveBuilds()
            For Each objArr As Array In builds
                Try
                    Dim fs As New FileStream(GetFullPath(objArr(0)), FileMode.Create, FileAccess.ReadWrite)
                    Dim enc As New System.Text.UTF8Encoding(True, False)
                    Dim data As Byte() = enc.GetBytes(objArr(1))
                    fs.Write(data, 0, data.Count)
                    fs.Close()
                Catch : End Try
            Next
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
End Namespace
