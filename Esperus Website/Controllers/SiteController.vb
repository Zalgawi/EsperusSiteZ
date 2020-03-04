Imports System.Net.Mail
Imports Esperus.Areas.Admin.Services
Imports Esperus.Data
Imports Esperus.Models
Imports Esperus.Services
Imports Ganss.XSS
Imports reCAPTCHA.MVC

Namespace Controllers
    Public Class SiteController : Inherits Controller
        Private Const ERR_EMAIL As String = "An error has occured. Please enter a valid e-mail address, and try again."
        Private Const ERR_TELEPHONE As String = "An error has occured. Please enter a valid telephone number, and try again."
        Private Const ERR_FIELDS As String = "An error has occured. Please make sure that all the fields in the contact form are populated and valid, and try again."

        Private Const MSG_SUCCESS_CONTACT As String = "Thank you for contacting Esperus Systems. We will get back to you as soon as possible."
        Private Const MSG_SUCCESS_WITHDRAW As String = "Thank you. You have successfully withdrawn from our mailing list."

        <HttpGet>
        Function Index() As ActionResult
            If Session("IsLoggedOn") Then
                Dim viewService As New LoginService()
                viewService.Logout(Session("ConnectionString"), Session("ActiveUser").Username)
            End If

            Dim viewModel As New PageViewModel()
            Dim contentService As New ContentService()
            contentService.GetContent(Session("ConnectionString"), "Page_1", viewModel)
            viewModel.pageHeadings = contentService.GetPageHeadings(Session("ConnectionString"))

            Response.Headers.Remove("Server")
            Return View(viewModel)
        End Function

        <HttpGet>
        Function Clients() As ActionResult
            If Session("IsLoggedOn") Then
                Dim viewService As New LoginService()
                viewService.Logout(Session("ConnectionString"), Session("ActiveUser").Username)
            End If

            Dim viewModel As New PageViewModel()
            Dim contentService As New ContentService()
            contentService.GetContent(Session("ConnectionString"), "Page_5", viewModel)
            viewModel.pageHeadings = contentService.GetPageHeadings(Session("ConnectionString"))

            TempData("Background") = "../../../Content/Images/Backgrounds/Carousel/carousel-image-5-1.jpg"

            Response.Headers.Remove("Server")
            Return View(viewModel)
        End Function

        <HttpGet>
        Function Testimonials() As ActionResult
            If Session("IsLoggedOn") Then
                Dim viewService As New LoginService()
                viewService.Logout(Session("ConnectionString"), Session("ActiveUser").Username)
            End If

            Dim viewModel As New PageViewModel()
            Dim contentService As New ContentService()
            contentService.GetContent(Session("ConnectionString"), "Page_6", viewModel)
            viewModel.pageHeadings = contentService.GetPageHeadings(Session("ConnectionString"))

            TempData("Background") = "../../../Content/Images/Backgrounds/Carousel/carousel-image-2-1.jpg"

            Response.Headers.Remove("Server")
            Return View(viewModel)
        End Function

        <HttpGet>
        Function About() As ActionResult
            If Session("IsLoggedOn") Then
                Dim viewService As New LoginService()
                viewService.Logout(Session("ConnectionString"), Session("ActiveUser").Username)
            End If

            Dim viewModel As New PageViewModel()
            Dim contentService As New ContentService()
            contentService.GetContent(Session("ConnectionString"), "Page_7", viewModel)
            viewModel.pageHeadings = contentService.GetPageHeadings(Session("ConnectionString"))

            TempData("Background") = "../../../Content/Images/Backgrounds/Home/home-background-2.jpg"

            Response.Headers.Remove("Server")
            Return View(viewModel)
        End Function

        <HttpGet>
        Function Contact() As ActionResult
            If Session("IsLoggedOn") Then
                Dim viewService As New LoginService()
                viewService.Logout(Session("ConnectionString"), Session("ActiveUser").Username)
            End If

            Dim viewModel As New ContactViewModel()
            Dim contentService As New ContentService()
            contentService.GetContent(Session("ConnectionString"), "Page_8", viewModel)
            viewModel.pageHeadings = contentService.GetPageHeadings(Session("ConnectionString"))

            TempData("Background") = "../../../Content/Images/Backgrounds/Carousel/carousel-image-4-1.jpg"

            Response.Headers.Remove("Server")
            Return View(viewModel)
        End Function

        <HttpPost>
        <CaptchaValidator>
        <ValidateAntiForgeryToken>
        Function Contact(viewModel As ContactViewModel, captchaValid As Boolean) As ActionResult
            If ModelState.IsValid Then
                If captchaValid = True Then
                    Dim dataManager As New ContactDataManager()
                    Dim messageService As New MessagingService()

                    Dim messageModel As New MessageModel()

                    If viewModel.RequestDemo Then
                        messageModel.Type = MessageType.DemoRequest
                    Else
                        messageModel.Type = MessageType.ContactRequest
                    End If

                    messageModel.SenderName = SanitizeMaliciousInput(viewModel.RequestFormName)
                    messageModel.SenderCompany = SanitizeMaliciousInput(viewModel.RequestFormCompany)

                    messageModel.SenderEmail = SanitizeMaliciousInput(viewModel.RequestFormEmail)
                    If Not IsValidEmail(messageModel.SenderEmail) Then
                        ViewData("Response") = ERR_EMAIL
                        ViewData("Response Type") = "Error"

                        ModelState.Clear()
                        Return View(New ContactViewModel())
                    End If

                    messageModel.SenderTelephone = SanitizeMaliciousInput(viewModel.RequestFormTelephone)
                    If Regex.IsMatch(messageModel.SenderTelephone, "^[0-9 ]+$") = False Then
                        ViewData("Response") = ERR_TELEPHONE
                        ViewData("Response Type") = "Error"

                        ModelState.Clear()
                        Return View(New ContactViewModel())
                    End If

                    messageModel.SenderCallingCode = SanitizeMaliciousInput(viewModel.RequestFormCallingCode)
                    messageModel.SenderExtension = SanitizeMaliciousInput(viewModel.RequestFormExtension)
                    messageModel.SenderMailingList = viewModel.RequestContactConsent

                    If Not viewModel.RequestFormInterest = "Placeholder" Then
                        messageModel.SenderInterest = viewModel.RequestFormInterest
                    Else
                        messageModel.SenderInterest = "Not Specified"
                    End If

                    If Not viewModel.RequestFormReferer = "Placeholder" Then
                        messageModel.SenderReferer = viewModel.RequestFormReferer
                    Else
                        messageModel.SenderReferer = "Not Specified"
                    End If

                    messageModel.SenderMessage = SanitizeMaliciousInput(viewModel.RequestFormMessage)

                    If messageService.SendMessage(messageModel) Then
                        ViewData("Response") = MSG_SUCCESS_CONTACT
                        ViewData("Response Type") = "Success"

                        If viewModel.RequestContactConsent = True Then
                            dataManager.SaveContactDetails(Session("ConnectionString"), messageModel)
                        End If
                    Else
                        ViewData("Response") = ERR_FIELDS
                        ViewData("Response Type") = "Error"
                    End If
                Else
                    ViewData("Response") = ERR_FIELDS
                    ViewData("Response Type") = "Error"
                End If
            End If

            ModelState.Clear()

            viewModel = New ContactViewModel()
            Dim contentService As New ContentService()
            contentService.GetContent(Session("ConnectionString"), "Page_8", viewModel)
            viewModel.pageHeadings = contentService.GetPageHeadings(Session("ConnectionString"))

            TempData("Background") = "../../../Content/Images/Backgrounds/Carousel/carousel-image-4-1.jpg"

            Response.Headers.Remove("Server")
            Return View(viewModel)
        End Function

        <HttpGet>
        Function Privacy() As ActionResult
            If Session("IsLoggedOn") Then
                Dim viewService As New LoginService()
                viewService.Logout(Session("ConnectionString"), Session("ActiveUser").Username)
            End If

            Dim viewModel As New PageViewModel()
            Dim contentService As New ContentService()
            contentService.GetContent(Session("ConnectionString"), "Page_10", viewModel)
            viewModel.pageHeadings = contentService.GetPageHeadings(Session("ConnectionString"))

            Response.Headers.Remove("Server")
            Return View(viewModel)
        End Function

        <HttpGet>
        Function Cookies() As ActionResult
            If Session("IsLoggedOn") Then
                Dim viewService As New LoginService()
                viewService.Logout(Session("ConnectionString"), Session("ActiveUser").Username)
            End If

            Dim viewModel As New PageViewModel()
            Dim contentService As New ContentService()
            contentService.GetContent(Session("ConnectionString"), "Page_11", viewModel)
            viewModel.pageHeadings = contentService.GetPageHeadings(Session("ConnectionString"))

            Response.Headers.Remove("Server")
            Return View(viewModel)
        End Function

        <HttpGet>
        Function Copyright() As ActionResult
            If Session("IsLoggedOn") Then
                Dim viewService As New LoginService()
                viewService.Logout(Session("ConnectionString"), Session("ActiveUser").Username)
            End If

            Dim viewModel As New PageViewModel()
            Dim contentService As New ContentService()
            contentService.GetContent(Session("ConnectionString"), "Page_12", viewModel)
            viewModel.pageHeadings = contentService.GetPageHeadings(Session("ConnectionString"))

            Response.Headers.Remove("Server")
            Return View(viewModel)
        End Function

        <HttpGet>
        Function Withdraw() As ActionResult
            If Session("IsLoggedOn") Then
                Dim viewService As New LoginService()
                viewService.Logout(Session("ConnectionString"), Session("ActiveUser").Username)
            End If

            Dim viewModel As New WithdrawViewModel()
            Dim contentService As New ContentService()
            contentService.GetContent(Session("ConnectionString"), "Page_13", viewModel)
            viewModel.pageHeadings = contentService.GetPageHeadings(Session("ConnectionString"))

            Response.Headers.Remove("Server")
            Return View(viewModel)
        End Function

        <HttpPost>
        <CaptchaValidator>
        <ValidateAntiForgeryToken>
        Function Withdraw(viewModel As WithdrawViewModel, captchaValid As Boolean) As ActionResult
            If ModelState.IsValid Then
                If captchaValid = True Then
                    Dim withdrawAddress = SanitizeMaliciousInput(viewModel.WithdrawAddress)
                    Dim dataManager As New ContactDataManager()

                    If IsValidEmail(withdrawAddress) Then
                        Dim result As Result = dataManager.DeleteContactDetails(Session("ConnectionString"), withdrawAddress)
                        If result.Type = True Then
                            ViewData("Response") = MSG_SUCCESS_WITHDRAW
                            ViewData("Response Type") = "Success"
                        Else
                            ViewData("Response") = ERR_FIELDS
                            ViewData("Response Type") = "Error"
                        End If
                    Else
                        ViewData("Response") = ERR_FIELDS
                        ViewData("Response Type") = "Error"
                    End If
                Else
                    ViewData("Response") = ERR_FIELDS
                    ViewData("Response Type") = "Error"
                End If
            End If

            ModelState.Clear()

            viewModel = New WithdrawViewModel()
            Dim contentService As New ContentService()
            contentService.GetContent(Session("ConnectionString"), "Page_13", viewModel)
            viewModel.pageHeadings = contentService.GetPageHeadings(Session("ConnectionString"))

            Response.Headers.Remove("Server")
            Return View(viewModel)
        End Function

        <HttpGet>
        Function Retail() As ActionResult
            If Session("IsLoggedOn") Then
                Dim viewService As New LoginService()
                viewService.Logout(Session("ConnectionString"), Session("ActiveUser").Username)
            End If

            Dim viewModel As New PageViewModel()
            Dim contentService As New ContentService()
            contentService.GetContent(Session("ConnectionString"), "Page_2", viewModel)
            viewModel.pageHeadings = contentService.GetPageHeadings(Session("ConnectionString"))

            TempData("Background") = "../../../Content/Images/Backgrounds/Home/home-background-4.jpg"

            Response.Headers.Remove("Server")
            Return View(viewModel)
        End Function

        <HttpGet>
        Function Wholesale() As ActionResult
            If Session("IsLoggedOn") Then
                Dim viewService As New LoginService()
                viewService.Logout(Session("ConnectionString"), Session("ActiveUser").Username)
            End If

            Dim viewModel As New PageViewModel()
            Dim contentService As New ContentService()
            contentService.GetContent(Session("ConnectionString"), "Page_3", viewModel)
            viewModel.pageHeadings = contentService.GetPageHeadings(Session("ConnectionString"))

            TempData("Background") = "../../../Content/Images/Backgrounds/Home/home-background-5.jpg"

            Response.Headers.Remove("Server")
            Return View(viewModel)
        End Function

        <HttpGet>
        Function Ecommerce() As ActionResult
            If Session("IsLoggedOn") Then
                Dim viewService As New LoginService()
                viewService.Logout(Session("ConnectionString"), Session("ActiveUser").Username)
            End If

            Dim viewModel As New PageViewModel()
            Dim contentService As New ContentService()
            contentService.GetContent(Session("ConnectionString"), "Page_4", viewModel)
            viewModel.pageHeadings = contentService.GetPageHeadings(Session("ConnectionString"))

            TempData("Background") = "../../../Content/Images/Backgrounds/Carousel/carousel-image-3-1.jpg"

            Response.Headers.Remove("Server")
            Return View(viewModel)
        End Function

        ''' <summary>
        ''' Converted from: https://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address
        ''' </summary>
        Private Function IsValidEmail(email As String)
            Try
                Dim mailAddress As New MailAddress(email)
                Return mailAddress.Address = email
            Catch exception As Exception
                Return False
            End Try
        End Function

        Private Function SanitizeMaliciousInput(input As String)
            Dim result As String = input
            Dim sanitizer As HtmlSanitizer = New HtmlSanitizer()
            Dim page As Lazy(Of Page) = New Lazy(Of Page)

            result = Replace(result, "'", "''")
            result = sanitizer.Sanitize(result)
            result = page.Value.Server.HtmlEncode(result)

            Return result
        End Function
    End Class
End Namespace
