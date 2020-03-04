Imports System.Web.Optimization

Namespace Areas.Admin
    Public Class BundleConfig
        Public Shared Sub RegisterBundles(ByVal bundles As BundleCollection)
            RegisterScripts(bundles)
            RegisterStyles(bundles)

            ' NOTE: For some reason EnableOptimizations wreaks havok with IE 11, causing the browser to crash to desktop.
            BundleTable.EnableOptimizations = False ' Defaults to the minified CSS and JS - switch to 'True' for production.
            bundles.UseCdn = False ' Defaults to the CDN resource if it is available.
        End Sub

        Private Shared Sub RegisterStyles(ByVal bundles As BundleCollection)
            bundles.Add(New StyleBundle("~/Content/bootstrap-treeview").Include("~/Areas/Admin/Content/Styles/Libs/bootstrap.treeview.min.css"))

            bundles.Add(New StyleBundle("~/Content/trumbowyg").Include(
                    "~/Areas/Admin/Content/Styles/Libs/Trumbowyg/trumbowyg.min.css",
                    "~/Areas/Admin/Content/Styles/Libs/Trumbowyg/Plugins/trumbowyg.specialchars.min.css"))

            bundles.Add(New StyleBundle("~/Content/admin").Include(
                    "~/Areas/Admin/Content/Styles/admin.min.css",
                    "~/Areas/Admin/Content/Styles/admin.editor.min.css"))

            bundles.Add(New StyleBundle("~/Content/admin-mobile").Include(
                        "~/Areas/Admin/Content/Styles/admin.mobile.min.css",
                        "~/Areas/Admin/Content/Styles/admin.editor.mobile.min.css"))
        End Sub

        Private Shared Sub RegisterScripts(ByVal bundles As BundleCollection)
            bundles.Add(New ScriptBundle("~/bundles/bootstrap-treeview").Include("~/Areas/Admin/Content/Scripts/Libs/bootstrap.treeview.min.js"))

            bundles.Add(New ScriptBundle("~/bundles/trumbowyg").Include(
                    "~/Areas/Admin/Content/Scripts/Libs/Trumbowyg/trumbowyg.min.js",
                    "~/Areas/Admin/Content/Scripts/Libs/Trumbowyg/Plugins/trumbowyg.cleanpaste.min.js",
                    "~/Areas/Admin/Content/Scripts/Libs/Trumbowyg/Plugins/trumbowyg.history.min.js",
                    "~/Areas/Admin/Content/Scripts/Libs/Trumbowyg/Plugins/trumbowyg.specialchars.min.js"))

            bundles.Add(New ScriptBundle("~/bundles/admin").Include("~/Areas/Admin/Content/Scripts/admin.min.js"))
            bundles.Add(New ScriptBundle("~/bundles/admin-injector").Include("~/Areas/Admin/Content/Scripts/admin.injector.min.js"))
            bundles.Add(New ScriptBundle("~/bundles/admin-pages").Include("~/Areas/Admin/Content/Scripts/admin.pages.min.js"))
            bundles.Add(New ScriptBundle("~/bundles/admin-reports").Include("~/Areas/Admin/Content/Scripts/admin.reports.min.js"))
            bundles.Add(New ScriptBundle("~/bundles/admin-gallery").Include("~/Areas/Admin/Content/Scripts/admin.gallery.min.js"))
        End Sub
    End Class
End Namespace
