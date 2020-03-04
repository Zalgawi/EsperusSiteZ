@ModelType Esperus.Models.PageViewModel
@Code
  ViewData("Title") = "Copyright"
  Layout = "~/Views/Shared/Layouts/_SiteLayout.vbhtml"
End Code

<!-- Encode the model so that it can be accessed in JavaScript: -->
<script type="text/javascript">
	var model = @Html.Raw(Json.Encode(Model));
</script>

<div data-admin-page="Page_12">
  @Code Html.RenderPartial("~/Views/Shared/Partials/Sidebar.vbhtml", Model.pageHeadings) End Code

  <header>
    @Code Html.RenderPartial("~/Views/Shared/Partials/Header.vbhtml", Model.pageHeadings) End Code
  </header>

  <div class="content-wrapper">
    <div class="container" data-admin-section="Section_46">
      <div class="row">
        <div class="col-md-9 ml-auto mr-auto" data-admin-content="Content_101">
          <h1 data-admin-content-header></h1>
          <div data-admin-content-body></div>
        </div>
      </div>
    </div>
  </div>
</div>

@Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/admin-injector")

@Code Html.RenderPartial("~/Views/Shared/Partials/Footer.vbhtml", Model.pageHeadings) End Code
