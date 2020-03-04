Namespace Areas.Admin.Models
    Public Class TreeViewNodeModel
        Public Property text As String
        Public Property name As String
        Public Property order As Integer
        Public Property href As String
        Public Property selectable As String
        Public Property nodes As List(Of TreeViewNodeModel)
        Public Property state As TreeViewNodeStateModel
        Public Property tags As List(Of String)
        Public Property icon As String
        Public Property selectedIcon As String

        Public Sub New()
            state = New TreeViewNodeStateModel()
        End Sub
    End Class
End Namespace

'
' API Reference: https://github.com/jonmiles/bootstrap-treeview
' NOTE: Variable names must match the lowercase attribute names as detailed in the API.
'
