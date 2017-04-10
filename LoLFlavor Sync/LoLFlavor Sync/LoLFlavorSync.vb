Imports System.IO
Imports LoLFlavor_Sync.Domain
Imports LoLFlavor_Sync.Domain.Listeners
Imports Newtonsoft.Json

Public Class LoLFlavorSync
    Private _stateChangedListeners As List(Of IStateChanged)
    Private _garena As Boolean
    Private _lolpath As LoLPath
    Private _champions As List(Of Champion)

    Public Sub New()
        _stateChangedListeners = New List(Of IStateChanged)
        Garena = GlobalVars.OptionUseGarena
        _lolpath = LoLPath.Detect()

        Dim champions As List(Of Champion) = Nothing

        Dim loader = New FileLoader("https://raw.githubusercontent.com/JohandeGraaf/LoLFlavor-Sync/master/LoLFlavor%20Sync.champions?rand=" & (New Random).Next(0, 9999))
        loader.Load()
        If loader.Available Then
            Try
                Dim json = loader.Content
                champions = JsonConvert.DeserializeObject(Of List(Of Champion))(json)
            Catch ex As Exception
                MessageBox.Show("Failed to load champion list; using hardcoded list." & Environment.NewLine & Environment.NewLine & "Exception:" & Environment.NewLine & ex.Message,
                                "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If

        If champions Is Nothing OrElse champions.Count = 0 Then
            _champions = Champion.Champions
            GlobalVars.AllChampions = Champion.Champions
        Else
            _champions = champions
            GlobalVars.AllChampions = champions
        End If
    End Sub

    Public Sub AddStateChangedListener(observer As IStateChanged)
        _stateChangedListeners.Add(observer)
    End Sub

    Public Sub RemoveStateChangedListener(observer As IStateChanged)
        _stateChangedListeners.Remove(observer)
    End Sub

    Public Sub Notify()
        NotifyTitleChange()
        NotifyRegionChange()
        NotifyLoLPathChange()
    End Sub

    Private Sub NotifyTitleChange()
        For Each observer As IStateChanged In _stateChangedListeners
            observer.OnTitleChange(Title)
        Next
    End Sub

    Private Sub NotifyRegionChange()
        For Each observer As IStateChanged In _stateChangedListeners
            observer.OnRegionChange(Garena)
        Next
    End Sub

    Private Sub NotifyLoLPathChange()
        For Each observer As IStateChanged In _stateChangedListeners
            observer.OnLoLPathChange(LoLPath)
        Next
    End Sub

    Public ReadOnly Property Title As String
        Get
            If GlobalVars.Garena Then
                Return "LoLFlavor Sync " & GlobalVars.VersionLocal & " (Garena)"
            Else
                Return "LoLFlavor Sync " & GlobalVars.VersionLocal
            End If
        End Get
    End Property

    Public Property Garena As Boolean
        Get
            Return _garena
        End Get
        Set
            _garena = Value
            GlobalVars.Garena = Value
            GlobalVars.OptionUseGarena = Value

            NotifyRegionChange()
            NotifyTitleChange()
        End Set
    End Property

    Public Property LoLPath As LoLPath
        Get
            Return _lolpath
        End Get
        Set
            _lolpath = Value
            GlobalVars.LoLPath = Value

            If Value.IsValid() And Garena Then
                GlobalVars.DetectGarenaPath()
            End If

            NotifyLoLPathChange()
        End Set
    End Property

    Public ReadOnly Property Champions As List(Of Champion)
        Get
            Return _champions
        End Get
    End Property
End Class
