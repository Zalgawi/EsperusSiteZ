@ModelType Esperus.Areas.Admin.Models.HomeViewModel
@Code
  ViewData("Title") = "Home"
  Layout = "~/Areas/Admin/Views/Shared/Layouts/_NestedLayout.vbhtml"
End Code

<div class="container">
  <div class="row">
    <div class="col">
      <div class="welcome-hero">
        <h1>Welcome, @Session("ActiveUser").DisplayName</h1>
      </div>
    </div>
  </div>
</div>

<div class="container">
  <div class="row">
    <div class="col">
      <div class="input-group">
        <div class="input-group-prepend">
          <span class="input-group-text">Date Range</span>
        </div>
        <div class="dropdown">
          <button class="btn btn-outline-secondary dropdown-toggle dashboard-date-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"></button>
          <div class="dropdown-menu" aria-labelledby="dashboard-refresh">
            <a class="dropdown-item dashboard-date" href="javascript:void(0);" value="7daysAgo">7 Days</a>
            <a class="dropdown-item dashboard-date" href="javascript:void(0);" value="14daysAgo">14 Days</a>
            <a class="dropdown-item dashboard-date" href="javascript:void(0);" value="30daysAgo">30 Days</a>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div class="row">
    <div class="col">
      <div class="report-container">
        <div class="report-wrapper">
          <div class="report-header">
            <h5>Site Traffic</h5>
            <p>Number of users visiting the website; displayed as totals.</p>
          </div>
          <div class="report" id="embed-api-chart-1"></div>
          <div class="d-none" id="embed-api-viewselect-1"></div>
        </div>
        <div class="report-wrapper">
          <div class="report-header">
            <h5>Popular Pages</h5>
            <p><b>Top 15</b> pages in terms of viewership; displayed as totals.</p>
          </div>
          <div class="report" id="embed-api-chart-2"></div>
          <div class="d-none" id="embed-api-viewselect-2"></div>
        </div>
      </div>
      <div class="report-container">
        <div class="report-wrapper report-small">
          <div class="report-header">
            <h5>Visitor Types</h5>
            <p>Collection of visitor types; displayed as totals.</p>
          </div>
          <div class="report" id="embed-api-chart-3"></div>
          <div class="d-none" id="embed-api-viewselect-3"></div>
        </div>
        <div class="report-wrapper report-small">
          <div class="report-header">
            <h5>Visitor Devices</h5>
            <p>Collection of visitor device types; displayed as totals.</p>
          </div>
          <div class="report" id="embed-api-chart-4"></div>
          <div class="d-none" id="embed-api-viewselect-4"></div>
        </div>
        <div class="report-wrapper">
          <div class="report-header">
            <h5>Site Discovery</h5>
            <p>Summary of site discoverability; displayed as totals.</p>
          </div>
          <div class="report" id="embed-api-chart-5"></div>
          <div class="d-none" id="embed-api-viewselect-5"></div>
        </div>
      </div>
    </div>
  </div>
</div>

<script type="text/javascript">
    var model = @Html.Raw(Json.Encode(Model));
</script>

@Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/admin-reports")
