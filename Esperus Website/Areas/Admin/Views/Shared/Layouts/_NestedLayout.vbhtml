@Code
  Layout = "~/Areas/Admin/Views/Shared/Layouts/_AdminLayout.vbhtml"
End Code

@Code Html.RenderPartial("~/Areas/Admin/Views/Shared/Partials/Sidebar.vbhtml") End Code

<div class="body-wrapper">
  @Code Html.RenderPartial("~/Areas/Admin/Views/Shared/Partials/Header.vbhtml") End Code

  @RenderBody
</div>
