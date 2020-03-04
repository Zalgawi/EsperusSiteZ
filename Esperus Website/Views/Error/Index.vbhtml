@Code
    ViewData("Title") = "Error"
    Layout = "~/Views/Shared/Layouts/_SiteLayout.vbhtml"
End Code

<header>
    @Html.Partial("~/Views/Shared/Partials/Header.vbhtml")
</header>

<div class="content-wrapper">
    <div class="container">
        <div class="row">
            <div class="col-md-6 ml-auto mr-auto">
                <h1>
                    Error @Html.Encode(ViewData("Code"))
                </h1>
                <p>
                    An error occurred while processing your request. This incident has been logged and will be examined by our development team.
                    Please return to the page you were on previously, or click the button below to return to safety.
                </p>

                <a class="button" href="@Url.Action("Index", "Site")" style="margin: 0;">
                    Home
                </a>
            </div>
        </div>
    </div>
</div>
