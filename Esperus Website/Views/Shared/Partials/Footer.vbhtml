@ModelType List(Of Esperus.Areas.Admin.Models.PageModel)

<footer class="footer">
  <div class="container">
    <div class="row">
      <div class="col-md-auto align-self-center">
        <div class="footer-content">
          <a class="footer-brand" href="@Url.Action("Index", "Site")">
            <img alt="Esperus Logo" src="@Url.Content("~/Content/Images/Logos/esperus-logo-transparent-1.png")">
          </a>
          <div class="footer-sub">
            <p>
              &copy; Copyright @DateTime.Now.Year Esperus Systems Limited
            </p>
            <p>
              Web design and development by Esperus Systems Limited
            </p>
          </div>
        </div>
      </div>
      <div class="col align-self-center mobile-disable page-links-wrapper">
        <div class="page-links">
          <div class="links">
            @If Model IsNot Nothing Then
              @For Each page As Esperus.Areas.Admin.Models.PageModel In Model
                @If Not page.Name = "Index" Then
                  @<a href="@Url.Action(page.PageLink, "Site")" id="nav-@page.DisplayID">
                    @page.Name
                  </a>
                End If
              Next
            End If
          </div>
        </div>
      </div>
      <div class="col-md-2 align-self-center">
        <a class="button inverted" id="scroll-top" href="javascript:void(0)" style="margin: 8px 0 0 0;"><i class="fas fa-arrow-up"></i> Top</a>
      </div>
    </div>
  </div>
</footer>
