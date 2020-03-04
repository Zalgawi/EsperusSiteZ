<nav class="navbar navbar-dark navbar-expand-lg">
  <div class="navbar-header">
    <button class="navbar-toggler hierarchy-open" type="button" href="javascript:void(0);">
      <i class="fas fa-list-ul"></i>
      <i class="fas fa-times" style="display: none;"></i>
    </button>
    <p class="navbar-brand">
      Esperus
    </p>
    <button class="navbar-toggler sidebar-open" type="button" href="javascript:void(0);">
      <i class="fas fa-bars"></i>
    </button>
  </div>
  <div class="collapse navbar-collapse" id="nav-main">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item">
        <a href="@Url.Action("Index", "Admin")" class="nav-link" id="nav-home">
          <i class="fas fa-home"></i> Home
        </a>
      </li>
      <li class="nav-item">
        <a href="@Url.Action("Pages", "Admin")" class="nav-link" id="nav-editor">
          <i class="fas fa-file-alt"></i> Pages
        </a>
      </li>

      <li class="nav-item dropdown">
        <a id="nav-assets" class="nav-link dropdown-toggle" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
          <i class="fas fa-puzzle-piece"></i> Assets
        </a>
        <div class="dropdown-menu" aria-labelledby="nav-assets">
          <a class="dropdown-item" href="@Url.Action("Images", "Admin")">Images</a>
        </div>
      </li>
    </ul>
    <ul class="navbar-nav ml-auto">
      <li class="nav-item dropdown">
        <a href="javascript:void(0);" class="nav-link dropdown-toggle" id="nav-logout" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
          <i class="fas fa-user"></i>
          @If Session("ActiveUser") IsNot Nothing Then
            @Session("ActiveUser").Username
          End If

        </a>
        <div class="dropdown-menu dropdown-menu-right" aria-labelledby="nav-logout">
          <a class="dropdown-item" href="@Url.Action("Account", "Admin")">Settings</a>
          <a class="dropdown-item" href="/">Logout</a>
        </div>
      </li>
    </ul>
  </div>
</nav>
