Imports System.Web.Optimization

Namespace Areas.Admin
    Public Class AdminAreaRegistration : Inherits AreaRegistration
        Public Overrides ReadOnly Property AreaName() As String
            Get
                Return "Admin"
            End Get
        End Property

        '
        ' Bundles, routes and filters are split up between the Admin area and the host website:
        ' See: https://stackoverflow.com/questions/13335839/how-to-bundle-resources-for-asp-net-mvc-areas
        '
        Public Overrides Sub RegisterArea(ByVal context As AreaRegistrationContext)
            RouteConfig.RegisterRoutes(context)
            BundleConfig.RegisterBundles(BundleTable.Bundles)
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        End Sub
    End Class
End Namespace
