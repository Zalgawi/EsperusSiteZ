<!DOCTYPE html>

<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="IE=edge">
    <meta name="viewport" content="height=device-height, width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="Providing a battle-hardened software platform built for fashion, footwear, sportswear and outdoorwear.">
    <meta name="keywords" content="esperus, esperus systems, genesis enterprise, stock management, stock distribution, multi-channel, multi channel, sales reporting, sales reports, mpos, epos, mobile point of sale, point of sale, point-of-sale, b2b, b2c">
    <meta name="author" content="Esperus Systems Ltd">
    <meta name="theme-color" content="#2699FB">
    <meta name="robots" content="index, follow">

    <meta name="apple-mobile-web-app-title" content="Esperus Systems">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="#2699FB">

    <link rel="manifest" href="@Url.Content("~/manifest.json")">
    <link rel="shortcut icon" type="image/png" href="@Url.Content("~/favicon.ico")">

    <link rel="apple-touch-icon" type="image/png" href="@Url.Content("~/touch-icon-iphone.png")">
    <link rel="apple-touch-icon" type="image/png" sizes="152x152" href="@Url.Content("~/touch-icon-ipad.png")">
    <link rel="apple-touch-icon" type="image/png" sizes="167x167" href="@Url.Content("~/touch-icon-ipad-retina.png")">
    <link rel="apple-touch-icon" type="image/png" sizes="180x180" href="@Url.Content("~/touch-icon-iphone-retina.png")">

    <title>Esperus Systems - @ViewBag.Title</title>

    @Styles.RenderFormat("<link type=""text/css"" rel=""stylesheet"" href=""{0}"" defer>", "~/Content/bootstrap")
    @Styles.RenderFormat("<link type=""text/css"" rel=""stylesheet"" href=""{0}"" defer>", "~/Content/animate")
    @Styles.RenderFormat("<link type=""text/css"" rel=""stylesheet"" href=""{0}"" defer>", "~/Content/animate-on-scroll")
    @Styles.RenderFormat("<link type=""text/css"" rel=""stylesheet"" href=""{0}"" media=""screen and (min-width: 992px)"" defer>", "~/Content/desktop")
    @Styles.RenderFormat("<link type=""text/css"" rel=""stylesheet"" href=""{0}"" media=""screen and (max-width: 991px)"" defer>", "~/Content/mobile")

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css" integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous">
</head>
<body>
    <!--[if lte IE 9]>
        <p class="browserupgrade">
            You are using an <b>outdated</b> browser. Please <a href="https://browsehappy.com/" target="_blank">upgrade your browser</a> to improve your experience and security.
        </p>
    <![endif]-->

    @Html.Partial("~/Views/Shared/Partials/Sidebar.vbhtml")

    <div class="container-body" id="main">
        @RenderBody()
        @Html.Partial("~/Views/Shared/Partials/Footer.vbhtml")
    </div>

    @Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/modernizr")
    @Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/jquery")
    @Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/popper")
    @Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/bootstrap")
    @Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/animate-on-scroll")
    @Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/js")

    @RenderSection("scripts", required:=False)

    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script rel="preconnect" type="text/javascript" src="https://www.googletagmanager.com/gtag/js?id=UA-129881280-2" async></script>
    <script rel="preconnect" type="text/javascript" async>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());
        gtag('config', 'UA-129881280-2');
    </script>

    <!-- Cookie Info Script -->
    <script rel="preconnect" type="text/javascript" id="cookieinfo"
            src="https://cookieinfoscript.com/js/cookieinfo.min.js"
            data-bg="black"
            data-fg="white"
            data-link="#2699FB"
            data-divlinkbg="#2699FB"
            data-cookie="CookieInfoScript"
            data-moreinfo="/Home/Privacy"
            data-text-align="left"
            data-close-text="Ok"
            async>
    </script>
</body>

</html>
