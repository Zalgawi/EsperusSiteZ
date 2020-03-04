@ModelType Esperus.Models.PageViewModel
@Code
  ViewData("Title") = "About"
  Layout = "~/Views/Shared/Layouts/_SiteLayout.vbhtml"
End Code

<!-- Encode the model so that it can be accessed in JavaScript: -->
<script type="text/javascript">
  var model = @Html.Raw(Json.Encode(Model));
</script>

<div data-admin-page="Page_7">
  @Code Html.RenderPartial("~/Views/Shared/Partials/Sidebar.vbhtml", Model.pageHeadings) End Code

  <header>
    @Code Html.RenderPartial("~/Views/Shared/Partials/Header.vbhtml", Model.pageHeadings) End Code

    <div id="upper-content">
      <div class="header-image" style="background-image: url('@TempData("Background")');"></div>
      <div class="legand-overlay"></div>
      <div class="legand-content container" data-admin-section="Section_40">
        <div class="legand-content-inner" data-admin-content="Content_95">
          <h1 class="legand-header" data-admin-content-header></h1>
          <p class="legand-body" data-admin-content-body></p>
        </div>
      </div>
    </div>
  </header>

  <div class="content-wrapper bordered">
    <div class="container borderless" data-admin-section="Section_48">
      <div class="row">
        <div class="col col-md-6" data-admin-content="Content_103">
          <div data-admin-content-body></div>
        </div>
        <div class="col col-md-6" data-admin-content="Content_104">
          <div data-admin-content-body></div>
        </div>
      </div>
    </div>

    <div class="container borderless" data-aos="fade-up" data-aos-anchor-placement="center-bottom">
      <div class="row">
        <div class="col">
          <h1 class="heading">Our Story</h1>
        </div>
      </div>
    </div>

    <div class="container timeline-wrapper" data-admin-section="Section_49">
      <div class="timeline-orb top" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom">Past</div>
      <ul class="timeline">
        <li>
          <div class="timeline-badge" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom"><p>1986</p></div>
          <div class="timeline-panel" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom" data-admin-content="Content_105">
            <div class="timeline-heading">
              <h4 class="timeline-title" data-admin-content-header></h4>
            </div>
            <div class="timeline-body">
              <p data-admin-content-body></p>
            </div>
          </div>
        </li>
        <li class="timeline-inverted">
          <div class="timeline-badge" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom"><p>1998</p></div>
          <div class="timeline-panel" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom" data-admin-content="Content_106">
            <div class="timeline-heading">
              <h4 class="timeline-title" data-admin-content-header></h4>
            </div>
            <div class="timeline-body">
              <p data-admin-content-body></p>
            </div>
          </div>
        </li>
        <li>
          <div class="timeline-badge" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom"><p>2000</p></div>
          <div class="timeline-panel" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom" data-admin-content="Content_107">
            <div class="timeline-heading">
              <h4 class="timeline-title" data-admin-content-header></h4>
            </div>
            <div class="timeline-body">
              <p data-admin-content-body></p>
            </div>
          </div>
        </li>
        <li class="timeline-inverted">
          <div class="timeline-badge" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom"><p>2002</p></div>
          <div class="timeline-panel" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom" data-admin-content="Content_108">
            <div class="timeline-heading">
              <h4 class="timeline-title" data-admin-content-header></h4>
            </div>
            <div class="timeline-body">
              <p data-admin-content-body></p>
            </div>
          </div>
        </li>
        <li>
          <div class="timeline-badge" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom"><p>2003</p></div>
          <div class="timeline-panel" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom" data-admin-content="Content_109">
            <div class="timeline-heading">
              <h4 class="timeline-title" data-admin-content-header></h4>
            </div>
            <div class="timeline-body">
              <p data-admin-content-body></p>
            </div>
          </div>
        </li>
        <li class="timeline-inverted">
          <div class="timeline-badge" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom"><p>2004</p></div>
          <div class="timeline-panel" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom" data-admin-content="Content_110">
            <div class="timeline-heading">
              <h4 class="timeline-title" data-admin-content-header></h4>
            </div>
            <div class="timeline-body">
              <p data-admin-content-body></p>
            </div>
          </div>
        </li>
        <li>
          <div class="timeline-badge" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom"><p>2005</p></div>
          <div class="timeline-panel" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom" data-admin-content="Content_111">
            <div class="timeline-heading">
              <h4 class="timeline-title" data-admin-content-header></h4>
            </div>
            <div class="timeline-body">
              <p data-admin-content-body></p>
            </div>
          </div>
        </li>
        <li class="timeline-inverted">
          <div class="timeline-badge" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom"><p>2007</p></div>
          <div class="timeline-panel" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom" data-admin-content="Content_112">
            <div class="timeline-heading">
              <h4 class="timeline-title" data-admin-content-header></h4>
            </div>
            <div class="timeline-body">
              <p data-admin-content-body></p>
            </div>
          </div>
        </li>
        <li>
          <div class="timeline-badge" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom"><p>2010</p></div>
          <div class="timeline-panel" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom" data-admin-content="Content_113">
            <div class="timeline-heading">
              <h4 class="timeline-title" data-admin-content-header></h4>
            </div>
            <div class="timeline-body">
              <p data-admin-content-body></p>
            </div>
          </div>
        </li>
        <li class="timeline-inverted">
          <div class="timeline-badge" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom"><p>2014</p></div>
          <div class="timeline-panel" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom" data-admin-content="Content_114">
            <div class="timeline-heading">
              <h4 class="timeline-title" data-admin-content-header></h4>
            </div>
            <div class="timeline-body">
              <p data-admin-content-body></p>
            </div>
          </div>
        </li>
        <li>
          <div class="timeline-badge" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom"><p>2015</p></div>
          <div class="timeline-panel" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom" data-admin-content="Content_115">
            <div class="timeline-heading">
              <h4 class="timeline-title" data-admin-content-header></h4>
            </div>
            <div class="timeline-body">
              <p data-admin-content-body></p>
            </div>
          </div>
        </li>
        <li class="timeline-inverted">
          <div class="timeline-badge" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom"><p>2016</p></div>
          <div class="timeline-panel" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom" data-admin-content="Content_116">
            <div class="timeline-heading">
              <h4 class="timeline-title" data-admin-content-header></h4>
            </div>
            <div class="timeline-body">
              <p data-admin-content-body></p>
            </div>
          </div>
        </li>
        <li class="timeline-inverted timeline-none">
          <div class="timeline-panel" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom" data-admin-content="Content_117">
            <div class="timeline-heading">
              <h4 class="timeline-title" data-admin-content-header></h4>
            </div>
            <div class="timeline-body">
              <p data-admin-content-body></p>
            </div>
          </div>
        </li>
        <li class="timeline-inverted timeline-none">
          <div class="timeline-panel" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom" data-admin-content="Content_118">
            <div class="timeline-heading">
              <h4 class="timeline-title" data-admin-content-header></h4>
            </div>
            <div class="timeline-body">
              <p data-admin-content-body></p>
            </div>
          </div>
        </li>
        <li>
          <div class="timeline-badge" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom"><p>2017</p></div>
          <div class="timeline-panel" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom" data-admin-content="Content_119">
            <div class="timeline-heading">
              <h4 class="timeline-title" data-admin-content-header></h4>
            </div>
            <div class="timeline-body">
              <p data-admin-content-body></p>
            </div>
          </div>
        </li>
        <li class="timeline-inverted">
          <div class="timeline-badge" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom"><p>2019</p></div>
          <div class="timeline-panel" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom" data-admin-content="Content_120">
            <div class="timeline-heading">
              <h4 class="timeline-title" data-admin-content-header></h4>
            </div>
            <div class="timeline-body">
              <p data-admin-content-body></p>
            </div>
          </div>
        </li>
      </ul>
      <div class="timeline-orb bottom" data-aos="fade-up" data-aos-anchor-placement="bottom-bottom">Future</div>
    </div>
  </div>
</div>

@Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/admin-injector")

@Code Html.RenderPartial("~/Views/Shared/Partials/Footer.vbhtml", Model.pageHeadings) End Code
