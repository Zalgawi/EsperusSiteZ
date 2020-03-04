Namespace Areas.Admin.Models
    Public Class ViewMessageModel
        Public Property ResponseHeading As String
        Public Property ResponseBody As String
        Public Property ResponseType As ViewMessageType

        Public Sub New()

        End Sub

        Public Sub New(heading As String, body As String, type As ViewMessageType)
            ResponseHeading = heading
            ResponseBody = body
            ResponseType = type
        End Sub
    End Class

    Public Enum ViewMessageType
        Warning = False
        Info = True
    End Enum
End Namespace
