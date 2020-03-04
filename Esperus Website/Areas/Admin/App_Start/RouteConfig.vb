Namespace Areas.Admin
    Public Class RouteConfig
        Public Shared Sub RegisterRoutes(ByVal context As AreaRegistrationContext)
            context.MapRoute(
                name:="Admin",
                url:="Admin/{action}/{id}",
                defaults:=New With {.action = "Index", .controller = "Admin", .id = UrlParameter.Optional}
            )
        End Sub
    End Class
End Namespace
