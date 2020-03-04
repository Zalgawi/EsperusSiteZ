Namespace Areas.Admin.Models
    <AttributeUsage(AttributeTargets.Method, Inherited:=True, AllowMultiple:=False)>
    Public Class ValidateSession : Inherits ActionFilterAttribute
        Public Overrides Sub OnActionExecuting(filterContext As ActionExecutingContext)
            Dim currentContext As HttpContext = HttpContext.Current

            If currentContext.Session IsNot Nothing Then
                If currentContext.Session.IsNewSession Then
                    Dim sessionCookie As String = currentContext.Request.Headers("Cookie")

                    If (sessionCookie IsNot Nothing) AndAlso (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0) Then
                        FormsAuthentication.SignOut()

                        HttpContext.Current.Session("IsLoggedOn") = False

                        If String.IsNullOrWhiteSpace(currentContext.Request.RawUrl) Then
                            filterContext.Result = New RedirectToRouteResult(New RouteValueDictionary(New With {.controller = "Admin", .action = "Login"}))
                            Return
                        End If
                    End If
                End If

                MyBase.OnActionExecuting(filterContext)
            End If
        End Sub
    End Class
End Namespace
