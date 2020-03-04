Imports System.IO
Imports System.Web.Script.Serialization
Imports Esperus.Areas.Admin.Data
Imports Esperus.Areas.Admin.Models
Imports Ganss.XSS

Namespace Areas.Admin.Services
    Public Class EditorService
        Private _acceptedUploadTypes As New List(Of String)(New String() {
            "png", "jpeg", "jpg", "gif", "jp2", "jpx", "j2k", "j2c"
        })

        Public Function SanitizeInput(input As String)
            input = Replace(input, "'", "''")
            input = New HtmlSanitizer().Sanitize(input)
            Return input
        End Function

        Public Function CheckFile(uploadFile As HttpPostedFileBase)
            Dim result As Boolean = False
            If uploadFile IsNot Nothing Then
                If uploadFile.ContentLength > 0 AndAlso uploadFile.ContentLength < 10485760 Then
                    result = True
                End If
            End If
            Return result
        End Function

        Public Function UploadImageFile(uploadFile As HttpPostedFileBase, uploadName As String)
            Dim fileName = Path.GetFileName(uploadFile.FileName)
            Dim fileType = Path.GetExtension(fileName).Replace(".", "")
            Dim filePath As String

            Dim assetDAO As New AssetDataManager()

            If _acceptedUploadTypes.Contains(fileType.ToLower()) Then
                filePath = Path.Combine("/Areas/Admin/Resources/Uploads/", fileName)

                If Not File.Exists(filePath) Then
                    Dim model As New AssetModel With {.Name = fileName, .Path = filePath, .Type = "IMAGE", .DisplayName = uploadName}

                    uploadFile.SaveAs(HttpContext.Current.Server.MapPath("~/Areas/Admin/Resources/Uploads/" & fileName))
                    assetDAO.SaveNewImage(HttpContext.Current.Session("ConnectionString"), model)
                End If
            Else
                Return Nothing
            End If
            Return Path.Combine("/Areas/Admin/Resources/Uploads/", fileName)
        End Function

        Public Sub PopulateContentSelector(connectionString As String, viewModel As EditorViewModel)
            Dim pageDAO As New PageDataManager()
            Dim sectionDAO As New SectionDataManager()
            Dim contentDAO As New ContentDataManager()

            Dim nodes As New List(Of TreeViewNodeModel)

            ' Get Pages
            Dim pages As DataSet = pageDAO.GetAllPages(connectionString)
            If pages IsNot Nothing Then
                Dim index = 1
                For Each page As DataRow In pages.Tables("esp_Pages").Rows
                    Dim node As New TreeViewNodeModel With {
                        .text = page.Item("PageKey"),
                        .name = page.Item("PageName"),
                        .icon = "far fa-folder",
                        .selectedIcon = "far fa-folder"
                    }

                    If IsDBNull(page.Item("DisplayOrder")) Then
                        node.order = index
                    Else
                        node.order = page.Item("DisplayOrder")
                    End If

                    node.state = New TreeViewNodeStateModel With {
                        .checked = False,
                        .disabled = False
                    }

                    node.tags = New List(Of String)
                    node.tags.Add("Page")

                    ' NOTE: This fires on GET
                    If String.IsNullOrWhiteSpace(viewModel.SelectedPageKey) Then
                        viewModel.SelectedPageKey = page.Item("PageKey")
                    End If

                    If page.Item("PageKey") = viewModel.SelectedPageKey Then
                        node.state.selected = True
                        node.state.expanded = True
                    Else
                        node.state.selected = False
                        node.state.expanded = False
                    End If

                    index = index + 1
                    nodes.Add(node)
                Next

                ' Order the nodes according to their DisplayOrder, so that they appear true-to-life in the editor:
                Dim _nodes As List(Of TreeViewNodeModel) = nodes.OrderBy(Function(o) o.order).ToList()
                nodes = _nodes
            End If

            ' Get Sections
            Dim sections As DataSet = sectionDAO.GetAllSections(connectionString)
            If sections IsNot Nothing Then
                For Each section As DataRow In sections.Tables("esp_Sections").Rows
                    Dim index = 1
                    For Each node As TreeViewNodeModel In nodes
                        If section.Item("PageKey") = node.text Then
                            Dim nested As New TreeViewNodeModel With {
                                .text = section.Item("SectionKey"),
                                .name = section.Item("SectionName"),
                                .icon = "far fa-file",
                                .selectedIcon = "far fa-file"
                            }

                            If IsDBNull(section.Item("DisplayOrder")) Then
                                nested.order = index
                            Else
                                nested.order = section.Item("DisplayOrder")
                            End If

                            nested.state = New TreeViewNodeStateModel With {
                                .checked = False,
                                .disabled = False
                            }

                            nested.tags = New List(Of String)
                            nested.tags.Add("Section")

                            If section.Item("SectionKey") = viewModel.SelectedSectionKey Then
                                node.state.selected = False

                                nested.state.selected = True
                                nested.state.expanded = True
                            Else
                                nested.state.selected = False
                                nested.state.expanded = False
                            End If

                            If node.nodes IsNot Nothing Then
                                node.nodes.Add(nested)
                            Else
                                node.nodes = New List(Of TreeViewNodeModel)
                                node.nodes.Add(nested)
                            End If

                            ' Order the nodes according to their DisplayOrder, so that they appear true-to-life in the editor:
                            Dim _nested As List(Of TreeViewNodeModel) = node.nodes.OrderBy(Function(o) o.order).ToList()
                            node.nodes = _nested

                            index = index + 1
                        End If
                    Next
                Next
            End If

            viewModel.EditorModel.Key = viewModel.SelectedPageKey
            viewModel.HierarchyString = New JavaScriptSerializer().Serialize(nodes)
        End Sub

        Public Function PopulateContentEditor(connectionString As String, pageModel As PageModel)
            Dim pageDAO As New PageDataManager()
            Dim page As New Lazy(Of Page)

            If pageDAO.LoadPageData(connectionString, pageModel) = True Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function PopulateContentEditor(connectionString As String, sectionModel As SectionModel)
            Dim sectionDAO As New SectionDataManager()
            Dim page As New Lazy(Of Page)

            If sectionDAO.LoadSectionData(connectionString, sectionModel) = True Then
                sectionModel.Name = page.Value.Server.HtmlDecode(sectionModel.Name)
                sectionModel.Body = page.Value.Server.HtmlDecode(sectionModel.Body)
                Return True
            Else
                Return False
            End If
        End Function

        Public Function PopulateContentEditor(connectionString As String, contentModel As ContentModel)
            Dim contentDAO As New ContentDataManager()
            Dim page As New Lazy(Of Page)

            If contentDAO.LoadContentData(connectionString, contentModel) = True Then
                contentModel.Name = page.Value.Server.HtmlDecode(contentModel.Name)
                contentModel.Body = page.Value.Server.HtmlDecode(contentModel.Body)
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End Namespace
