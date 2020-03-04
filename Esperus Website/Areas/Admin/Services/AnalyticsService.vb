Imports System.IO
Imports System.Threading.Tasks
Imports Google.Apis.Auth.OAuth2

Namespace Areas.Admin.Services
    Public Class AnalyticsService

        Public Sub New()

        End Sub

        ''' <summary>
        ''' Retrieves the Google Analytics access token using Google's API. It uses a Service
        ''' Account set-up in Google API Console to channel access between this application and 
        ''' Google Analytics Embed API.
        ''' </summary>
        ''' <param name="keyDir">Token Path</param>
        ''' <param name="scopes">Access Scopes</param>
        Public Function GetAccessToken(ByVal keyDir As String, ParamArray scopes As String()) As Task(Of String)
            Using stream = New FileStream(keyDir, FileMode.Open, FileAccess.Read)
                Return GoogleCredential.FromStream(stream).CreateScoped(scopes).UnderlyingCredential.GetAccessTokenForRequestAsync()
            End Using
        End Function
    End Class
End Namespace
