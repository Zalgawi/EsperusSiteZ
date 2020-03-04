@ModelType Esperus.Models.PageViewModel
@Code
  ViewData("Title") = "Privacy"
  Layout = "~/Views/Shared/Layouts/_SiteLayout.vbhtml"
End Code

<!-- Encode the model so that it can be accessed in JavaScript: -->
<script type="text/javascript">
	var model = @Html.Raw(Json.Encode(Model));
</script>

<div data-admin-page="Page_10">
  @Code Html.RenderPartial("~/Views/Shared/Partials/Sidebar.vbhtml", Model.pageHeadings) End Code

  <header>
    @Code Html.RenderPartial("~/Views/Shared/Partials/Header.vbhtml", Model.pageHeadings) End Code
  </header>

  <div class="content-wrapper">
    <div class="container" data-admin-section="Section_43">
      <div class="row">
        <div class="col-md-9 ml-auto mr-auto" data-admin-content="Content_98">
          <h1 data-admin-content-header></h1>
          <div data-admin-content-body></div>
        </div>
      </div>
    </div>
    <div class="container" data-admin-section="Section_44">
      <div class="row">
        <div class="col-md-9 ml-auto mr-auto" data-admin-content="Content_99">
          <h1 data-admin-content-header></h1>
          <div data-admin-content-body></div>
        </div>
      </div>
    </div>
  </div>
</div>

@Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/admin-injector")

@Code Html.RenderPartial("~/Views/Shared/Partials/Footer.vbhtml", Model.pageHeadings) End Code
