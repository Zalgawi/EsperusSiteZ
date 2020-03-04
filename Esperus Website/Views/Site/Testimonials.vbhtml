@ModelType Esperus.Models.PageViewModel
@Code
  ViewData("Title") = "Testimonials"
  Layout = "~/Views/Shared/Layouts/_SiteLayout.vbhtml"
End Code

<!-- Encode the model so that it can be accessed in JavaScript: -->
<script type="text/javascript">
	var model = @Html.Raw(Json.Encode(Model));
</script>

<div data-admin-page="Page_6">
  @Code Html.RenderPartial("~/Views/Shared/Partials/Sidebar.vbhtml", Model.pageHeadings) End Code

  <header>
    @Code Html.RenderPartial("~/Views/Shared/Partials/Header.vbhtml", Model.pageHeadings) End Code

    <div id="upper-content">
      <div class="header-image" style="background-image: url('@TempData("Background")');"></div>
      <div class="legand-overlay"></div>
      <div class="legand-content container" data-admin-section="Section_39">
        <div class="legand-content-inner" data-admin-content="Content_94">
          <h1 class="legand-header" data-admin-content-header></h1>
          <p class="legand-body" data-admin-content-body></p>
        </div>
      </div>
    </div>
  </header>

  <div class="content-wrapper">
    <div class="container">
      <div class="row">
        <div class="col col-md-12 ml-auto mr-auto">
          <div class="list-group list-group-horizontal" id="list-tab" role="tablist">
            <a class="list-group-item list-group-item-action active" id="list-cd" data-toggle="list" href="#tab-cd" role="tab" aria-controls="tab-cd">
              Cordings
            </a>
            <a class="list-group-item list-group-item-action" id="list-qpr" data-toggle="list" href="#tab-qpr" role="tab" aria-controls="tab-qpr">
              Queens Park Rangers
            </a>
            <a class="list-group-item list-group-item-action" id="list-jw" data-toggle="list" href="#tab-jw" role="tab" aria-controls="tab-jw">
              Jeffery West
            </a>
            <a class="list-group-item list-group-item-action" id="list-ew" data-toggle="list" href="#tab-ew" role="tab" aria-controls="tab-ew">
              Emma Willis
            </a>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col col-md-12 ml-auto mr-auto">
          <div class="tab-content">
            <div class="tab-pane fade show active" id="tab-cd" role="tabpanel" aria-labelledby="list-cd" data-admin-section="Section_50">
              <div class="page">
                <div class="page-header" style="background: url('@Url.Content("~/Content/Images/Backgrounds/Testimonials/cordings-testimonial-1.jpg")'); background-size: cover; background-position: center; background-repeat: no-repeat;">
                  <div class="header-overlay"></div>
                  <div class="header-content">
                    <div class="header-content-inner">
                      <h1>
                        Cordings
                      </h1>
                    </div>
                  </div>
                </div>
                <div class="page-divide first" data-admin-content="Content_121">
                  <p>
                    Download the full case study (PDF)
                  </p>
                  <a class="button" href="" target="_blank" data-admin-content-link>
                    <i class="fas fa-arrow-down"></i>
                  </a>
                </div>
                <div class="page-content">
                  <div class="quote-wrapper nested">
                    <div class="quote-content" data-admin-content="Content_122">
                      <p class="quote-body" data-admin-content-body></p>
                      <p class="quote-author" data-admin-content-header></p>
                    </div>
                  </div>

                  <div data-admin-content="Content_123">
                    <div data-admin-content-body></div>
                  </div>
                </div>
                <div class="page-divide" data-admin-content="Content_124">
                  <p>
                    Visit the Cordings website:
                  </p>
                  <a class="button" href="" rel="noreferrer" target="_blank" data-admin-content-link>
                    <img class="link-icon" src="~/Content/Images/Icons/link-icon-w-f-1.png" />
                  </a>
                </div>
              </div>
            </div>
            <div class="tab-pane fade" id="tab-qpr" role="tabpanel" aria-labelledby="list-qpr" data-admin-section="Section_51">
              <div class="page">
                <div class="page-header" style="background: url('@Url.Content("~/Content/Images/Backgrounds/Testimonials/qpr-page-header-1.jpg")'); background-size: cover; background-position: center; background-repeat: no-repeat;">
                  <div class="header-overlay"></div>
                  <div class="header-content">
                    <div class="header-content-inner">
                      <h1>
                        Queens Park Rangers Football Club
                      </h1>
                    </div>
                  </div>
                </div>
                <div class="page-divide first" data-admin-content="Content_125">
                  <p>
                    Download the full case study (PDF)
                  </p>
                  <a class="button" href="" target="_blank" data-admin-content-link>
                    <i class="fas fa-arrow-down"></i>
                  </a>
                </div>
                <div class="page-content">
                  <div class="quote-wrapper nested" data-admin-content="Content_126">
                    <div class="quote-content">
                      <p class="quote-body" data-admin-content-body></p>
                      <p class="quote-author" data-admin-content-header></p>
                    </div>
                  </div>

                  <div data-admin-content="Content_127">
                    <div data-admin-content-body></div>
                  </div>
                </div>
                <div class="page-divide" data-admin-content="Content_128">
                  <p>
                    Visit the Queens Park Rangers website:
                  </p>
                  <a class="button" href="" rel="noreferrer" target="_blank" data-admin-content-link>
                    <img class="link-icon" src="~/Content/Images/Icons/link-icon-w-f-1.png" />
                  </a>
                </div>
              </div>
            </div>
            <div class="tab-pane fade" id="tab-jw" role="tabpanel" aria-labelledby="list-jw" data-admin-section="Section_52">
              <div class="page">
                <div class="page-header" style="background: url('@Url.Content("~/Content/Images/Backgrounds/Testimonials/jeffery-west-page-header-1.jpg")'); background-size: cover; background-position: center; background-repeat: no-repeat;">
                  <div class="header-overlay"></div>
                  <div class="header-content">
                    <div class="header-content-inner">
                      <h1>
                        Jeffery West
                      </h1>
                    </div>
                  </div>
                </div>
                <div class="page-divide first" data-admin-content="Content_129">
                  <p>
                    Download the full case study (PDF)
                  </p>
                  <a class="button" href="" target="_blank" data-admin-content-link>
                    <i class="fas fa-arrow-down"></i>
                  </a>
                </div>
                <div class="page-content">
                  <div class="quote-wrapper nested" data-admin-content="Content_130">
                    <div class="quote-content">
                      <p class="quote-body" data-admin-content-body></p>
                      <p class="quote-author" data-admin-content-header></p>
                    </div>
                  </div>
                </div>
                <div class="page-divide" data-admin-content="Content_131">
                  <p>
                    Download a featured magazine article (PDF)
                  </p>
                  <a class="button" href="" target="_blank" data-admin-content-link>
                    <i class="fas fa-arrow-down"></i>
                  </a>
                </div>
                <div class="page-content">
                  <div data-admin-content="Content_132">
                    <div data-admin-content-body></div>
                  </div>
                </div>
                <div class="page-divide" data-admin-content="Content_133">
                  <p>
                    Visit the Jeffery West website:
                  </p>
                  <a class="button" href="" rel="noreferrer" target="_blank" data-admin-content-link>
                    <img class="link-icon" src="~/Content/Images/Icons/link-icon-w-f-1.png" />
                  </a>
                </div>
              </div>
            </div>
            <div class="tab-pane fade" id="tab-ew" role="tabpanel" aria-labelledby="list-ew" data-admin-section="Section_53">
              <div class="page">
                <div class="page-header" style="background: url('@Url.Content("~/Content/Images/Backgrounds/Testimonials/emma-willis-page-header-1.jpg")'); background-size: cover; background-position: center; background-repeat: no-repeat;">
                  <div class="header-overlay"></div>
                  <div class="header-content">
                    <div class="header-content-inner">
                      <h1>
                        Emma Willis
                      </h1>
                    </div>
                  </div>
                </div>
                <div class="page-divide first" data-admin-content="Content_134">
                  <p>
                    Download the full case study (PDF)
                  </p>
                  <a class="button" href="" target="_blank" data-admin-content-link>
                    <i class="fas fa-arrow-down"></i>
                  </a>
                </div>
                <div class="page-content">
                  <div class="quote-wrapper nested" data-admin-content="Content_135">
                    <div class="quote-content">
                      <p class="quote-body" data-admin-content-body></p>
                      <p class="quote-author" data-admin-content-header></p>
                    </div>
                  </div>

                  <div data-admin-content="Content_136">
                    <div data-admin-content-body></div>
                  </div>

                </div>
                <div class="page-divide" data-admin-content="Content_137">
                  <p>
                    Visit the Emma Willis website:
                  </p>
                  <a class="button" href="" rel="noreferrer" target="_blank" data-admin-content-link>
                    <img class="link-icon" src="~/Content/Images/Icons/link-icon-w-f-1.png" />
                  </a>
                </div>
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
