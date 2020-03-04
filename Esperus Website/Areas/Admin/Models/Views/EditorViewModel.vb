Imports Esperus.Models

Namespace Areas.Admin.Models
    Public Class EditorViewModel
        Public Property EditorModel As BaseEditorModel
        Public Property EditorImages As List(Of DirectoryItem)
        Public Property ContentModels As List(Of BaseEditorModel)
        Public Property CurrentEditorType As String
        Public Property SelectedPageKey As String
        Public Property SelectedSectionKey As String
        Public Property SelectedEditorType As String
        Public Property SaveChanges As Boolean
        Public Property HierarchyString As String

        Public Sub New()
            EditorModel = New BaseEditorModel()
            EditorImages = New List(Of DirectoryItem)
            ContentModels = New List(Of BaseEditorModel)
        End Sub
    End Class
End Namespace
