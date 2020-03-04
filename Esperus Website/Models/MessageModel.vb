Namespace Models
    Public Class MessageModel
        Public Property Type As MessageType
        Public Property SenderName As String
        Public Property SenderCompany As String
        Public Property SenderEmail As String
        Public Property SenderCallingCode As String
        Public Property SenderTelephone As String
        Public Property SenderExtension As String
        Public Property SenderInterest As String
        Public Property SenderReferer As String
        Public Property SenderMessage As String
        Public Property SenderSubject As String
        Public Property SenderMailingList As Boolean
    End Class

    Public Enum MessageType
        DemoRequest = 0
        ContactRequest = 1
    End Enum
End Namespace
