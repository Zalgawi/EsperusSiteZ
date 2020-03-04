@ModelType Esperus.Models.WithdrawViewModel
@Code
  ViewData("Title") = "Withdraw"
  Layout = "~/Views/Shared/Layouts/_SiteLayout.vbhtml"
End Code

<!-- Encode the model so that it can be accessed in JavaScript: -->
<script type="text/javascript">
	var model = @Html.Raw(Json.Encode(Model));
</script>

<div data-admin-page="Page_13">
  @Code Html.RenderPartial("~/Views/Shared/Partials/Sidebar.vbhtml", Model.pageHeadings) End Code

  <header>
    @Code Html.RenderPartial("~/Views/Shared/Partials/Header.vbhtml", Model.pageHeadings) End Code
  </header>

  <div class="content-wrapper">
    @If ViewData("Response") IsNot Nothing Then
      @<div class="container borderless" style="margin-top: 16px;">
        @If ViewData("Response Type") = "Error" Then
          @<div Class="alert alert-warning" role="alert">
            <p>
              @Html.Encode(ViewData("Response"))
            </p>
            <p style="font-size: 10px; margin-bottom: 0;">
              <i>
                @Html.Encode(ViewData("Response Message"))
              </i>
            </p>
          </div>
        Else
          @<div Class="alert alert-success" role="alert">
            @Html.Encode(ViewData("Response"))
          </div>
        End If
      </div>
    End If

    <div class="container" data-admin-section="Section_47">
      <div class="row">
        <div class="col-md-6 ml-auto mr-auto">
          <div class="withdraw-form-wrapper" data-admin-content="Content_102">
            <h1 data-admin-content-header></h1>
            <p data-admin-content-body></p>

            @Using Html.BeginForm("Withdraw", "Home", FormMethod.Post, New With {.class = "withdraw-form", .id = "withdraw-form"})
              @Html.AntiForgeryToken()

              @<div class="row">
                <div class="col-md">
                  <div class="form-group">
                    @Html.TextBoxFor(Function(m) m.WithdrawAddress, New With {.required = "required", .placeholder = "E-Mail", .class = "form-control"})
                    <p>*</p>
                  </div>
                </div>
              </div>
              @<div class="row">
                <div Class="col-md ml-auto mr-auto" style="max-width: unset; flex-grow: 0;">
                  <div class="form-group captcha">
                    @Imports reCAPTCHA.MVC
                    @Using (Html.BeginForm())
                      @Html.Recaptcha()
                      @Html.ValidationMessage("ReCaptcha")
                      @:<button type="submit" value="Send" class="button" id="submit" style="margin-top: 16px;">Submit</button>
                    End Using
                    <p style="margin-top: 16px;">* Required fields.</p>
                  </div>
                </div>
              </div>
            End Using
          </div>
        </div>
      </div>
    </div>
  </div>
</div>

@Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/admin-injector")

@Code Html.RenderPartial("~/Views/Shared/Partials/Footer.vbhtml", Model.pageHeadings) End Code
