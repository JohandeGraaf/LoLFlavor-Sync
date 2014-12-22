Namespace Global.LoLFlavor_Sync.Library
    Public Class Champion
        Private _Name As String
        Private _DisplayName As String

        Sub New(ByVal ChampionName As String)
            Me._Name = ChampionName
        End Sub

        Sub New(ByVal ChampionName As String, ByVal DisplayName As String)
            Me._Name = ChampionName
            Me._DisplayName = DisplayName
        End Sub

        ''' <summary>
        ''' Returns the name of the champion
        ''' </summary>
        Public ReadOnly Property Name As String
            Get
                Return _Name
            End Get
        End Property
        ''' <summary>
        ''' Returns the displayname of the champion. If displayname is null returns name.
        ''' </summary>
        Public ReadOnly Property DisplayName As String
            Get
                If String.IsNullOrWhiteSpace(_DisplayName) Then
                    Return _Name
                Else
                    Return _DisplayName
                End If
            End Get
        End Property

        ''' <summary>
        ''' Returns a string that represents the current object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class
End Namespace
