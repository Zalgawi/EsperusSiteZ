Imports Esperus.Areas.Admin.Data
Imports Esperus.Areas.Admin.Models
Imports Esperus.Areas.Admin.Services
Imports Esperus.Models
Imports reCAPTCHA.MVC

Namespace Areas.Admin.Controllers
    Public Class AdminController : Inherits Controller
        Private Const ANALYTICS_SCOPE As String = "https://www.googleapis.com/auth/analytics.readonly"
        Private Const ANALYTICS_TOKEN_PATH As String = "/Areas/Admin/Content/Tokens/esperus-cms-e52a653700c6.json"

        Private Const ERROR_CAPTCHA As String = "Please complete reCAPTCHA before you log in."
        Private Const ERROR_FIELDS As String = "Please make sure that all the fields in the form are populated and valid, and try again."

        <HttpGet>
        <ValidateSession>
        Function Index() As ActionResult
            If Not Session("IsLoggedOn") Then
                Return RedirectToAction("Login")
            End If

            Dim viewService As New AnalyticsService()

            Dim scopes As String() = New String() {ANALYTICS_SCOPE}
            Dim key As String = AppDomain.CurrentDomain.BaseDirectory & ANALYTICS_TOKEN_PATH
            Dim credentials = viewService.GetAccessToken(key, scopes).Result

            Dim viewModel As New HomeViewModel()
            viewModel.Token = credentials

            Return View(viewModel)
        End Function

        <HttpGet>
        <ValidateSession>
        Function Login() As ActionResult
            Return View(New LoginViewModel())
        End Function

        <HttpPost>
        <CaptchaValidator>
        <ValidateAntiForgeryToken>
        <ValidateSession>
        Function Login(viewModel As LoginViewModel, captchaValid As Boolean) As ActionResult
            Dim service As New LoginService()
            Dim result As Result

            If viewModel.captchaEnabled Then
                If Not captchaValid Then
                    result = New Result(False, "Invalid Submission", ERROR_CAPTCHA)
                Else
                    Dim currentUsername As String = Convert.ToString(viewModel.inputUsername)
                    Dim currentPassword As String = Convert.ToString(viewModel.inputPassword)

                    result = service.Login(Session("ConnectionString"), currentUsername, currentPassword)
                End If
            Else
                Dim currentUsername As String = Convert.ToString(viewModel.inputUsername)
                Dim currentPassword As String = Convert.ToString(viewModel.inputPassword)

                result = service.Login(Session("ConnectionString"), currentUsername, currentPassword)
            End If

            If result.Type = True Then
                Session("IsLoggedOn") = True
                Return RedirectToAction("Index")
            Else
                ModelState.Clear()

                Dim loginAttempts As Integer = viewModel.loginAttempts
                viewModel = New LoginViewModel() With {.loginMessage = New ViewMessageModel(result.Heading, result.Message, result.Type)}
                viewModel.loginAttempts = loginAttempts + 1

                If viewModel.loginAttempts = 3 Then
                    viewModel.captchaEnabled = True
                End If

                Return View(viewModel)
            End If
        End Function

        <HttpGet>
        <ValidateSession>
        Function Pages() As ActionResult
            If Not Session("IsLoggedOn") Then
                Return RedirectToAction("Login")
            End If

            Dim viewModel As New EditorViewModel()
            Dim viewService As New EditorService()
            Dim imageService As New ImageService()

            viewModel.EditorModel = New PageModel()

            viewService.PopulateContentSelector(Session("ConnectionString"), viewModel)

            Dim pageModel As New PageModel(viewModel.EditorModel.Key, viewModel.EditorModel.Name)
            If viewService.PopulateContentEditor(Session("ConnectionString"), pageModel) = False Then
                Return RedirectToAction("Error_500", "Error")
            End If

            viewModel.EditorModel = pageModel
            viewModel.EditorImages = imageService.PopulateFolders(Session("ConnectionString"))

            For Each image As DirectoryItem In viewModel.EditorImages
                image.RelativePath = GetRelativePath(image.FullPath)
            Next

            ' Default values:
            viewModel.CurrentEditorType = "Page"
            viewModel.SelectedEditorType = "Page"

            Return View(viewModel)
        End Function

        <HttpPost>
        <ValidateSession>
        <ValidateAntiForgeryToken>
        Function Pages(viewModel As EditorViewModel) As ActionResult
            Dim viewService As New EditorService()

            ' If the user has asked to save their changes..
            If viewModel.SaveChanges = True Then
                Dim currentType As SelectionType = [Enum].Parse(GetType(SelectionType), viewModel.CurrentEditorType)

                ' Check to see what type of page they're _currently_ viewing
                ' so we can run the appropriate data operations.
                Select Case currentType
                    Case SelectionType.Page
                        Dim pageModel As New PageModel With {.Key = viewModel.EditorModel.Key}
                        pageModel.Name = viewService.SanitizeInput(viewModel.EditorModel.Name)

                        Dim _parseResult As Integer
                        If Integer.TryParse(viewModel.EditorModel.Order, _parseResult) Then
                            pageModel.Order = Convert.ToInt32(viewService.SanitizeInput(viewModel.EditorModel.Order))
                        End If

                        If New PageDataManager().SavePageData(Session("ConnectionString"), pageModel) = False Then
                            Return RedirectToAction("Error_500", "Error")
                        End If
                        Exit Select

                    Case SelectionType.Section
                        Dim sectionModel As New SectionModel With {.Key = viewModel.EditorModel.Key, .PageKey = viewModel.SelectedPageKey}
                        sectionModel.Name = viewService.SanitizeInput(viewModel.EditorModel.Name)

                        Dim _parseResult As Integer
                        If Integer.TryParse(viewModel.EditorModel.Order, _parseResult) Then
                            sectionModel.Order = Convert.ToInt32(viewService.SanitizeInput(viewModel.EditorModel.Order))
                        End If

                        If New SectionDataManager().SaveSectionData(Session("ConnectionString"), sectionModel) = False Then
                            Return RedirectToAction("Error_500", "Error")
                        End If

                        If viewModel.ContentModels IsNot Nothing Then
                            ' Save each editor.
                            For Each response As BaseEditorModel In viewModel.ContentModels
                                Dim contentModel As New ContentModel With {.Key = response.Key, .Type = viewModel.SelectedEditorType, .SectionKey = viewModel.SelectedSectionKey}
                                contentModel.Name = viewService.SanitizeInput(response.Name)

                                Dim contentType As ContentType = [Enum].Parse(GetType(ContentType), response.Type)

                                ' Check to see what type of content they're _editing_
                                ' so we can run the appropriate data operations.
                                Select Case contentType
                                    Case ContentType.Text
                                        contentModel.Body = viewService.SanitizeInput(response.Body)
                                        Exit Select

                                    Case ContentType.Image
                                        contentModel.Image = response.Image
                                        Exit Select

                                    Case ContentType.Slide
                                        contentModel.Image = response.Image
                                        contentModel.Body = viewService.SanitizeInput(response.Body)
                                        Exit Select

                                    Case ContentType.Link
                                        contentModel.Body = viewService.SanitizeInput(response.Body)
                                        'contentModel.Image = viewService.SanitizeInput(response.Image)
                                        Exit Select
                                End Select

                                If New ContentDataManager().SaveContentData(Session("ConnectionString"), contentModel) = False Then
                                    Return RedirectToAction("Error_500", "Error")
                                End If
                            Next
                        End If
                        Exit Select
                End Select
            End If

            ' Check to see what type of page they've _selected_ next
            ' so we can run the appropriate data operations.
            Dim selectedType As SelectionType = [Enum].Parse(GetType(SelectionType), viewModel.SelectedEditorType)
            Select Case selectedType
                Case SelectionType.Page
                    Dim pageModel As New PageModel With {.Key = viewModel.SelectedPageKey}

                    viewService.PopulateContentSelector(Session("ConnectionString"), viewModel)

                    If viewService.PopulateContentEditor(Session("ConnectionString"), pageModel) = False Then
                        Return RedirectToAction("Error_500", "Error")
                    End If

                    viewModel.EditorModel = pageModel
                    viewModel.CurrentEditorType = "Page"

                    If viewModel.ContentModels.Count > 0 Then
                        viewModel.ContentModels.Clear()
                    End If
                    Exit Select

                Case SelectionType.Section
                    Dim sectionModel As New SectionModel With {.Key = viewModel.SelectedSectionKey}

                    viewService.PopulateContentSelector(Session("ConnectionString"), viewModel)

                    If viewService.PopulateContentEditor(Session("ConnectionString"), sectionModel) = False Then
                        Return RedirectToAction("Error_500", "Error")
                    End If

                    viewModel.EditorModel = sectionModel
                    viewModel.CurrentEditorType = "Section"

                    If viewModel.ContentModels.Count > 0 Then
                        viewModel.ContentModels.Clear()
                    End If

                    Dim contentManager As New ContentDataManager()
                    Dim tableData As DataSet = contentManager.GetContentBySectionKey(Session("ConnectionString"), sectionModel)
                    Dim _tableData As DataTable = tableData.Tables(0)

                    For Each tableRow As DataRow In _tableData.Rows
                        Dim contentModel As New ContentModel With {.Key = tableRow("ContentKey")}

                        If viewService.PopulateContentEditor(Session("ConnectionString"), contentModel) = False Then
                            Return RedirectToAction("Error_500", "Error")
                        End If

                        viewModel.ContentModels.Add(contentModel)
                    Next
                    Exit Select
            End Select

            viewModel.SaveChanges = False

            Dim imageService As New ImageService()
            viewModel.EditorImages = imageService.PopulateFolders(Session("ConnectionString"))

            For Each image As DirectoryItem In viewModel.EditorImages
                image.RelativePath = GetRelativePath(image.FullPath)
            Next

            ModelState.Clear()
            Return View(viewModel)
        End Function

        <HttpGet>
        <ValidateSession>
        Function Images() As ActionResult
            If Not Session("IsLoggedOn") Then
                Return RedirectToAction("Login")
            End If

            Dim viewModel As New ImagesViewModel()
            Dim viewService As New ImageService()

            viewModel.Images = viewService.PopulateFolders(Session("ConnectionString"))

            For Each image As DirectoryItem In viewModel.Images
                image.RelativePath = GetRelativePath(image.FullPath)
            Next

            Return View(viewModel)
        End Function

        <HttpPost>
        <ValidateSession>
        Function Images(viewModel As ImagesViewModel) As ActionResult
            If ModelState.IsValid Then

            End If

            ModelState.Clear()
            Return View(viewModel)
        End Function

        <HttpPost>
        <ValidateSession>
        Function UploadImage(viewModel As ImagesViewModel, imagePath As HttpPostedFileBase, imageName As String) As ActionResult
            If ModelState.IsValid Then
                Dim viewService As New EditorService()

                If viewService.CheckFile(imagePath) Then
                    viewService.UploadImageFile(imagePath, imageName)
                End If
            End If

            ModelState.Clear()
            Return RedirectToAction("Images")
        End Function

        <HttpPost>
        <ValidateSession>
        Function DeleteImage(viewModel As ImagesViewModel, selectedImageName As String, selectedImagePath As String) As ActionResult
            If ModelState.IsValid Then
                Dim assetDAO As New AssetDataManager()
                Dim viewService As New ImageService()

                Dim path As String = Server.MapPath(selectedImagePath)
                If IO.File.Exists(path) Then
                    GC.Collect()
                    GC.WaitForPendingFinalizers()
                    IO.File.Delete(path)

                    assetDAO.DeleteExistingImage(Session("ConnectionString"), selectedImageName)
                End If
            End If

            ModelState.Clear()
            Return RedirectToAction("Images")
        End Function

        <HttpGet>
        <ValidateSession>
        Function Account() As ActionResult
            If Not Session("IsLoggedOn") Then
                Return RedirectToAction("Login")
            End If

            Return View(New SettingsAccountViewModel())
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        <ValidateSession>
        Function Account(viewModel As SettingsAccountViewModel) As ActionResult
            Dim service As New LoginService()
            Dim result As Result = Nothing

            If ModelState.IsValid() Then
                Dim currentUsername As String = Convert.ToString(viewModel.CurrentUsername)
                Dim currentPassword As String = Convert.ToString(viewModel.CurrentPassword)

                If String.IsNullOrWhiteSpace(currentUsername) OrElse String.IsNullOrWhiteSpace(currentPassword) Then
                    result = New Result(False, "Error", ERROR_FIELDS)
                Else
                    Dim newUsername As String = Convert.ToString(viewModel.NewUsername)
                    Dim newPassword As String = Convert.ToString(viewModel.NewPassword)

                    If String.IsNullOrWhiteSpace(newUsername) OrElse String.IsNullOrWhiteSpace(newPassword) Then
                        result = New Result(False, "Error", ERROR_FIELDS)
                    Else
                        currentPassword = service.Encrypt(currentPassword)
                        newPassword = service.Encrypt(newPassword)

                        result = service.UpdateAccount(Session("ConnectionString"), currentUsername, currentPassword, newUsername, newPassword)
                    End If
                End If
            End If

            ModelState.Clear()

            viewModel = New SettingsAccountViewModel()
            If result IsNot Nothing Then
                viewModel.ViewMessage = New ViewMessageModel(result.Heading, result.Message, result.Type)
            End If

            Return View(viewModel)
        End Function

        Private Function GetUrl(context As Page) As String
            Return context.Request.Url.GetLeftPart(UriPartial.Authority)
        End Function

        Private Function GetRelativePath(path As String) As String
            Dim relativePath As String
            relativePath = path.Substring(Server.MapPath("~/").Length - 1)
            relativePath = relativePath.Replace("\", "/")
            Return relativePath
        End Function

        Private Function PathToUrl(path As String, context As Page) As String
            Dim url As String
            url = $"{GetUrl(context)}{GetRelativePath(path)}"
            Return url
        End Function
    End Class
End Namespace

Enum SelectionType
    Page = 1
    Section = 2
End Enum

Enum ContentType
    Text = 1
    Image = 2
    Slide = 3
    Link = 4
End Enum
