Namespace Models
    Public Class Result
        Public Property Type As Boolean
        Public Property Heading As String
        Public Property Message As String

        Public Sub New()

        End Sub

        Public Sub New(_type As Boolean, _heading As String, _message As String)
            Type = _type
            Heading = _heading
            Message = _message
        End Sub
    End Class
End Namespace
