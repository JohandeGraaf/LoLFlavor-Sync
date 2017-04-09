Namespace Domain.Listeners
    Public Interface IStateChanged
        Sub OnTitleChange(title As String)
        Sub OnRegionChange(garena As Boolean)
        Sub OnLoLPathChange(lolpath As LoLPath)
    End Interface
End NameSpace