Imports System.Security
Imports System.Runtime.Serialization

Namespace Global.LoLFlavor_Sync.Domain
    <Serializable()>
    Public Class DownloadNotCompletedException : Inherits System.Exception
        ''' <summary>
        ''' Initializes a new instance of the <see cref="DownloadNotCompletedException"/> class.
        ''' </summary>
        Public Sub New()
            MyBase.New()
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DownloadNotCompletedException"/> class
        ''' with the specified error message.
        ''' </summary>
        ''' <param name="message">The message that describes the error.</param>
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DownloadNotCompletedException"/> class
        ''' with the specified error message and a reference to the inner
        ''' exception that is the cause of this exception.
        ''' </summary>
        ''' <param name="message">The message that describes the error.</param>
        ''' <param name="innerException">The exception that is the cause of the
        ''' current exception, or a null reference if no inner exception is
        ''' specified</param>
        Public Sub New(ByVal message As String, ByVal innerexception As System.Exception)
            MyBase.New(message, innerexception)
        End Sub

        ' Constructor required for serialization
        <SecuritySafeCritical()>
        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
    End Class
End Namespace
