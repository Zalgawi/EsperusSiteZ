Imports Esperus.Areas.Admin.Models

Namespace Areas.Admin
    Public Class FilterConfig
        Public Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
            filters.Add(New ValidateSession())
        End Sub
    End Class
End Namespace
