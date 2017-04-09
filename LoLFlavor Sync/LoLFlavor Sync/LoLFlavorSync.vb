Imports LoLFlavor_Sync.Domain
Imports LoLFlavor_Sync.Domain.Listeners

Public Class LoLFlavorSync
    Private stateChangedListeners As List(Of IStateChanged)
    Private _garena As Boolean
    Private _lolpath As LoLPath

    Public Sub New()
        stateChangedListeners = New List(Of IStateChanged)
        Garena = GlobalVars.OptionUseGarena
        _lolpath = LoLPath.Detect()
        GlobalVars.AllChampions = Champion.Champions
    End Sub

    Public Sub AddStateChangedListener(observer As IStateChanged)
        stateChangedListeners.Add(observer)
    End Sub

    Public Sub RemoveStateChangedListener(observer As IStateChanged)
        stateChangedListeners.Remove(observer)
    End Sub

    Public Sub Notify()
        NotifyTitleChange()
        NotifyRegionChange()
        NotifyLoLPathChange()
    End Sub

    Private Sub NotifyTitleChange()
        For Each observer As IStateChanged In stateChangedListeners
            observer.OnTitleChange(Title)
        Next
    End Sub

    Private Sub NotifyRegionChange()
        For Each observer As IStateChanged In stateChangedListeners
            observer.OnRegionChange(Garena)
        Next
    End Sub

    Private Sub NotifyLoLPathChange()
        For Each observer As IStateChanged In stateChangedListeners
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
End Class
