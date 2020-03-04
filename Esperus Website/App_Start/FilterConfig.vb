Imports Esperus.Services

Public Module FilterConfig
    Public Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
        filters.Add(New ElmahHandledErrorLoggerFilter()) ' Required for Elmah
    End Sub
End Module
