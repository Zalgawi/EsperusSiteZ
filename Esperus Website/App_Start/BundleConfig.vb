Imports System.Web.Optimization

Public Module BundleConfig
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)
        RegisterScripts(bundles)
        RegisterStyles(bundles)

        ' NOTE: For some reason EnableOptimizations wreaks havok with IE 11, causing the browser to crash to desktop.
        BundleTable.EnableOptimizations = False ' Defaults to the minified CSS and JS - switch to 'True' for production.
        bundles.UseCdn = False ' Defaults to the CDN resource if it is available.
    End Sub

    Private Sub RegisterStyles(ByVal bundles As BundleCollection)
        bundles.Add(New StyleBundle("~/Content/bootstrap").Include("~/Content/Styles/Libs/bootstrap.min.css"))
        bundles.Add(New StyleBundle("~/Content/animate-on-scroll").Include("~/Content/Styles/Libs/aos.min.css"))
        bundles.Add(New StyleBundle("~/Content/animate").Include("~/Content/Styles/Libs/animate.min.css"))

        bundles.Add(New StyleBundle("~/Content/fonts").Include(
                    "~/Content/Styles/Fonts/montserrat.min.css",
                    "~/Content/Styles/Fonts/nunito.min.css",
                    "~/Content/Styles/Fonts/fontawesome.min.css"))

        bundles.Add(New StyleBundle("~/Content/main").Include(
                    "~/Content/Styles/main.min.css",
                    "~/Content/Styles/page-testimonials.min.css",
                    "~/Content/Styles/page-withdraw.min.css",
                    "~/Content/Styles/page-timeline.min.css"))

        bundles.Add(New StyleBundle("~/Content/main-mobile").Include(
                    "~/Content/Styles/main-mobile.min.css",
                    "~/Content/Styles/page-testimonials-mobile.min.css",
                    "~/Content/Styles/page-withdraw-mobile.min.css",
                    "~/Content/Styles/page-timeline-mobile.min.css"))
    End Sub

    Private Sub RegisterScripts(ByVal bundles As BundleCollection)
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include("~/Content/Scripts/Libs/modernizr.min.js"))
        bundles.Add(New ScriptBundle("~/bundles/jquery").Include("~/Content/Scripts/Libs/jquery.min.js"))
        bundles.Add(New ScriptBundle("~/bundles/popper").Include("~/Content/Scripts/Libs/popper.min.js"))
        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include("~/Content/Scripts/Libs/bootstrap.min.js"))
        bundles.Add(New ScriptBundle("~/bundles/animate-on-scroll").Include("~/Content/Scripts/Libs/aos.min.js"))

        bundles.Add(New ScriptBundle("~/bundles/main").Include(
                    "~/Content/Scripts/main.min.js",
                    "~/Content/Scripts/main.form.min.js",
                    "~/Content/Scripts/main.carousel.min.js"))
    End Sub
End Module
