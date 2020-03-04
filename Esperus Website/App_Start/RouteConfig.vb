Imports Microsoft.AspNet.FriendlyUrls

Public Module RouteConfig
    Public Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
        routes.IgnoreRoute("elmah.axd") ' Required for Elmah

        routes.MapRoute(
            name:="Error",
            url:="error/{action}/{id}",
            defaults:=New With {.controller = "Error", .action = "Index", .id = UrlParameter.Optional}
        )

        routes.MapRoute(
            name:="Site",
            url:="{action}/{id}",
            defaults:=New With {.controller = "Site", .action = "Index", .id = UrlParameter.Optional}
        )

        routes.LowercaseUrls = True

        routes.EnableFriendlyUrls(New FriendlyUrlSettings With {
            .AutoRedirectMode = RedirectMode.Permanent
        })
    End Sub
End Module
