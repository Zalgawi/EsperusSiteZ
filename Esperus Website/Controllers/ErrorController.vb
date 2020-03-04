Namespace Controllers
    Public Class ErrorController : Inherits Controller
        <HttpGet>
        Function Index() As ActionResult
            Response.Headers.Remove("Server")
            Response.TrySkipIisCustomErrors = True
            Server.ClearError()
            Return View()
        End Function

        <HttpGet>
        Function Error_400() As ActionResult
            Response.Headers.Remove("Server")
            Response.StatusCode = 400
            ViewData("Code") = 400
            Return View("Index")
        End Function

        <HttpGet>
        Function Error_401() As ActionResult
            Response.Headers.Remove("Server")
            Response.StatusCode = 401
            ViewData("Code") = 401
            Return View("Index")
        End Function

        <HttpGet>
        Function Error_403() As ActionResult
            Response.Headers.Remove("Server")
            Response.StatusCode = 403
            ViewData("Code") = 403
            Return View("Index")
        End Function

        <HttpGet>
        Function Error_404() As ActionResult
            Response.Headers.Remove("Server")
            Response.StatusCode = 404
            ViewData("Code") = 404
            Return View("Index")
        End Function

        <HttpGet>
        Function Error_409() As ActionResult
            Response.Headers.Remove("Server")
            Response.StatusCode = 409
            ViewData("Code") = 409
            Return View("Index")
        End Function

        <HttpGet>
        Function Error_500() As ActionResult
            Response.Headers.Remove("Server")
            Response.StatusCode = 500
            ViewData("Code") = 500
            Return View("Index")
        End Function
    End Class
End Namespace
