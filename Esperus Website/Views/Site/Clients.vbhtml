@ModelType Esperus.Models.PageViewModel
@Code
  ViewData("Title") = "Clients"
  Layout = "~/Views/Shared/Layouts/_SiteLayout.vbhtml"
End Code

<!-- Encode the model so that it can be accessed in JavaScript: -->
<script type="text/javascript">
	var model = @Html.Raw(Json.Encode(Model));
</script>

<div data-admin-page="Page_5">
  @Code Html.RenderPartial("~/Views/Shared/Partials/Sidebar.vbhtml", Model.pageHeadings) End Code

  <header>
    @Code Html.RenderPartial("~/Views/Shared/Partials/Header.vbhtml", Model.pageHeadings) End Code

    <div id="upper-content">
      <div class="header-image" style="background-image: url('@TempData("Background")');"></div>
      <div class="legand-overlay"></div>
      <div class="legand-content container" data-admin-section="Section_37">
        <div class="legand-content-inner" data-admin-content="Content_92">
          <h1 class="legand-header" data-admin-content-header></h1>
          <p class="legand-body" data-admin-content-body></p>
        </div>
      </div>
    </div>
  </header>

  <div class="content-wrapper bordered">
    <div class="container-fluid separator" data-admin-section="Section_38">
      <div class="container">
        <div class="row align-items-center justify-content-center">
          <div class="col col-md-8 align-self-center ml-auto mr-auto">
            <div class="page-title" data-admin-content="Content_93">
              <h1 data-admin-content-header></h1>
              <p data-admin-content-body></p>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom">
      <div class="row">
        <div class="col">
          <h1 class="heading">Long-Standing Clients</h1>
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom">
      <div class="row">
        <div class="col">
          <div class="client-wrapper">
            <div class="client-wrapper-inner full-spread">
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/Carducci/carducci-logo-1-1.jpg")" alt="Carduuci" />
              </div>
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/Cordings/cordings-2-t.png")" alt="Cordings" />
              </div>
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/Davina/davina-logo-1-1.jpg")" alt="Davina" />
              </div>
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/James Lock/james-lock-2-w.png")" alt="James Lock" />
              </div>
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/Pan World Brands/pwb-logo-1-1.jpg")" alt="Pan World Brands" />
              </div>
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/Pretty Eccentric/pretty-eccentric-logo-1-1.jpg")" alt="Pretty Eccentric" />
              </div>
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/Queens Park Rangers/queens-park-rangers-2-w.png")" alt="Queens Park Rangers" />
              </div>
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/Timberland/timberland-2-w.png")" alt="Timberland" />
              </div>
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/Surfanic/surfanic-1-1.jpg")" alt="Surfanic" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom">
      <div class="row">
        <div class="col">
          <h1 class="heading">New & Recent Clients</h1>
        </div>
      </div>
    </div>

    <div class="container" data-aos="fade-up" data-aos-anchor-placement="top-bottom">
      <div class="row">
        <div class="col">
          <div class="client-wrapper">
            <div class="client-wrapper-inner full-spread">
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/Early Days/early-days-1-1.jpg")" alt="Early Days" />
              </div>
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/Emma Willis/emma-willis-1-1.jpg")" alt="Emma Willis" />
              </div>
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/Goodwood/goodwood-2-t.png")" alt="Goodwood" />
              </div>
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/Javelin/javelin-logo-1-1.jpg")" alt="Javelin" />
              </div>
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/Jeffrey West/jeffery-west-logo-1-1.jpg")" alt="Jeffery West" />
              </div>
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/Little Mistress/little-mistress-2-w.png")" alt="Little Mistress" />
              </div>
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/Melin Tregwynt/melin-logo-1-1.jpg")" alt="Melin Tregwynt" />
              </div>
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/Mini-La-Mode/mini-la-mode-logo-1-1.jpg")" alt="Mini-La-Mode" />
              </div>
              <div class="client-card">
                <img class="client-image" src="@Url.Content("~/Content/Images/Logos/Brands/Clients/Wyse/wyse-london-logo-1-1.jpg")" alt="Wyse London" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>

@Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/admin-injector")

@Code Html.RenderPartial("~/Views/Shared/Partials/Footer.vbhtml", Model.pageHeadings) End Code
