Imports Esperus.Areas.Admin.Data
Imports Esperus.Areas.Admin.Models
Imports Esperus.Models

Namespace Services
    Public Class ContentService
        ''' <summary>
        ''' Populates a ContentPageViewModel with content according to a PageKey.
        ''' </summary>
        Public Sub GetContent(connectionString As String, pageKey As String, viewModel As PageViewModel)
            Dim page As New Lazy(Of Page)

            Dim pageDAO As New PageDataManager()
            Dim sectionDAO As New SectionDataManager()
            Dim contentDAO As New ContentDataManager()

            Dim pageModel As New PageModel()
            pageModel.Key = pageKey

            pageDAO.LoadPageData(connectionString, pageModel)

            Dim pageSections As DataSet = sectionDAO.GetSectionsByPageKey(connectionString, pageModel)
            Dim _pageSections As DataTable = pageSections.Tables("esp_Sections")

            Dim sectionModels As New List(Of SectionModel)
            Dim contentModels As New List(Of ContentModel)

            For Each pageSection As DataRow In _pageSections.Rows
                Dim sectionModel As New SectionModel()
                sectionModel.Key = pageSection.Item("SectionKey")
                sectionModel.Name = pageSection.Item("SectionName")
                sectionModel.PageKey = pageSection.Item("PageKey")
                sectionModels.Add(sectionModel)
            Next

            For Each sectionModel As SectionModel In sectionModels
                Dim pageContent As DataSet = contentDAO.GetContentBySectionKey(connectionString, sectionModel)
                Dim _pageContent As DataTable = pageContent.Tables("esp_Contents")

                For Each sectionContent As DataRow In _pageContent.Rows
                    Dim contentModel As New ContentModel()
                    contentModel.Key = sectionContent.Item("ContentKey")

                    If Not IsDBNull(sectionContent.Item("ContentBody")) Then
                        Dim contentName = sectionContent.Item("ContentName")
                        contentName = page.Value.Server.HtmlDecode(contentName)
                        contentModel.Name = contentName
                    End If

                    If Not IsDBNull(sectionContent.Item("ContentBody")) Then
                        Dim contentBody = sectionContent.Item("ContentBody")
                        contentBody = page.Value.Server.HtmlDecode(contentBody)
                        contentModel.Body = contentBody
                    End If

                    If Not IsDBNull(sectionContent.Item("ContentImage")) Then
                        Dim contentImage = sectionContent.Item("ContentImage")
                        contentImage = page.Value.Server.HtmlDecode(contentImage)
                        contentModel.Image = contentImage
                    End If

                    If Not IsDBNull(sectionContent.Item("ContentType")) Then
                        Dim contentType = sectionContent.Item("ContentType")
                        contentType = page.Value.Server.HtmlDecode(contentType)
                        contentModel.Type = contentType
                    End If

                    contentModel.SectionKey = sectionContent.Item("SectionKey")
                    contentModels.Add(contentModel)
                Next
            Next

            viewModel.pageKey = pageModel.Key
            viewModel.pageName = pageModel.Name
            viewModel.pageSections = sectionModels
            viewModel.pageContent = contentModels
        End Sub

        Public Function GetPageHeadings(connectionString As String)
            Dim pageDAO As New PageDataManager()

            Dim pages As DataSet = pageDAO.GetAllPages(connectionString)
            Dim _pages As DataTable = pages.Tables("esp_Pages")

            Dim pageHeadings As New List(Of PageModel)
            For Each page As DataRow In _pages.Rows
                Dim pageModel As New PageModel()

                If Not IsDBNull(page.Item("PageKey")) Then
                    pageModel.Key = page.Item("PageKey")
                End If

                If Not IsDBNull(page.Item("PageName")) Then
                    pageModel.Name = page.Item("PageName")
                End If

                If Not IsDBNull(page.Item("PageLink")) Then
                    pageModel.PageLink = page.Item("PageLink")
                End If

                If Not IsDBNull(page.Item("DisplayOrder")) Then
                    pageModel.Order = page.Item("DisplayOrder")
                End If

                If Not IsDBNull(page.Item("DisplayNavbar")) Then
                    pageModel.DisplayNavbar = Convert.ToBoolean(page.Item("DisplayNavbar"))
                End If

                If Not IsDBNull(page.Item("DisplayID")) Then
                    pageModel.DisplayID = page.Item("DisplayID")
                End If

                pageHeadings.Add(pageModel)
            Next

            Dim _orderedPages As List(Of PageModel) = pageHeadings.OrderBy(Function(o) o.Order).ToList()
            pageHeadings = _orderedPages

            Return pageHeadings
        End Function
    End Class
End Namespace
