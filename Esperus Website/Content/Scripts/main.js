$(document).ready(function () {
    $("#header-carousel").carousel({
        interval: 8000,
        ride: "carousel",
        keyboard: false,
        pause: false,
        wrap: true
    });

    AOS.init({
        disable: 'mobile'
    });

    /*
     * Sets hidden fields in the request demo and contact forms
     * before the data is sent back to the server, so that the server
     * can pick up the values from those hidden fields.
     */
    $("#request-submit").click(function () {
        var referee = $("#referee option:selected").text();
        var timeframe = $("#timeframe option:selected").text();
        var type = $("#type option:selected").text();

        if (referee == $("#referee option").first().text()) {
            $("#referee-selected").val("Not Specified");
        }
        else {
            $("#referee-selected").val(referee);
        }

        if (timeframe == $("#timeframe option").first().text()) {
            $("#timeframe-selected").val("Not Specified");
        }
        else {
            $("#timeframe-selected").val(timeframe);
        }

        if (type == $("#type option").first().text()) {
            $("#type-selected").val("Not Specified");
        }
        else {
            $("#type-selected").val(type);
        }
    });

    $("#scroll-top").click(function () {
        $('html, body').animate({ scrollTop: '0px' }, 1200, 'swing');
    });

    $(".sidebar-open").click(function () {
        if ($(window).width() < 576) {
            $(".nav-sidenav").css("width", "100%");
        }
        else {
            $(".nav-sidenav").css("width", "256px");
        }
        $(".nav-sidenav").addClass("show");
    });

    $(".sidebar-close").click(function () {
        $(".nav-sidenav").css("width", "0px");
        $(".nav-sidenav").removeClass("show");
    });

    highlight_page();
});

// Highlights the current page in both the navigation menu, and the sidebar menu.
function highlight_page() {
    var pages = ["retail", "wholesale", "ecommerce", "about", "testimonials", "contact", "clients"];
    var path = window.location.pathname;
    path = path.split("/").pop();

    for (i = 0; i < pages.length; i++) {
        if (path.toUpperCase() === pages[i].toUpperCase()) {
            $("#nav-" + pages[i]).addClass("selected");
            $("#sidebar-" + pages[i]).addClass("selected");
        }
    }
}

function form_recaptcha_callback() {
    $(".form-submit").show();
    $(".g-recaptcha").hide();
}
