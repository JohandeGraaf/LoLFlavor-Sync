Imports Newtonsoft.Json

Namespace Global.LoLFlavor_Sync.Domain
    Public Class Champion
        Private Shared _champions As List(Of Champion) = New List(Of Champion)(
            New Champion() {
                New Champion("Aatrox"),
                New Champion("Ahri"),
                New Champion("Akali"),
                New Champion("Alistar"),
                New Champion("Amumu"),
                New Champion("Anivia"),
                New Champion("Annie"),
                New Champion("Ashe"),
                New Champion("AurelionSol", "Aurelion Sol"),
                New Champion("Azir"),
                New Champion("Bard"),
                New Champion("Blitzcrank"),
                New Champion("Brand"),
                New Champion("Braum"),
                New Champion("Caitlyn"),
                New Champion("Camille"),
                New Champion("Cassiopeia"),
                New Champion("Chogath", "Cho'Gath"),
                New Champion("Corki"),
                New Champion("Darius"),
                New Champion("Diana"),
                New Champion("Draven"),
                New Champion("DrMundo", "Dr. Mundo"),
                New Champion("Ekko"),
                New Champion("Elise"),
                New Champion("Evelynn"),
                New Champion("Ezreal"),
                New Champion("FiddleSticks", "Fiddlesticks"),
                New Champion("Fiora"),
                New Champion("Fizz"),
                New Champion("Galio"),
                New Champion("Gangplank"),
                New Champion("Garen"),
                New Champion("Gnar"),
                New Champion("Gragas"),
                New Champion("Graves"),
                New Champion("Hecarim"),
                New Champion("Heimerdinger"),
                New Champion("Illaoi"),
                New Champion("Irelia"),
                New Champion("Ivern"),
                New Champion("Janna"),
                New Champion("JarvanIV", "Jarvan IV"),
                New Champion("Jax"),
                New Champion("Jayce"),
                New Champion("Jinx"),
                New Champion("Jhin"),
                New Champion("Kalista"),
                New Champion("Karma"),
                New Champion("Karthus"),
                New Champion("Kassadin"),
                New Champion("Katarina"),
                New Champion("Kayle"),
                New Champion("Kennen"),
                New Champion("Khazix", "Kha'Zix"),
                New Champion("Kindred"),
                New Champion("Kled"),
                New Champion("KogMaw", "Kog'Maw"),
                New Champion("Leblanc", "LeBlanc"),
                New Champion("LeeSin", "Lee Sin"),
                New Champion("Leona"),
                New Champion("Lissandra"),
                New Champion("Lucian"),
                New Champion("Lulu"),
                New Champion("Lux"),
                New Champion("Malphite"),
                New Champion("Malzahar"),
                New Champion("Maokai"),
                New Champion("MasterYi", "Master Yi"),
                New Champion("MissFortune", "Miss Fortune"),
                New Champion("MonkeyKing", "Wukong"),
                New Champion("Mordekaiser"),
                New Champion("Morgana"),
                New Champion("Nami"),
                New Champion("Nasus"),
                New Champion("Nautilus"),
                New Champion("Nidalee"),
                New Champion("Nocturne"),
                New Champion("Nunu"),
                New Champion("Olaf"),
                New Champion("Orianna"),
                New Champion("Pantheon"),
                New Champion("Poppy"),
                New Champion("Quinn"),
                New Champion("Rakan"),
                New Champion("Rammus"),
                New Champion("Reksai", "Rek'Sai"),
                New Champion("Renekton"),
                New Champion("Rengar"),
                New Champion("Riven"),
                New Champion("Rumble"),
                New Champion("Ryze"),
                New Champion("Sejuani"),
                New Champion("Shaco"),
                New Champion("Shen"),
                New Champion("Shyvana"),
                New Champion("Singed"),
                New Champion("Sion"),
                New Champion("Sivir"),
                New Champion("Skarner"),
                New Champion("Sona"),
                New Champion("Soraka"),
                New Champion("Swain"),
                New Champion("Syndra"),
                New Champion("TahmKench", "Tahm Kench"),
                New Champion("Taliyah"),
                New Champion("Talon"),
                New Champion("Taric"),
                New Champion("Teemo"),
                New Champion("Thresh"),
                New Champion("Tristana"),
                New Champion("Trundle"),
                New Champion("Tryndamere"),
                New Champion("TwistedFate", "Twisted Fate"),
                New Champion("Twitch"),
                New Champion("Udyr"),
                New Champion("Urgot"),
                New Champion("Varus"),
                New Champion("Vayne"),
                New Champion("Veigar"),
                New Champion("Velkoz", "Vel'Koz"),
                New Champion("Vi"),
                New Champion("Viktor"),
                New Champion("Vladimir"),
                New Champion("Volibear"),
                New Champion("Warwick"),
                New Champion("Xayah"),
                New Champion("Xerath"),
                New Champion("XinZhao", "Xin Zhao"),
                New Champion("Yasuo"),
                New Champion("Yorick"),
                New Champion("Zac"),
                New Champion("Zed"),
                New Champion("Ziggs"),
                New Champion("Zilean"),
                New Champion("Zyra")
            }
        )

        Public Shared ReadOnly Property Champions As List(Of Champion)
            Get
                Return _champions
            End Get
        End Property


        Private _Name As String
        Private _DisplayName As String

        Sub New(ByVal Name As String)
            Me._Name = Name
        End Sub

        <JsonConstructor>
        Sub New(ByVal Name As String, ByVal DisplayName As String)
            Me._Name = Name
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
