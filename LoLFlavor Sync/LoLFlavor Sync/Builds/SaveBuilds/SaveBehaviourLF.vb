Imports System.IO
Imports LoLFlavor_Sync.Lib
Imports LoLFlavor_Sync.DLBuilds

Namespace Global.LoLFlavor_Sync.SaveBuilds
    Public Class SaveBehaviourLF : Implements ISaveBehaviour
        Private _SaveInfo As ISaveInfo

        Public ReadOnly Property GetSaveInfo As ISaveInfo
            Get
                Return _SaveInfo
            End Get
        End Property

        Sub New(ByRef SaveInfo As ISaveInfo)
            Me._SaveInfo = SaveInfo
        End Sub

        Public Sub SaveBuild(ByRef build As Build) Implements ISaveBehaviour.SaveBuild
            Using fs As New FileStream(_SaveInfo.GetFullPath(build.GetChampion, build.GetLaneType), FileMode.Create, FileAccess.ReadWrite)
                Dim enc As New System.Text.UTF8Encoding(True, False)
                Dim data As Byte() = enc.GetBytes(build.GetBuildText)
                fs.Write(data, 0, data.Count)
                fs.Close()
            End Using
        End Sub
    End Class
End Namespace
