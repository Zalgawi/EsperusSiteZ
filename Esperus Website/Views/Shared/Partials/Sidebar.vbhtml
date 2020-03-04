@ModelType List(Of Esperus.Areas.Admin.Models.PageModel)

<div class="nav-sidenav">
  <div class="sidenav-header">
    <a class="sidebar-close" href="javascript:void(0);">
      <i class="fas fa-times"></i>
    </a>
  </div>

  <div class="sidenav-nav">
    @If Model IsNot Nothing Then
      @For Each page As Esperus.Areas.Admin.Models.PageModel In Model
        If page.DisplayNavbar = True Then
          @<a class="nav-item" href="@Url.Action(page.PageLink, "Site")" id="sidebar-@page.DisplayID">
            @page.Name
          </a>
        End If
      Next
    End If

    @*<div class="sidenav-separator"></div>

    <a class="nav-item" href="@Url.Action("Index", "Admin", New With {.Area = "Admin"})" id="sidebar-admin">
      <i class="fas fa-user"></i> Login
    </a>*@
  </div>
</div>
