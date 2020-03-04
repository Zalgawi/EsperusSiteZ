@ModelType Esperus.Areas.Admin.Models.ImagesViewModel
@Code
  ViewData("Title") = "Images"
  Layout = "~/Areas/Admin/Views/Shared/Layouts/_NestedLayout.vbhtml"
End Code

@Code
  Dim totalSizeUploaded As Decimal = 0
  Dim totalSizeProvided As Decimal = 0
  Dim totalCountUploaded As Integer = 0
  Dim totalCountProvided As Integer = 0
End Code

@For Each image As Esperus.Models.DirectoryItem In Model.Images
  If image.Type = Models.DirectoryItemType.Uploaded Then
    Dim currentSize As Decimal = Convert.ToDecimal(image.Size)
    totalSizeUploaded = totalSizeUploaded + currentSize
    totalCountUploaded += 1
  ElseIf image.Type = Models.DirectoryItemType.Provided Then
    Dim currentSize As Decimal = Convert.ToDecimal(image.Size)
    totalSizeProvided = totalSizeProvided + currentSize
    totalCountProvided += 1
  End If
Next

<div class="container">
  <div class="gallery-wrapper">
    <div class="gallery-header">
      <h1>Uploads</h1>
      <p>These are the images you've uploaded after-the-fact. <b>You can add to, modify and delete any of these images</b>.</p>
    </div>

    <div class="image-gallery">
      <div class="gallery-actions">
        <button type="submit" Class="button upload-dialog"><i Class="fas fa-upload"></i> Upload</button>
        <p class="total-file-size">Total: <b>@totalSizeUploaded<span>MB</span></b> approx.</p>
        <p class="">Count: <b>@totalCountUploaded</b></p>
        <p class="enlarge"><i class="fas fa-image"></i> <i class="fas fa-mouse-pointer"></i> <b>Preview</b></p>
      </div>

      <div class="gallery full-spread">
        @For Each image As Esperus.Models.DirectoryItem In Model.Images
          If image.Type = Models.DirectoryItemType.Uploaded Then
            @<div class="card">
              <a class="image-preview" href="@image.RelativePath" target="_blank" style="background-image: url('@Url.Content(image.RelativePath)')"></a>

              <div class="card-body">
                <p class="card-title">@image.DisplayName</p>
                <p class="card-subtitle">@image.Name</p>
                <p>@image.Size<span>MB</span> approx.</p>
                <p>@image.Dimentions</p>
              </div>

              <div class="card-actions">
                @Using Html.BeginForm("DeleteImage", "Admin", FormMethod.Post, New With {.class = "button-row"})
                  @<input type="hidden" name="selectedImageName" id="selectedImageName" value="@image.Name" />
                  @<input type="hidden" name="selectedImagePath" id="selectedImagePath" value="@image.RelativePath" />
                  @<button type="submit" class="button card-button"><i class="fas fa-trash-alt"></i> Delete</button>
                End Using
              </div>
            </div>
          End If
        Next
      </div>
    </div>
  </div>

  <div class="gallery-wrapper">
    <div class="gallery-header">
      <h1>Provided</h1>
      <p>These are images that have come with your website by default; <b>you can't delete these images</b>.</p>
    </div>

    <div class="image-gallery">
      <div class="gallery-actions">
        <p class="total-file-size">Total: <b>@totalSizeProvided<span>MB</span></b> approx.</p>
        <p class="">Count: <b>@totalCountProvided</b></p>
        <p class="enlarge"><i class="fas fa-image"></i> <i class="fas fa-mouse-pointer"></i> <b>Preview</b></p>
      </div>

      <div class="gallery full-spread">
        @For Each image As Esperus.Models.DirectoryItem In Model.Images
          If image.Type = Models.DirectoryItemType.Provided Then
            @<div class="card">
              <a class="image-preview" href="@image.RelativePath" target="_blank" style="background-image: url('@Url.Content(image.RelativePath)')"></a>

              <div class="card-body">
                <p class="card-title">@image.DisplayName</p>
                <p class="card-subtitle">@image.Name</p>
                <p>@image.Size<span>MB</span> approx.</p>
                <p>@image.Dimentions</p>
              </div>
            </div>
          End If
        Next
      </div>
    </div>
  </div>
</div>

@* gallery-save-modal *@
<div class="modal fade" id="gallery-save-modal" role="dialog" tabindex="-1" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">
          <i class="fas fa-exclamation-circle"></i> Unspecified File
        </h5>
        <button class="close" type="button" data-dismiss="modal" aria-label="Close">
          <i class="fas fa-times"></i>
        </button>
      </div>
      <div class="modal-body">
        <p>Please select a file to upload and specify a name.</p>
      </div>
      <div class="modal-footer">
        <button class="button" type="button" data-dismiss="modal">Back</button>
      </div>
    </div>
  </div>
</div>

@* gallery-upload-modal *@
<div class="modal fade" id="gallery-upload-modal" role="dialog" tabindex="-1" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">
          <i class="fas fa-exclamation-circle"></i> Upload Image
        </h5>
        <button class="close" type="button" data-dismiss="modal" aria-label="Close">
          <i class="fas fa-times"></i>
        </button>
      </div>

      @Using Html.BeginForm("UploadImage", "Admin", FormMethod.Post, New With {.enctype = "multipart/form-data", .class = "upload-form"})
        @<div class="modal-body">
          <div class="form-row">
            <div class="form-group col-md-12" id="name-group">
              <label for="imageName">Name:</label>
              <input type="text" name="imageName" id="imageName" class="form-control" placeholder="" disabled="disabled" />
            </div>
            <div class="form-group col-md-12" id="name-group">
              <label for="imageDir">Path:</label>
              <input type="text" name="imageDir" id="imageDir" class="form-control" placeholder="" disabled="disabled" />
            </div>
            <div class="form-group col-md-12">
              <label for="imagePath">Please select a file to upload</label>
              <input type="file" name="imagePath" id="imagePath" required="required" />
            </div>
          </div>
        </div>
        @<div class="modal-footer">
          <button type="submit" class="button gallery-upload"><i class="fas fa-upload"></i> Confirm</button>
          <button class="button" type="button" data-dismiss="modal"><i class="fas fa-chevron-left"></i> Back</button>
        </div>
      End Using
    </div>
  </div>
</div>

<script type="text/javascript">
  var model = @Html.Raw(Json.Encode(Model));
</script>

@Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/admin-gallery")
