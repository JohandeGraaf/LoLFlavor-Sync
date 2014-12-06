Namespace Global.LoLFlavor_Sync.Library
    Public Class Champion
        Private _Name As String
        Private _DisplayName As String

        Private _SourceUrlFormat As String = "http://www.lolflavor.com/champions/{Champion}/Recommended/{Champion}_{Lane}_scrape.json"
        Private _DestinationPath As String = "\Config\Champions\{Champion}\Recommended\"
        Private _DestinationFile As String = "{Champion}_{Lane}_scrape.json"

        Public Shared Property ChampionVar As String = "{Champion}"

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
        ''' Gets and sets the URL where the build needs to be downloaded.
        ''' </summary>
        ''' <param name="orig">
        ''' Orig [False] : 'Champion.ChampionVar' will be replaced with Champion.Name
        ''' Orig [True]  : Returns the original value of SourceUrl
        ''' </param>
        Public Property SourceUrl(ByVal orig As Boolean) As String
            Get
                If orig Then
                    Return _SourceUrlFormat
                Else
                    Return _SourceUrlFormat.Replace(ChampionVar, _Name)
                End If
            End Get
            Set(value As String)
                _SourceUrlFormat = value
            End Set
        End Property
        ''' <summary>
        ''' Gets and sets the path where the build needs to be saved.
        ''' </summary>
        ''' <param name="orig">
        ''' Orig [False] : 'Champion.ChampionVar' will be replaced with Champion.Name
        ''' Orig [True]  : Returns the original value of DestinationPath
        ''' </param>
        Public Property DestinationPath(ByVal orig As Boolean) As String
            Get

                Return _DestinationPath.Replace(ChampionVar, _Name)
            End Get
            Set(value As String)
                _DestinationPath = value
            End Set
        End Property
        ''' <summary>
        ''' Gets and sets the filename of the build.
        ''' </summary>
        ''' <param name="orig">
        ''' Orig [False] : 'Champion.ChampionVar' will be replaced with Champion.Name
        ''' Orig [True]  : Returns the original value of DestinationFile
        ''' </param>
        Public Property DestinationFile(ByVal orig As Boolean) As String
            Get
                Return _DestinationFile.Replace(ChampionVar, _Name)
            End Get
            Set(value As String)
                _DestinationFile = value
            End Set
        End Property

        ''' <summary>
        ''' Returns a string that represents the current object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class
End Namespace
