<!DOCTYPE html>

<html lang="en">

<head>
  <meta charset="utf-8">
  <meta http-equiv="x-ua-compatible" content="IE=edge">
  <meta name="viewport" content="height=device-height, width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="keywords" content="">
  <meta name="author" content="">
  <meta name="theme-color" content="#2699FB">
  <meta name="robots" content="noindex, nofollow">

  <link rel="manifest" href="@Url.Content("~/manifest.json")">
  <link rel="shortcut icon" type="image/png" href="@Url.Content("~/favicon.ico")">

  <title>Esperus Systems - @ViewBag.Title</title>

  @Styles.RenderFormat("<link type=""text/css"" rel=""stylesheet"" href=""{0}"" defer/>", "~/Content/bootstrap")
  @Styles.RenderFormat("<link type=""text/css"" rel=""stylesheet"" href=""{0}"" defer/>", "~/Content/bootstrap-treeview")
  @Styles.RenderFormat("<link type=""text/css"" rel=""stylesheet"" href=""{0}"" defer/>", "~/Content/trumbowyg")
  @Styles.RenderFormat("<link type=""text/css"" rel=""stylesheet"" href=""{0}"" media=""screen and (min-width: 993px)"" defer>", "~/Content/admin")
  @Styles.RenderFormat("<link type=""text/css"" rel=""stylesheet"" href=""{0}"" media=""screen and (max-width: 992px)"" defer>", "~/Content/admin-mobile")
  @Styles.RenderFormat("<link type=""text/css"" rel=""stylesheet"" href=""{0}"">", "~/Content/fonts")

  @Scripts.RenderFormat("<script type="" text/javascript"" src=""{0}"" ></script>", "~/bundles/jquery")
  @Scripts.RenderFormat("<script type="" text/javascript"" src=""{0}"" ></script>", "~/bundles/modernizr")
  @Scripts.RenderFormat("<script type="" text/javascript"" src=""{0}"" ></script>", "~/bundles/popper")
  @Scripts.RenderFormat("<script type="" text/javascript"" src=""{0}"" ></script>", "~/bundles/bootstrap")
</head>

<body>
  <!--[if lte IE 9]>
      <p class="browserupgrade">You are using an <b>outdated</b> browser. Please <a href="https://browsehappy.com/" target="_blank">upgrade your browser</a> to improve your experience and security.</p>
  <![endif]-->

  @RenderBody()

  @Scripts.RenderFormat("<script type="" text/javascript"" src=""{0}"" ></script>", "~/bundles/bootstrap-treeview")
  @Scripts.RenderFormat("<script type="" text/javascript"" src=""{0}"" defer></script>", "~/bundles/trumbowyg")
  @Scripts.RenderFormat("<script type="" text/javascript"" src=""{0}"" defer></script>", "~/bundles/admin")
</body>

</html>
