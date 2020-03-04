Imports Esperus.Areas.Admin.Models

Namespace Models
    Public Class PageViewModel : Inherits BaseViewModel
        Public Property pageKey As String
        Public Property pageName As String
        Public Property pageSections As List(Of SectionModel)
        Public Property pageContent As List(Of ContentModel)

        Public Sub New()

        End Sub
    End Class
End Namespace
