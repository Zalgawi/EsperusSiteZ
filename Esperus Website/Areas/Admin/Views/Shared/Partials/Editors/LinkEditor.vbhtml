@ModelType Esperus.Areas.Admin.Models.BaseEditorModel

<div class="link-editor">
    <div class="form-row link-row">
        <div class="form-group">
            @Html.LabelFor(Function(m) m.Name, "Name")
            @Html.TextBoxFor(Function(m) m.Name, New With {.class = "form-control", .id = "link-name", .value = Model.Body, .name = "link-name"})
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.Body, "URL")
            @Html.TextBoxFor(Function(m) m.Body, New With {.class = "form-control", .id = "link-url", .value = Model.Image, .name = "link-url"})
        </div>
    </div>
</div>
