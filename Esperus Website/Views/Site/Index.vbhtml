@ModelType Esperus.Models.PageViewModel
@Code
  ViewData("Title") = "Home"
  Layout = "~/Views/Shared/Layouts/_SiteLayout.vbhtml"
End Code

<!-- Encode the model so that it can be accessed in JavaScript: -->
<script type="text/javascript">
	var model = @Html.Raw(Json.Encode(Model));
</script>

<div data-admin-page="Page_1">
  @Code Html.RenderPartial("~/Views/Shared/Partials/Sidebar.vbhtml", Model.pageHeadings) End Code

  <header>
    @Code Html.RenderPartial("~/Views/Shared/Partials/Header.vbhtml", Model.pageHeadings) End Code

    <div id="upper-content">
      <div id="header-carousel" class="carousel slide carousel-fade" data-ride="carousel">
        <ol class="carousel-indicators">
          <li class="indicator active" data-target="#header-carousel" data-slide-to="0"></li>
          <li class="indicator" data-target="#header-carousel" data-slide-to="1"></li>
          <li class="indicator" data-target="#header-carousel" data-slide-to="2"></li>
          <li class="indicator" data-target="#header-carousel" data-slide-to="3"></li>
          <li class="indicator" data-target="#header-carousel" data-slide-to="4"></li>
        </ol>

        <div class="carousel-inner" data-admin-section="Section_33">
          <div class="carousel-item active" data-admin-content="Content_47">
            <div class="header-image" data-admin-content-background></div>
            <div class="carousel-overlay"></div>
            <div class="carousel-caption d-md-block">
              <div class="carousel-caption-inner">
                <h1 class="slide-header" data-animation="animated fadeInUp" data-admin-content-header></h1>
                <div class="slide-body" data-animation="animated fadeInUp" data-admin-content-body></div>
              </div>
            </div>
          </div>

          <div class="carousel-item" data-admin-content="Content_48">
            <div class="header-image" data-admin-content-background></div>
            <div class="carousel-overlay"></div>
            <div class="carousel-caption d-md-block">
              <div class="carousel-caption-inner">
                <h1 class="slide-header" data-animation="animated fadeInUp" data-admin-content-header></h1>
                <div class="slide-body" data-animation="animated fadeInUp" data-admin-content-body></div>
              </div>
            </div>
          </div>

          <div class="carousel-item" data-admin-content="Content_49">
            <div class="header-image" data-admin-content-background></div>
            <div class="carousel-overlay"></div>
            <div class="carousel-caption d-md-block">
              <div class="carousel-caption-inner">
                <h1 class="slide-header" data-animation="animated fadeInUp" data-admin-content-header></h1>
                <div class="slide-body" data-animation="animated fadeInUp" data-admin-content-body></div>
              </div>
            </div>
          </div>

          <div class="carousel-item" data-admin-content="Content_50">
            <div class="header-image" data-admin-content-background></div>
            <div class="carousel-overlay"></div>
            <div class="carousel-caption d-md-block">
              <div class="carousel-caption-inner">
                <h1 class="slide-header" data-animation="animated fadeInUp" data-admin-content-header></h1>
                <div class="slide-body" data-animation="animated fadeInUp" data-admin-content-body></div>
              </div>
            </div>
          </div>

          <div class="carousel-item" data-admin-content="Content_51">
            <div class="header-image" data-admin-content-background></div>
            <div class="carousel-overlay"></div>
            <div class="carousel-caption d-md-block">
              <div id="integration" class="carousel-caption-inner">
                <h1 class="slide-header" data-animation="animated fadeInUp" data-admin-content-header></h1>
                <div class="slide-body" data-animation="animated fadeInUp" data-admin-content-body></div>
                <div class="carousel-logos">
                  <img class="animated fadeInUp" src="@Url.Content("~/Content/Images/Logos/Brands/Integrations/Sage/sage-1-t-sm.png")" />
                  <img class="animated fadeInUp" src="@Url.Content("~/Content/Images/Logos/Brands/Integrations/JOOR/joor-1-t-sm.png")" />
                  <img class="animated fadeInUp" src="@Url.Content("~/Content/Images/Logos/Brands/Integrations/Xero/xero-2-t-sm.png")" />
                  <img class="animated fadeInUp" src="@Url.Content("~/Content/Images/Logos/Brands/Integrations/VeriFone/verifone-1-t-sm.png")" />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </header>

  <div class="content-wrapper bordered">
    <div class="container-fluid separator" data-admin-section="Section_21">
      <div class="container">
        <div class="row align-items-center justify-content-center">
          <div class="col col-md-8 ml-auto mr-auto">
            <div class="page-title" data-admin-content="Content_31">
              <h1 data-admin-content-header></h1>
              <p data-admin-content-body></p>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_23">
      <div class="row">
        <div class="col col-md-6 align-self-center" data-admin-content="Content_34">
          <h1 data-admin-content-header></h1>
          <div data-admin-content-body></div>
        </div>
        <div class="col col-md-6 mobile-disable align-self-center" data-admin-content="Content_55">
          <img class="body-image right" data-admin-content-image />
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_22">
      <div class="row">
        <div class="col col-md-4" data-admin-content="Content_33">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
        <div class="col col-md-4" data-admin-content="Content_41">
          <h2 data-admin-content-header></h2>
          <div data-admin-content-body></div>
        </div>
        <div class="col col-md-4" data-admin-content="Content_42">
          <h2 data-admin-content-header></h2>
          <div data-admin-content-body></div>
        </div>
      </div>
    </div>

    <div class="container-fluid separator" data-admin-section="Section_24">
      <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom">
        <div class="row align-items-center justify-content-center">
          <div class="col col-md-auto mobile-disable ml-auto align-self-center col-img-top" data-admin-content="Content_56">
            <img class="body-image transparent" style="max-width: 192px;" data-admin-content-image />
          </div>
          <div class="col col-md-6 mr-auto align-self-center" data-admin-content="Content_35">
            <h3 style="text-align: left;" data-admin-content-header></h3>
            <p data-admin-content-body></p>
          </div>
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_25">
      <div class="row align-items-center justify-content-center">
        <div class="col col-md-6 ml-auto align-self-center" data-admin-content="Content_36">
          <h1 data-admin-content-header></h1>
          <div data-admin-content-body></div>
        </div>
        <div class="col col-md-6 mobile-disable mr-auto align-self-center col-img-bottom" data-admin-content="Content_57">
          <img class="body-image right" data-admin-content-image />
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_26">
      <div class="row align-items-center justify-content-center">
        <div class="col col-md-6 mobile-disable align-self-center" data-admin-content="Content_58">
          <img class="body-image left" data-admin-content-image />
        </div>
        <div class="col col-md-6 align-self-center" data-admin-content="Content_37">
          <h1 data-admin-content-header></h1>
          <p data-admin-content-body></p>
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_27">
      <div class="row">
        <div class="col col-md-4" data-admin-content="Content_38">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
        <div class="col col-md-4" data-admin-content="Content_39">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
        <div class="col col-md-4" data-admin-content="Content_40">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
      </div>
    </div>

    <div class="container-fluid separator" data-admin-section="Section_28">
      <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom">
        <div class="row">
          <div class="col">
            <div class="client-wrapper">
              <div class="client-wrapper-inner">
                <div class="client-card" data-admin-content="Content_59">
                  <img class="client-image" data-admin-content-image />
                </div>
                <div class="client-card" data-admin-content="Content_60">
                  <img class="client-image" data-admin-content-image />
                </div>
                <div class="client-card" data-admin-content="Content_61">
                  <img class="client-image" data-admin-content-image />
                </div>
                <div class="client-card" data-admin-content="Content_62">
                  <img class="client-image" data-admin-content-image />
                </div>
                <div class="client-card" data-admin-content="Content_63">
                  <img class="client-image" data-admin-content-image />
                </div>
                <div class="client-card" data-admin-content="Content_64">
                  <img class="client-image" data-admin-content-image />
                </div>
                <div class="client-card-shim"></div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_31">
      <div class="row align-items-center justify-content-center">
        <div class="col col-md-5 mobile-disable align-self-center" data-admin-content="Content_65">
          <img class="body-image transparent" data-admin-content-image />
        </div>
        <div class="col col-md-7 align-self-center" data-admin-content="Content_45">
          <h1 data-admin-content-header></h1>
          <p data-admin-content-body></p>

          <div data-admin-content="Content_86">
            <a class="button body-button" data-admin-content-link></a>
          </div>
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom" data-admin-section="Section_30">
      <div class="row align-items-center justify-content-center">
        <div class="col col-md-4 align-self-center" data-admin-content="Content_43">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
        <div class="col col-md-4 align-self-center" data-admin-content="Content_44">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
        <div class="col col-md-4 align-self-center" data-admin-content="Content_138">
          <h2 data-admin-content-header></h2>
          <p data-admin-content-body></p>
        </div>
      </div>
    </div>

    <div class="container-fluid separator" data-admin-section="Section_32">
      <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom">
        <div class="row align-items-center justify-content-center">
          <div class="col col-md-4 mobile-disable align-self-center" data-admin-content="Content_66">
            <img class="body-image logo" data-admin-content-image />
          </div>
          <div class="col col-md-8 align-self-center quote-wrapper">
            <div class="quote-content" data-admin-content="Content_46">
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
