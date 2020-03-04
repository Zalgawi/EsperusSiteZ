@ModelType Esperus.Models.PageViewModel
@Code
  ViewData("Title") = "Wholesale"
  Layout = "~/Views/Shared/Layouts/_SiteLayout.vbhtml"
End Code

<!-- Encode the model so that it can be accessed in JavaScript: -->
<script type="text/javascript">
	var model = @Html.Raw(Json.Encode(Model));
</script>

<div data-admin-page="Page_3">
  @Code Html.RenderPartial("~/Views/Shared/Partials/Sidebar.vbhtml", Model.pageHeadings) End Code

  <header>
    @Code Html.RenderPartial("~/Views/Shared/Partials/Header.vbhtml", Model.pageHeadings) End Code

    <div id="upper-content">
      <div class="header-image" style="background-image: url('@TempData("Background")');"></div>
      <div class="legand-overlay"></div>
      <div class="legand-content container" data-admin-section="Section_35">
        <div class="legand-content-inner" data-admin-content="Content_53">
          <h1 class="legand-header" data-admin-content-header></h1>
          <p class="legand-body" data-admin-content-body></p>
        </div>
      </div>
    </div>
  </header>

  <div class="content-wrapper bordered">
    <div class="container-fluid separator" data-admin-section="Section_10">
      <div class="container">
        <div class="row align-items-center justify-content-center">
          <div class="col col-md-8 align-self-center ml-auto mr-auto">
            <div class="page-title" data-admin-content="Content_15">
              <h1 data-admin-content-header></h1>
              <p data-admin-content-body></p>

              <div data-admin-content="Content_90">
                <a style="margin: 0; width: 152px;" class="button" href="" target="_blank" data-admin-content-link>
                  <img class="link-icon" src="~/Content/Images/Icons/link-icon-w-f-1.png" />
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_13">
      <div class="row align-items-center justify-content-center">
        <div class="col col-md-6 align-self-center" data-admin-content="Content_80">
          <img class="body-image left mobile-disable" alt="home-image-3-1" data-admin-content-image />
        </div>
        <div class="col col-md-6 align-self-center" data-admin-content="Content_23">
          <h1 data-admin-content-header></h1>
          <div data-admin-content-body></div>
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_11">
      <div class="row">
        <div class="col col-md-4" data-admin-content="Content_16">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
        <div class="col col-md-4" data-admin-content="Content_17">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
        <div class="col col-md-4" data-admin-content="Content_18">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
      </div>
    </div>

    <div class="container-fluid separator" data-admin-section="Section_12">
      <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom">
        <div class="row align-items-center justify-content-center">
          <div class="col col-md-6 align-self-center ml-auto mr-auto" data-admin-content="Content_22">
            <h3 data-admin-content-header></h3>
            <p data-admin-content-body></p>
          </div>
        </div>
        <div class="row align-items-center justify-content-center" style="margin-top: 16px;">
          <div data-admin-content="Content_77">
            <img style="max-width: 128px; margin-right: 32px;" alt="Sage" data-admin-content-image />
          </div>
          <div data-admin-content="Content_78">
            <img style="max-width: 92px; margin-right: 32px;" alt="Pegasus" data-admin-content-image />
          </div>
          <div data-admin-content="Content_79">
            <img style="max-width: 64px;" alt="Xero" data-admin-content-image />
          </div>
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_14">
      <div class="row align-items-center justify-content-center">
        <div class="col col-md-6 align-self-center" data-admin-content="Content_24">
          <h1 data-admin-content-header></h1>
          <div data-admin-content-body></div>
        </div>
        <div class="col col-md-6 align-self-center" data-admin-content="Content_81">
          <img class="body-image right" alt="wholesale-image-1-1" data-admin-content-image />
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_11">
      <div class="row">
        <div class="col col-md-4" data-admin-content="Content_19">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
        <div class="col col-md-4" data-admin-content="Content_20">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
        <div class="col col-md-4" data-admin-content="Content_21">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
      </div>
    </div>

    <div class="container-fluid separator" data-admin-section="Section_15">
      <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom">
        <div class="row align-items-center justify-content-center">
          <div class="col col-md-4 mobile-disable align-self-center" data-admin-content="Content_82">
            <img class="body-image logo" data-admin-content-image />
          </div>
          <div class="col col-md-8 align-self-center quote-wrapper" data-admin-content="Content_25">
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
