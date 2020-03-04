@ModelType List(Of Esperus.Models.DirectoryItem)

<div class="gallery-wrapper">
  <div class="image-gallery">
    @Code
      Dim totalSize As Decimal = 0
    End Code

    @For Each image As Esperus.Models.DirectoryItem In Model
      Dim currentSize As Decimal = Convert.ToDecimal(image.Size)
      totalSize = totalSize + currentSize
    Next

    <div class="gallery-actions">
      <button type="button" class="button gallery-clear">Clear Selection</button>
      <p class="total-file-size">Total: <b>@totalSize<span>MB</span></b> approx. (all)</p>
      <p class="">Count: <b>@Model.Count</b> (all)</p>
      <p class="enlarge"><i class="fas fa-image"></i> <i class="fas fa-mouse-pointer"></i> <b>Preview</b></p>
    </div>

    <div class="gallery">
      <div class="gallery-container">
        <h1 class="gallery-header">Uploaded</h1>

        <div class="gallery-inner">
          @For Each image As Esperus.Models.DirectoryItem In Model
            @If image.Type = Models.DirectoryItemType.Uploaded Then
              @<div class="card">
                <a class="image-preview" href="@image.RelativePath" target="_blank" style="background-image: url('@Url.Content(image.RelativePath)')"></a>

                <div class="card-body">
                  <p class="card-title">@image.DisplayName</p>
                  <p class="card-subtitle">@image.Name</p>
                  <p>@image.Size<span>MB</span> approx.</p>
                  <p>@image.Dimentions</p>
                </div>

                <div class="card-actions">
                  <div class="button-row">
                    <input type="hidden" name="_imagePath" id="_imagePath" value="@image.RelativePath" />
                    <button type="button" class="button card-button select-image"><i class="fas fa-check"></i> Select</button>
                  </div>
                </div>
              </div>
            End If
          Next
        </div>
      </div>

      <div class="gallery-container">
        <h1 class="gallery-header">Provided</h1>

        <div class="gallery-inner">
          @For Each image As Esperus.Models.DirectoryItem In Model
            @If image.Type = Models.DirectoryItemType.Provided Then
              @<div class="card">
                <a class="image-preview" href="@image.RelativePath" target="_blank" style="background-image: url('@Url.Content(image.RelativePath)')"></a>

                <div class="card-body">
                  <p class="card-title">@image.DisplayName</p>
                  <p class="card-subtitle">@image.Name</p>
                  <p>@image.Size<span>MB</span> approx.</p>
                  <p>@image.Dimentions</p>
                </div>

                <div class="card-actions">
                  <div class="button-row">
                    <input type="hidden" name="_imagePath" id="_imagePath" value="@image.RelativePath" />
                    <button type="button" class="button card-button select-image"><i class="fas fa-check"></i> Select</button>
                  </div>
                </div>
              </div>
            End If
          Next
        </div>
      </div>
    </div>
  </div>
</div>
