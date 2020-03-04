@ModelType Esperus.Models.PageViewModel
@Code
  ViewData("Title") = "Retail"
  Layout = "~/Views/Shared/Layouts/_SiteLayout.vbhtml"
End Code

<!-- Encode the model so that it can be accessed in JavaScript: -->
<script type="text/javascript">
	var model = @Html.Raw(Json.Encode(Model));
</script>

<div data-admin-page="Page_2">
  @Code Html.RenderPartial("~/Views/Shared/Partials/Sidebar.vbhtml", Model.pageHeadings) End Code

  <header>
    @Code Html.RenderPartial("~/Views/Shared/Partials/Header.vbhtml", Model.pageHeadings) End Code

    <div id="upper-content">
      <div class="header-image" style="background-image: url('@TempData("Background")');"></div>
      <div class="legand-overlay"></div>
      <div class="legand-content container" data-admin-section="Section_34">
        <div class="legand-content-inner" data-admin-content="Content_52">
          <h1 class="legand-header" data-admin-content-header></h1>
          <p class="legand-body" data-admin-content-body></p>
        </div>
      </div>
    </div>
  </header>

  <div class="content-wrapper bordered">
    <div class="container-fluid separator" data-admin-section="Section_1">
      <div class="container">
        <div class="row align-items-center justify-content-center">
          <div class="col col-md-8 align-self-center ml-auto mr-auto">
            <div class="page-title" data-admin-content="Content_1">
              <h1 data-admin-content-header></h1>
              <p data-admin-content-body></p>

              <div data-admin-content="Content_87">
                <a style="margin: 0; width: 152px;" class="button" href="" target="_blank" data-admin-content-link>
                  <img class="link-icon" src="~/Content/Images/Icons/link-icon-w-f-1.png" />
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    @*<div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_54">
      <div class="row">
        <div class="col col-md-6 align-self-center">
          <div class="col-row" data-admin-content="Content_139">
            <h1 data-admin-content-header></h1>
            <div data-admin-content-body></div>
          </div>
        </div>
        <div class="col-md-6 mobile-disable align-self-center" data-admin-content="Content_140">
          <img class="body-image right" data-admin-content-image />
        </div>
      </div>
    </div>*@

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_2">
      <div class="row">
        <div class="col col-md-6" data-admin-content="Content_2">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
        <div class="col col-md-6" data-admin-content="Content_3">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
      </div>
    </div>

    <div class="container-fluid separator" data-admin-section="Section_3">
      <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom">
        <div class="row align-items-center justify-content-center">
          <div class="col col-md-9 align-self-center ml-auto mr-auto" data-admin-content="Content_4">
            <h3 data-admin-content-header></h3>
          </div>
        </div>
        <div class="row align-items-center justify-content-center">
          <div data-admin-content="Content_67">
            <img style="max-width: 128px; margin-right: 32px;" alt="Aures" data-admin-content-image />
          </div>
          <div data-admin-content="Content_68">
            <img style="max-width: 128px;" alt="VeriFone" data-admin-content-image />
          </div>
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_4">
      <div class="row">
        <div class="col col-md-3 ml-auto" data-admin-content="Content_5">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
        <div class="col col-md-3 mr-auto" data-admin-content="Content_6">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
        <div class="col col-md-3 ml-auto" data-admin-content="Content_7">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
        <div class="col col-md-3 mr-auto" data-admin-content="Content_8">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
      </div>
    </div>

    <div class="container-fluid separator" data-admin-section="Section_5">
      <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom">
        <div class="row align-items-center justify-content-center">
          <div class="col col-md-9 align-self-center ml-auto mr-auto" data-admin-content="Content_9">
            <h3 data-admin-content-header></h3>
            <p data-admin-content-body></p>
          </div>
        </div>
        <div class="row mobile-disable align-items-center justify-content-center">
          <div data-admin-content="Content_69">
            <img style="max-width: 128px; margin-right: 32px;" alt="John Lewis" data-admin-content-image />
          </div>
          <div data-admin-content="Content_70">
            <img style="max-width: 128px; margin-right: 32px;" alt="Debenhams" data-admin-content-image />
          </div>
          <div data-admin-content="Content_71">
            <img style="max-width: 128px; margin-right: 32px;" alt="House of Fraser" data-admin-content-image />
          </div>
          <div data-admin-content="Content_72">
            <img style="max-width: 128px; margin-right: 32px;" alt="Boundary Mill" data-admin-content-image />
          </div>
          <div data-admin-content="Content_73">
            <img style="max-width: 128px;" alt="Arnotts" data-admin-content-image />
          </div>
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_6">
      <div class="row align-items-center justify-content-center">
        <div class="col col-md-6 align-self-center" data-admin-content="Content_10">
          <h1 data-admin-content-header></h1>
          <div data-admin-content-body></div>

          <div data-admin-content="Content_88">
            <a class="button body-button wide" href="" target="_blank" data-admin-content-link>
              <img class="link-icon" src="~/Content/Images/Icons/link-icon-w-f-1.png" />
            </a>
          </div>
        </div>
        <div class="col-md-6 align-self-center" data-admin-content="Content_74">
          <img class="body-image right transparent" data-admin-content-image />
        </div>
      </div>
    </div>

    <div class="container-fluid separator" data-admin-section="Section_7">
      <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom">
        <div class="row align-items-center justify-content-center">
          <div class="col col-md-8 align-self-center ml-auto mr-auto" data-admin-content="Content_11">
            <div class="page-title">
              <h1 data-admin-content-header></h1>
              <p data-admin-content-body></p>

              <div data-admin-content="Content_89">
                <a style="margin: 0; width: 152px;" class="button" href="" target="_blank" data-admin-content-link>
                  <img class="link-icon" src="~/Content/Images/Icons/link-icon-w-f-1.png" />
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_8">
      <div class="row align-items-center justify-content-center">
        <div class="col col-md-6 align-self-center" data-admin-content="Content_12">
          <h1 data-admin-content-header></h1>
          <div data-admin-content-body></div>
        </div>
        <div class="col-md-6 mobile-disable align-self-center col-img-bottom" data-admin-content="Content_75">
          <img class="body-image right" data-admin-content-image />
        </div>
      </div>
    </div>

    <div class="container-fluid separator" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_9">
      <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom">
        <div class="row align-items-center justify-content-center">
          <div class="col col-md-4 mobile-disable" data-admin-content="Content_76">
            <img class="body-image logo" data-admin-content-image />
          </div>
          <div class="col col-md-8 align-self-center quote-wrapper" data-admin-content="Content_13">
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
