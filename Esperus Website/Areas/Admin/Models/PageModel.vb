Namespace Areas.Admin.Models
    Public Class PageModel : Inherits BaseEditorModel
        Public Property PageLink As String
        Public Property DisplayNavbar As Boolean
        Public Property DisplayID As String

        Public Sub New()
        End Sub

        Public Sub New(_pageKey As String, _pageName As String)
            Key = _pageKey
            Name = _pageName
        End Sub

        Public Sub New(_pageKey As String, _pageName As String, _displayOrder As String)
            Key = _pageKey
            Name = _pageName
            Order = _displayOrder
        End Sub
    End Class
End Namespace
