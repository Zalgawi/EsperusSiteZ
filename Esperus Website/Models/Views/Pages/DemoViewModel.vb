Namespace Models
    Public Class DemoViewModel : Inherits PageViewModel
        Public Property Interests As IEnumerable(Of SelectListItem)
        Public Property Referers As IEnumerable(Of SelectListItem)

        Public Property RequestFormName As String
        Public Property RequestFormCompany As String
        Public Property RequestFormEmail As String
        Public Property RequestFormExtension As String
        Public Property RequestFormTelephone As String
        Public Property RequestFormCallingCode As String
        Public Property RequestFormInterest As String
        Public Property RequestFormReferer As String
        Public Property RequestFormMessage As String
        Public Property RequestContactConsent As Boolean

        Public Sub New()
            Dim _interests As List(Of SelectListItem) = New List(Of SelectListItem)
            _interests.Add(New SelectListItem() With {.Text = "What type of system are you looking for?", .Value = "Placeholder"})
            _interests.Add(New SelectListItem() With {.Text = "Retail", .Value = "Retail"})
            _interests.Add(New SelectListItem() With {.Text = "Wholesale", .Value = "Wholesale"})
            _interests.Add(New SelectListItem() With {.Text = "E-commerce", .Value = "E-commerce"})
            _interests.Add(New SelectListItem() With {.Text = "Multi-channel", .Value = "Multi-channel"})
            Interests = _interests

            Dim _referers As List(Of SelectListItem) = New List(Of SelectListItem)
            _referers.Add(New SelectListItem() With {.Text = "How did you hear about us?", .Value = "Placeholder"})
            _referers.Add(New SelectListItem() With {.Text = "Referal", .Value = "Referal"})
            _referers.Add(New SelectListItem() With {.Text = "Emailer", .Value = "Emailer"})
            _referers.Add(New SelectListItem() With {.Text = "Trade Show", .Value = "Trade Show"})
            _referers.Add(New SelectListItem() With {.Text = "Online Search", .Value = "Online Search"})
            _referers.Add(New SelectListItem() With {.Text = "Magazine Article", .Value = "Magazine Article"})
            _referers.Add(New SelectListItem() With {.Text = "Other", .Value = "other"})
            Referers = _referers
        End Sub
    End Class
End Namespace
