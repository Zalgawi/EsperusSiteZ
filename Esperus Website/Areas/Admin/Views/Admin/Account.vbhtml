@ModelType Esperus.Areas.Admin.Models.SettingsAccountViewModel
@Code
  ViewData("Title") = "Account"
  Layout = "~/Areas/Admin/Views/Shared/Layouts/_NestedLayout.vbhtml"

  If Model.ViewMessage IsNot Nothing Then
    Html.RenderPartial("~/Areas/Admin/Views/Shared/Partials/Toast.vbhtml", Model.ViewMessage)
  End If
End Code

<div class="container">
  <div class="row">
    <div class="col">
      <div class="account-wrapper">
        <div class="account-container">
          <div class="form-header">
            <h3>Change Account Details</h3>
          </div>

          @Using Html.BeginForm("Account", "Admin", FormMethod.Post, New With {.class = "account-form"})
            @Html.AntiForgeryToken()

            @<div class="row">
              <div class="col">
                <h6>Current Username &amp; Password</h6>
                <div class="form-group input-group">
                  @Html.TextBoxFor(Function(m) m.CurrentUsername, New With {.maxlength = "50", .type = "text", .required = "required", .placeholder = "Current Username", .class = "form-control"})
                  <p>*</p>
                </div>
                <div class="form-group input-group">
                  @Html.TextBoxFor(Function(m) m.CurrentPassword, New With {.maxlength = "50", .type = "password", .required = "required", .placeholder = "Current Password", .class = "form-control"})
                  <p>*</p>
                </div>
                <br />
                <h6>New Username &amp; Password</h6>
                <div class="form-group input-group">
                  @Html.TextBoxFor(Function(m) m.NewUsername, New With {.maxlength = "50", .type = "text", .required = "required", .placeholder = "New Username", .class = "form-control"})
                  <p>*</p>
                </div>
                <div class="form-group input-group">
                  @Html.TextBoxFor(Function(m) m.NewPassword, New With {.maxlength = "50", .type = "password", .required = "required", .placeholder = "New Password", .class = "form-control"})
                  <p>*</p>
                </div>
              </div>
            </div>
            @<div class="row">
              <div class="col-md-3 ml-auto mr-auto">
                <div class="form-group">
                  <button type="submit" value="Send" class="button" id="submit" style="margin-top: 16px;">Submit</button>
                  <p style="margin-top: 8px;">* Required fields.</p>
                </div>
              </div>
            </div>
          End Using
        </div>
      </div>
    </div>
  </div>
</div>

<script type="text/javascript">
    var model = @Html.Raw(Json.Encode(Model));

    if (model.ViewMessage != null) {
        $('#message-toast').toast({
            autohide: true,
            delay: 5000
        });
        $('#message-toast').toast('show');
    }
</script>
