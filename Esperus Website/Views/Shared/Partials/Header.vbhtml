@ModelType List(Of Esperus.Areas.Admin.Models.PageModel)

<nav class="navbar navbar-expand-lg navbar-light fixed-top">
  <div class="container">
    <div class="navbar-shim"></div>

    <div class="navbar-title">
      <a class="navbar-brand" href="@Url.Action("Index", "Site")">
        <img class="navbar-logo" alt="Esperus" src="@Url.Content("~/Content/Images/Logos/esperus-logo-transparent-2.png")" />
        <p class="navbar-tag">est. 1986</p>
      </a>
    </div>

    <div class="collapse navbar-collapse" id="navigation">
      <ul class="navbar-nav">
        @If Model IsNot Nothing Then
          @For Each page As Esperus.Areas.Admin.Models.PageModel In Model
            If page.DisplayNavbar = True Then
              @<li class="nav-item underline" id="nav-@page.DisplayID">
                <a class="nav-link" href="@Url.Action(page.PageLink, "Site")">
                  @page.Name
                </a>
              </li>
            End If
          Next
        End If
      </ul>
    </div>

    <div class="navbar-mobile">
      <button class="navbar-toggler sidebar-open" type="button" href="javascript:void(0);">
        <i class="fas fa-bars"></i>
      </button>
    </div>
  </div>
</nav>

<div class="header-fixed"></div>
