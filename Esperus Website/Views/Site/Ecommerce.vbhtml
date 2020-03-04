@ModelType Esperus.Models.PageViewModel
@Code
  ViewData("Title") = "Ecommerce"
  Layout = "~/Views/Shared/Layouts/_SiteLayout.vbhtml"
End Code

<!-- Encode the model so that it can be accessed in JavaScript: -->
<script type="text/javascript">
	var model = @Html.Raw(Json.Encode(Model));
</script>

<div data-admin-page="Page_4">
  @Code Html.RenderPartial("~/Views/Shared/Partials/Sidebar.vbhtml", Model.pageHeadings) End Code

  <header>
    @Code Html.RenderPartial("~/Views/Shared/Partials/Header.vbhtml", Model.pageHeadings) End Code

    <div id="upper-content">
      <div class="header-image" style="background-image: url('@TempData("Background")');"></div>
      <div class="legand-overlay"></div>
      <div class="legand-content container" data-admin-section="Section_36">
        <div class="legand-content-inner" data-admin-content="Content_54">
          <h1 class="legand-header" data-admin-content-header></h1>
          <p class="legand-body" data-admin-content-body></p>
        </div>
      </div>
    </div>
  </header>

  <div class="content-wrapper bordered">
    <div class="container-fluid separator" data-admin-section="Section_16">
      <div class="container">
        <div class="row align-items-center justify-content-center">
          <div class="col col-md-8 align-self-center ml-auto mr-auto">
            <div class="page-title" data-admin-content="Content_26">
              <h1 data-admin-content-header></h1>
              <p data-admin-content-body></p>

              <div data-admin-content="Content_91">
                <a style="margin: 0; width: 152px;" class="button" href="" target="_blank" data-admin-content-link>
                  <img class="link-icon" src="~/Content/Images/Icons/link-icon-w-f-1.png" />
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_17">
      <div class="row align-items-center justify-content-center">
        <div class="col col-md-6 ml-auto" data-admin-content="Content_27">
          <h1 data-admin-content-header></h1>
          <div data-admin-content-body></div>
        </div>
        <div class="col col-md-6 mr-auto" data-admin-content="Content_83">
          <img class="body-image right" alt="ecommerce-image-1-1" data-admin-content-image />
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_18">
      <div class="row align-items-center justify-content-center">
        <div class="col col-md-6 mr-auto" data-admin-content="Content_84">
          <img class="body-image left" alt="body-image-2" data-admin-content-image />
        </div>
        <div class="col col-md-6 ml-auto" data-admin-content="Content_28">
          <h1 data-admin-content-header></h1>
          <div data-admin-content-body></div>
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_19">
      <div class="row align-items-center justify-content-center">
        <div class="col col-md-8 ml-auto mr-auto" data-admin-content="Content_29">
          <h2 class="center-text" data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
      </div>
    </div>

    <div class="container-fluid separator" data-admin-section="Section_20">
      <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom">
        <div class="row align-items-center justify-content-center">
          <div class="col col-md-4 mobile-disable" data-admin-content="Content_85">
            <img class="body-image logo" data-admin-content-image />
          </div>
          <div class="col col-md-8 quote-wrapper" data-admin-content="Content_30">
            <div class="quote-content">
              <p class="quote-body" data-admin-content-body></p>
              <p class="quote-author" data-admin-content-header></p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>

@Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/admin-injector")

@Code Html.RenderPartial("~/Views/Shared/Partials/Footer.vbhtml", Model.pageHeadings) End Code
