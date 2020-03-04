Imports Elmah

Namespace Services
    Public Class ElmahHandledErrorLoggerFilter : Inherits HandleErrorAttribute
        Public Overrides Sub OnException(ByVal context As ExceptionContext)
            MyBase.OnException(context)
            If Not context.ExceptionHandled Then Return
            Dim httpContext = context.HttpContext.ApplicationInstance.Context
            Dim signal = ErrorSignal.FromContext(httpContext)
            signal.Raise(context.Exception, httpContext)
        End Sub
    End Class
End Namespace
