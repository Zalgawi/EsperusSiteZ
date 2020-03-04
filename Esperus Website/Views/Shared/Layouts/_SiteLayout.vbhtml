<!DOCTYPE html>

<html lang="en">

<head>
    <meta charset="utf-8">

    <meta http-equiv="x-ua-compatible" content="IE=edge">

    <meta name="viewport" content="height=device-height, width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="Providing a battle-hardened software platform built for fashion, footwear, sportswear and outdoorwear.">
    <meta name="keywords" content="esperus, esperus systems, genesis enterprise, stock management, stock distribution, multi-channel, multi channel, sales reporting, sales reports, mpos, epos, mobile point of sale, point of sale, point-of-sale, b2b, b2c">
    <meta name="author" content="Esperus Systems Limited">
    <meta name="theme-color" content="#2699FB">
    <meta name="robots" content="index, follow">

    <meta name="google-site-verification" content="drqbZ0RCAaje6m0JiZPUy6j4qRJmKsKMSUM6ECxQ3pY" />

    <meta name="apple-mobile-web-app-title" content="Esperus Systems">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="#2699FB">

    <link rel="canonical" href="https://esperus.com/" />

    <link rel="alternate" href="https://esperus.com/" hreflang="en-gb" />
    <link rel="alternate" href="https://esperus.com/" hreflang="x-default" />

    <link rel="manifest" href="@Url.Content("~/manifest.json")">
    <link rel="shortcut icon" type="image/png" href="@Url.Content("~/favicon.ico")">

    <link rel="apple-touch-icon" type="image/png" href="@Url.Content("~/touch-icon-iphone.png")">
    <link rel="apple-touch-icon" type="image/png" sizes="152x152" href="@Url.Content("~/touch-icon-ipad.png")">
    <link rel="apple-touch-icon" type="image/png" sizes="167x167" href="@Url.Content("~/touch-icon-ipad-retina.png")">
    <link rel="apple-touch-icon" type="image/png" sizes="180x180" href="@Url.Content("~/touch-icon-iphone-retina.png")">

    <title>Esperus Systems - @ViewBag.Title</title>

    <script type="application/ld+json">
        {
            "@@context" : "http://schema.org",
            "@@type" : "Organization",
            "@@id" : "https://organization.esperus.com",
            "name" : "Esperus",
            "legalName" : "Esperus Systems Limited",
            "logo" : "https://esperus.com/Content/Images/Logos/esperus-logo-transparent-2.png",
            "description" : "Business software solutions for fashion, footwear, sportswear and outdoor wear.",
            "foundingDate": "1986",
            "url" : "https://esperus.com",
            "telephone" : "+44(0)208 9209888",
            "address" : {
            "@@type" : "PostalAddress",
                "addressLocality" : "London",
                "addressCountry" : "GB",
                "postalCode" : "N14 6HF",
                "streetAddress" : "Southgate Office Village, 288 Chase Road"
            },
            "contactPoint": [{
                "@@type": "ContactPoint",
                "contactType": "Reception",
                "telephone": "+44(0)208 9209888 (Option 1)",
                "email": "info@esperus.com"
            }, {
                "@@type": "ContactPoint",
                "contactType": "Customer Support",
                "telephone": "+44(0)208 9209888 (Option 2)",
                "email": "support@esperus.com"
            }],
            "sameAs": [
                "https://www.facebook.com/Esperus",
                "https://twitter.com/Esperus",
                "https://www.linkedin.com/company/esperus",
                "https://www.instagram.com/esperus_systems",
                "https://www.yell.com/biz/esperus-london-2863202"
            ]
        }
    </script>


    @Styles.RenderFormat("<link type=""text/css"" rel=""stylesheet"" href=""{0}"" defer>", "~/Content/bootstrap")
    @Styles.RenderFormat("<link type=""text/css"" rel=""stylesheet"" href=""{0}"" defer>", "~/Content/animate")
    @Styles.RenderFormat("<link type=""text/css"" rel=""stylesheet"" href=""{0}"" defer>", "~/Content/animate-on-scroll")
    @Styles.RenderFormat("<link type=""text/css"" rel=""stylesheet"" href=""{0}"" media=""screen and (min-width: 992px)"" defer>", "~/Content/main")
    @Styles.RenderFormat("<link type=""text/css"" rel=""stylesheet"" href=""{0}"" media=""screen and (max-width: 991px)"" defer>", "~/Content/main-mobile")
    @Styles.RenderFormat("<link type=""text/css"" rel=""stylesheet"" href=""{0}"" defer>", "~/Content/fonts")

    @Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/jquery")
</head>

<body>
    <!--[if lte IE 9]>
        <p class="browserupgrade">
            You are using an <b>outdated</b> browser. Please <a href="https://browsehappy.com/" target="_blank">upgrade your browser</a> to improve your experience and security.
        </p>
    <![endif]-->

    <div class="container-body" id="main">
        @RenderBody()
    </div>

    @Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/modernizr")
    @Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/popper")
    @Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/bootstrap")
    @Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/animate-on-scroll")
    @Scripts.RenderFormat("<script type=""text/javascript"" src=""{0}""></script>", "~/bundles/main")

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
            data-moreinfo="@Url.Action("Privacy", "Site")"
            data-text-align="left"
            data-close-text="Ok"
            async>
    </script>
</body>

</html>
