@ModelType Esperus.Areas.Admin.Models.LoginViewModel
@Code
  ViewData("Title") = "Login"
  Layout = "~/Areas/Admin/Views/Shared/Layouts/_AdminLayout.vbhtml"

  If Model.loginMessage IsNot Nothing Then
    Html.RenderPartial("~/Areas/Admin/Views/Shared/Partials/Toast.vbhtml", Model.loginMessage)
  End If
End Code

<div class="login-wrapper">
  <div class="login-container">
    <div class="login-header">
      <h3>Welcome.</h3>

      @If Model.loginAttempts > 0 AndAlso Model.loginAttempts < 2 Then
        @<p class="login-attempt">You have made <b>@Model.loginAttempts</b> login attempt.</p>
      ElseIf Model.loginAttempts = 3 Then
        @<p class="login-attempt">You have made <b>@Model.loginAttempts</b> or more login attempts.</p>
        @<p class="login-attempt">You will now need to authenticate yourself in order to proceed.</p>
      ElseIf Model.loginAttempts > 0 Then
        @<p class="login-attempt">You have made <b>@Model.loginAttempts</b> login attempts.</p>
      End If
    </div>

    @Using Html.BeginForm("Login", "Admin", FormMethod.Post, New With {.class = "login-form"})
      @Html.AntiForgeryToken()

      @Html.HiddenFor(Function(m) m.loginAttempts, Model.loginAttempts)
      @Html.HiddenFor(Function(m) m.captchaEnabled, Model.captchaEnabled)

      @<div class="form-row login-row">
        <div class="col">
          <div class="form-group">
            @Html.TextBoxFor(Function(m) m.inputUsername, New With {.maxlength = "50", .type = "text", .required = "required", .placeholder = "Username", .class = "form-control"})
          </div>
          <div class="form-group">
            @Html.TextBoxFor(Function(m) m.inputPassword, New With {.maxlength = "50", .type = "password", .required = "required", .placeholder = "Password", .class = "form-control"})
          </div>
        </div>
      </div>

      @If Model.captchaEnabled Then
        @<div class="form-row">
          <div class="col">
            <div class="form-group captcha">
              @Imports reCAPTCHA.MVC
              @Using (Html.BeginForm())
                @Html.Recaptcha()
                @Html.ValidationMessage("ReCaptcha")
                @<button type="submit" value="Send" class="button login-submit" id="submit" style="margin-top: 16px;">
                  <i class="fas fa-sign-in-alt"></i> Login
                </button>
              End Using
            </div>
          </div>
        </div>
      Else
        @<div class="form-row button-row">
          <div class="col">
            <button type="submit" value="Send" class="button login-submit" id="submit">
              <i class="fas fa-sign-in-alt"></i> Login
            </button>
            <a class="button" href="/">
              <i class="fas fa-sign-out-alt"></i> Back
            </a>
          </div>
        </div>
      End If
    End Using
  </div>

  <div class="login-footer">
    <p class="login-notice">&copy; 2019 Esperus Systems Limited. All rights reserved.</p>
  </div>
</div>

<script type="text/javascript">
    var model = @Html.Raw(Json.Encode(Model));

    if (model.loginMessage != null) {
        $('#message-toast').toast({
            autohide: true,
            delay: 5000
        });
        $('#message-toast').toast('show');
    }
</script>
