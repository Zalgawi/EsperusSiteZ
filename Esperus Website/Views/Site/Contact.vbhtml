@ModelType Esperus.Models.ContactViewModel
@Code
  ViewData("Title") = "Contact"
  Layout = "~/Views/Shared/Layouts/_SiteLayout.vbhtml"
End Code

<!-- Encode the model so that it can be accessed in JavaScript: -->
<script type="text/javascript">
	var model = @Html.Raw(Json.Encode(Model));
</script>

<div data-admin-page="Page_8">
  @Code Html.RenderPartial("~/Views/Shared/Partials/Sidebar.vbhtml", Model.pageHeadings) End Code

  <header>
    @Code Html.RenderPartial("~/Views/Shared/Partials/Header.vbhtml", Model.pageHeadings) End Code

    <div id="upper-content">
      <div class="header-image" style="background-image: url('@TempData("Background")');"></div>
      <div class="legand-overlay"></div>
      <div class="legand-content container" data-admin-section="Section_41">
        <div class="legand-content-inner" data-admin-content="Content_96">
          <h1 class="legand-header" data-admin-content-header></h1>
          <p class="legand-body" data-admin-content-body></p>
        </div>
      </div>
    </div>
  </header>

  <div class="content-wrapper bordered">
    @If ViewData("Response") IsNot Nothing Then
      @<div class="container borderless" style="margin-top: 16px;">
        @If ViewData("Response Type") = "Error" Then
          @<div Class="alert alert-warning" role="alert">
            <p style="margin-bottom: 0;">
              @Html.Encode(ViewData("Response"))
            </p>
          </div>
        Else
          @<div Class="alert alert-success" role="alert">
            @Html.Encode(ViewData("Response"))
          </div>
        End If
      </div>
    End If

    <div class="container borderless">
      <div class="row">
        <div class="col col-md-6 mr-auto">
          <h1 class="mobile-center">Contact Information</h1>
          <div>
            <div class="row">
              <div class="col col-md-6">
                <p>
                  <b>Esperus Systems Limited</b><br />
                  Southgate Office Village<br />
                  288 Chase Road<br />
                  London<br />
                  United Kingdom<br />
                  N14 6HF<br />
                </p>
              </div>
              <div class="col col-md-6">
                <a class="d-block" href="tel:+442089209888">
                  <i class="fas fa-phone"></i> +44 (0)20 8920 9888
                </a>
                <a class="d-block" href="mailto:info@esperus.com">
                  <i class="fas fa-envelope"></i> info@esperus.com
                </a>
                <br />
                <a class="d-block" href="https://www.google.com/maps/place/Esperus+Systems/51.633442,-0.1292979,17z/data=!3m1!4b1!4m5!3m4!1s0x4876191baa682457:0x7e18769a23e9f33c!8m2!3d51.633442!4d-0.1271092" rel="noreferrer" target="_blank">
                  <i class="fas fa-map-marker-alt"></i> Google Maps
                </a>
                <br />
                <a class="contact-social" href="https://www.instagram.com/esperus_systems/" rel="noreferrer" target="_blank">
                  <i class="fab fa-instagram"></i>
                </a>
                <a class="contact-social" href="https://www.twitter.com/Esperus/" rel="noreferrer" target="_blank">
                  <i class="fab fa-twitter-square"></i>
                </a>
                <a class="contact-social" href="https://www.facebook.com/Esperus/" rel="noreferrer" target="_blank">
                  <i class="fab fa-facebook-square contact"></i>
                </a>
                <a class="contact-social" href="https://www.linkedin.com/company/esperus/" rel="noreferrer" target="_blank">
                  <i class="fab fa-linkedin contact"></i>
                </a>

              </div>
            </div>
          </div>

          <br /><br />

          <h1 class="mobile-center">Hardware Partner</h1>
          <div>
            <div class="row">
              <div class="col col-md-6">
                <p>
                  <b>Bytek IT Solutions Limited</b><br />
                  Unit 28<br />
                  Woodbine Business Park<br />
                  New Ross<br />
                  County Wexford<br />
                  Ireland<br />
                </p>
              </div>
              <div class="col col-md-6">
                <a class="d-block" href="tel:+35351426200">
                  <i class="fas fa-phone"></i> +353 (0)51 426 200
                </a>
                <a class="d-block" href="mailto:info@bytek.ie">
                  <i class="fas fa-envelope"></i> info@bytek.ie
                </a>
                <a class="d-block" href="https://www.bytek.ie/" rel="noreferrer" target="_blank">
                  <img class="link-icon" src="~/Content/Images/Icons/link-icon-w-1.png" style="margin-right: 2px;" /> https://www.bytek.ie
                </a>
                <br />
              </div>
            </div>
          </div>
        </div>
        <div class="col col-md-6 ml-auto align-self-center">
          <div class="form-wrapper ml-auto mr-auto">
            @Using Html.BeginForm("Contact", "Home", FormMethod.Post, New With {.class = "contact-form", .id = "contact-form"})
              @<div class="row">
                <div class="col">
                  <div class="form-row">
                    <div class="col-11">
                      @Html.TextBoxFor(Function(m) m.RequestFormName, New With {.required = "required", .placeholder = "Name", .class = "form-control form-input"})
                    </div>
                    <div class="col required-row">
                      <p>*</p>
                    </div>
                  </div>
                  <div class="form-row">
                    <div class="col-11">
                      @Html.TextBoxFor(Function(m) m.RequestFormCompany, New With {.required = "required", .placeholder = "Company", .class = "form-control form-input"})
                    </div>
                    <div class="col required-row">
                      <p>*</p>
                    </div>
                  </div>
                  <div class="form-row">
                    <div class="col-11">
                      @Html.TextBoxFor(Function(m) m.RequestFormEmail, New With {.required = "required", .placeholder = "E-Mail Address", .class = "form-control form-input"})
                    </div>
                    <div class="col required-row">
                      <p>*</p>
                    </div>
                  </div>
                  <div class="form-row">
                    <div class="col-2">
                      @Html.TextBoxFor(Function(m) m.RequestFormCallingCode, New With {.placeholder = "(code)", .class = "form-control form-input"})
                    </div>
                    <div class="col-7" id="telephone-field">
                      @Html.TextBoxFor(Function(m) m.RequestFormTelephone, New With {.required = "required", .placeholder = "Telephone", .class = "form-control form-input"})
                    </div>
                    <div class="col-2">
                      @Html.TextBoxFor(Function(m) m.RequestFormExtension, New With {.placeholder = "(ext/opt)", .class = "form-control form-input"})
                    </div>
                    <div class="col required-row">
                      <p>*</p>
                    </div>
                  </div>
                  <div class="form-row">
                    <div class="col-11">
                      @Html.DropDownListFor(Function(m) m.RequestFormInterest, Model.Interests, New With {.required = "required", .class = "form-control custom-select form-input"})
                    </div>
                    <div class="col required-row">
                      <p>*</p>
                    </div>
                  </div>
                  <div class="form-row">
                    <div class="col-11">
                      @Html.DropDownListFor(Function(m) m.RequestFormReferer, Model.Referers, New With {.required = "required", .class = "form-control custom-select form-input"})
                    </div>
                    <div class="col required-row">
                      <p>*</p>
                    </div>
                  </div>
                  <div class="form-row">
                    <div class="col-12">
                      @Html.TextAreaFor(Function(m) m.RequestFormMessage, New With {.rows = "6", .placeholder = "Please leave a message", .class = "form-control form-input"})
                    </div>
                  </div>
                  <div class="form-row form-consent">
                    <div class="col-12">
                      @Html.CheckBoxFor(Function(m) m.RequestDemo, True)
                      @Html.LabelFor(Function(m) m.RequestDemo, "Would you like to request a demo of our products and services?")
                    </div>
                  </div>
                  <div class="form-row form-consent">
                    <div class="col-12">
                      @Html.CheckBoxFor(Function(m) m.RequestContactConsent, True)
                      @Html.LabelFor(Function(m) m.RequestContactConsent, "Would you like to recieve updates regarding our products?")
                    </div>
                  </div>
                </div>
              </div>
              @<div class="row captcha-row">
                <div Class="col ml-auto mr-auto">
                  <div class="form-row captcha">
                    <div class="col-12">
                      @Imports reCAPTCHA.MVC
                      @Using (Html.BeginForm())
                        @Html.Recaptcha(callback:="form_recaptcha_callback")
                        @Html.ValidationMessage("ReCaptcha")
                        @<button type="submit" value="Send" class="button form-submit" id="submit" style="margin-top: 16px; display: none;">
                          Submit
                        </button>
                      End Using
                      <p style="margin-top: 16px; font-weight: 700;">
                        * Required
                      </p>
                    </div>
                  </div>
                </div>
              </div>

              @Html.AntiForgeryToken()
            End Using
          </div>
        </div>
      </div>
    </div>
  </div>
</div>

@Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/admin-injector")

@Code Html.RenderPartial("~/Views/Shared/Partials/Footer.vbhtml", Model.pageHeadings) End Code
