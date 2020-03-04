Imports System.Web.Configuration
Imports System.Web.Optimization

Public Class MvcApplication : Inherits HttpApplication

    ''' <summary>
    ''' Called by ASP.NET once for the lifetime of the application
    ''' domain; so whenever the first user access' the website, or whenever 
    ''' the Application Pool refreshes on the server.
    ''' </summary>
    Protected Sub Application_Start(ByVal sender As Object, ByVal args As EventArgs)
        AreaRegistration.RegisterAllAreas()

        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        ValueProviderFactories.Factories.Add(New JsonValueProviderFactory())
    End Sub

    ''' <summary>
    ''' Called by ASP.NET if an exception is thrown at the application level.
    ''' </summary>
    Protected Sub Application_Error(ByVal sender As Object, ByVal args As EventArgs)
        Dim lastException As Exception = Server.GetLastError()
        Response.Clear()

        Dim httpException As HttpException = TryCast(lastException, HttpException)
        If httpException IsNot Nothing Then

            Dim controllerAction As String
            Select Case httpException.GetHttpCode()
                Case 400
                    controllerAction = "Error_400"
                    Exit Select
                Case 401
                    controllerAction = "Error_401"
                    Exit Select
                Case 402
                    controllerAction = "Error_402"
                    Exit Select
                Case 403
                    controllerAction = "Error_403"
                    Exit Select
                Case 404
                    controllerAction = "Error_404"
                    Exit Select
                Case 409
                    controllerAction = "Error_409"
                    Exit Select
                Case 500
                    controllerAction = "Error_500"
                    Exit Select
                Case Else
                    controllerAction = ""
                    Exit Select
            End Select

            Server.ClearError()
            Response.Redirect(String.Format("~/Error/{0}", controllerAction))
        End If
    End Sub

    ''' <summary>
    ''' Called whenever a new user first access' the website and lasts for the
    ''' duration of their stay, or after twenty minutes. Whichever comes first.
    ''' </summary>
    Protected Sub Session_Start(ByVal sender As Object, ByVal args As EventArgs)
        '
        ' Set the connectionString for the current browsing session.
        '
        ' NOTE: If we're running locally (and assuming the debugger is running), we should
        ' connect to the local database, otherwise we should connect to the remote database.
        '
#If DEBUG Then
        HttpContext.Current.Session("ConnectionString") = WebConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
#Else
        HttpContext.Current.Session("ConnectionString") = WebConfigurationManager.ConnectionStrings("RemoteConnection").ConnectionString
#End If
    End Sub
End Class
