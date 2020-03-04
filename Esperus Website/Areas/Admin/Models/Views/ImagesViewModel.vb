Imports Esperus.Models

Namespace Areas.Admin.Models
    Public Class ImagesViewModel
        Public Images As List(Of DirectoryItem)

        Public Sub New()
            Images = New List(Of DirectoryItem)
        End Sub
    End Class
End Namespace
