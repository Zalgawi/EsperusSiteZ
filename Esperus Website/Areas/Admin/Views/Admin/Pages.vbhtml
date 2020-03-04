@ModelType Esperus.Areas.Admin.Models.EditorViewModel
@Imports Esperus.Areas.Admin.Models
@Code
  ViewData("Title") = "Pages"
  Layout = "~/Areas/Admin/Views/Shared/Layouts/_NestedLayout.vbhtml"
End Code

<div class="form-wrapper">
  <form class="editor-form" action="/admin/pages" enctype="multipart/form-data" method="post">
    <input type="hidden" id="_currentEditorKey" name="EditorModel.Key" value="@Model.EditorModel.Key" />
    <input type="hidden" id="_currentEditorType" name="CurrentEditorType" value="@Model.CurrentEditorType" />
    <input type="hidden" id="_selectedPageKey" name="SelectedPageKey" value="@Model.SelectedPageKey" />
    <input type="hidden" id="_selectedSectionKey" name="SelectedSectionKey" value="@Model.SelectedSectionKey" />
    <input type="hidden" id="_selectedEditorType" name="SelectedEditorType" value="@Model.SelectedEditorType" />
    <input type="hidden" id="_saveChanges" name="SaveChanges" value="@Model.SaveChanges" />
    <input type="hidden" id="_hierarchyString" name="HierarchyString" value="@Model.HierarchyString" />

    <div class="hierarchy-wrapper">
      <div class="hierarchy-header">
        <p>Hierarchy</p>
      </div>
      <div class="hierarchy" id="page-tree"></div>
    </div>

    <div class="editor-wrapper">
      <div class="editor-header">
        <p>Editor</p>
      </div>

      <div class="page-editor">
        @* title-row *@
        <div class="form-row" id="title-row">
          <div class="form-group" id="action-group">
            <button type="submit" class="button editor-submit">
              <i class="fas fa-save"></i> Save
            </button>
          </div>
        </div>

        @* editor-row *@
        <div class="form-row" id="editor-row">
          <div class="top-wrapper">
            <div class="form-group" id="name-group">
              <p class="name-group-label">Name:</p>
              @Html.TextBoxFor(Function(model) model.EditorModel.Name, New With {.class = "form-control"})
            </div>

            <div class="form-group" id="display-group">
              <p class="display-group-label">Order:</p>
              @Html.TextBoxFor(Function(model) model.EditorModel.Order, New With {.class = "form-control"})
            </div>

            @If Not Model.ContentModels.Count = 0 Then
              @<div class="form-group" id="content-group">
                <p class="list-group-label">Content:</p>

                <div class="list-group list-group-horizontal" id="list-tab" role="tablist">
                  @Code Dim index As Integer = 1 End Code
                  @For Each baseModel As BaseEditorModel In Model.ContentModels
                    @<a class="list-group-item list-group-item-action" id="content-list-@index" data-toggle="list" href="#list-@index" aria-controls="list-@index">
                      @baseModel.Type
                    </a>

                    @Code index = index + 1 End Code
                  Next
                </div>
              </div>
            End If
          </div>

          <div Class="form-group" id="editor-group">
            @If Not Model.ContentModels.Count = 0 Then
              @<div class="tab-content" id="editor-content">
                @Code Dim index As Integer = 1 End Code
                @For Each baseModel As BaseEditorModel In Model.ContentModels
                  @<div class="tab-pane fade" id="list-@index" role="tabpanel" aria-labelledby="content-list-@index">

                    @Code
                        Dim inputKey As String = "ContentModels[" & (index - 1) & "].Key"
                        Dim inputName As String = "ContentModels[" & (index - 1) & "].Name"
                        Dim inputType As String = "ContentModels[" & (index - 1) & "].Type"
                        Dim inputBody As String = "ContentModels[" & (index - 1) & "].Body"
                        Dim inputImage As String = "ContentModels[" & (index - 1) & "].Image"
                End Code

                    <input type="hidden" id="_contentKey_@index" name="@inputKey" value="@baseModel.Key" />
                    <input type="hidden" id="_contentName_@index" name="@inputName" value="@baseModel.Name" />
                    <input type="hidden" id="_contentType_@index" name="@inputType" value="@baseModel.Type" />
                    <input type="hidden" id="_contentBody_@index" name="@inputBody" value="@baseModel.Body" />
                    <input type="hidden" id="_contentImage_@index" name="@inputImage" value="@baseModel.Image" />

                    @* content-editor *@
                    <div class="content-editor" data-content-id="@baseModel.Key">
                      @If baseModel.Type = "Text" Then
                        @<div Class="name-editor">
                          <p Class="name-group-label">Heading:</p>
                          <input type="text" Class="form-control name-field" name="name-field" />
                        </div>

                        @Html.Partial("~/Areas/Admin/Views/Shared/Partials/Editors/TextEditor.vbhtml", baseModel)
                    ElseIf baseModel.Type = "Image" Then
                        @Html.Partial("~/Areas/Admin/Views/Shared/Partials/Editors/ImageEditor.vbhtml", Model.EditorImages)
                    ElseIf baseModel.Type = "Link" Then
                        @Html.Partial("~/Areas/Admin/Views/Shared/Partials/Editors/LinkEditor.vbhtml", baseModel)
                    ElseIf baseModel.Type = "Slide" Then
                        @<div Class="name-editor">
                          <p Class="name-group-label">Heading:</p>
                          <input type="text" Class="form-control name-field" name="name-field" />
                        </div>

                        @Html.Partial("~/Areas/Admin/Views/Shared/Partials/Editors/TextEditor.vbhtml", baseModel)
                        @Html.Partial("~/Areas/Admin/Views/Shared/Partials/Editors/ImageEditor.vbhtml", Model.EditorImages)
                    End If
                    </div>
                  </div>

                  @Code index = index + 1 End Code
                        Next
              </div>
                        End If
          </div>
        </div>
      </div>
    </div>

    @* save-modal *@
    <div class="modal fade" id="save-modal" role="dialog" tabindex="-1" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">
              <i class="fas fa-exclamation-circle"></i> Unsaved Changes
            </h5>
            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
              <i class="fas fa-times"></i>
            </button>
          </div>
          <div class="modal-body">
            <p>There are unsaved changes on this page. Would you like to save your progress before leaving?</p>
          </div>
          <div class="modal-footer">
            <button class="button" type="button" data-dismiss="modal">Back</button>
            <button class="button editor-discard" type="button">Discard</button>
            <button class="button editor-submit" type="submit">Save</button>
          </div>
        </div>
      </div>
    </div>

    @Html.AntiForgeryToken()
  </form>
</div>

<script type="text/javascript">
  var _model = {
    editorModel: @Html.Raw(Json.Encode(Model.EditorModel)),
    editorImages: @Html.Raw(Json.Encode(Model.EditorImages)),
    contentModels: @Html.Raw(Json.Encode(Model.ContentModels)),
    currentType: "@Html.Raw(Model.CurrentEditorType)",
    selectedPageKey: "@Html.Raw(Model.SelectedPageKey)",
    selectedSectionKey: "@Html.Raw(Model.SelectedSectionKey)",
    selectedType: "@Html.Raw(Model.SelectedEditorType)",
    saveCurrent: "@Html.Raw(Model.SaveChanges)",
    displayString: @Html.Raw(Json.Encode(Model.HierarchyString))
  };

  // Set active/show on tabs:
  $("#list-tab").children(":first").addClass("active");
  $("#editor-content").children(":first").addClass("show").addClass("active");
</script>

@Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/admin-pages")
@Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/admin-gallery")
