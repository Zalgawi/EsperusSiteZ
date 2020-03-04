<div class="nav-sidenav">
  <div class="sidenav-header">
    <a class="sidebar-close" href="javascript:void(0);">
      <i class="fas fa-times"></i>
    </a>
  </div>
  <ul class="sidenav-nav">
    <li class="sidenav-item">
      <a href="@Url.Action("Index", "Admin")" id="sidenav-home">
        <i class="fas fa-home sidenav-icon"></i> Home
      </a>
    </li>
    <li class="sidenav-item">
      <a href="@Url.Action("Editor", "Admin")" id="sidenav-editor">
        <i class="fas fa-file-alt sidenav-icon"></i> Pages
      </a>
    </li>
    <li class="sidenav-item">
      <a class="sidenav-toggle" id="assets-toggle" href="javascript:void(0);">
        <i class="fas fa-puzzle-piece sidenav-icon"></i> Assets
      </a>
      <div class="sidenav-menu" id="assets-menu">
        <a id="sidenav-images" href="@Url.Action("Images", "Admin")">
          Images
        </a>
      </div>
    </li>
    <li class="sidenav-item">
      <a class="sidenav-toggle" id="account-toggle" href="javascript:void(0);">
        <i class="fas fa-user sidenav-icon"></i>
        @If Session("ActiveUser") IsNot Nothing Then
          @Session("ActiveUser").Username
        End If
      </a>
      <div class="sidenav-menu" id="account-menu">
        <a id="sidenav-account" href="@Url.Action("Account", "Admin")">Settings</a>
        <a href="/">Logout</a>
      </div>
    </li>
  </ul>
</div>
