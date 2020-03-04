$(document).ready(function () {
    var hover = 1;
    $(".nav-item.dropdown").hover(function () {
        clearTimeout();
        hover = 1;
    }, function () {
        hover = 0;
        setTimeout(function () {
            if (hover === 0) {
                $(".dropdown-menu").removeClass("show");
            }
        }, 300);
    });

    var path = window.location.pathname;
    if (path.includes("pages")) {
        $("#nav-editor").addClass("selected");
        $("#sidenav-editor").addClass("selected");

        var width = $(window).width();
        if (width < 992) {
            $(".hierarchy-open").show();
        }
    }
    else if (path.includes("images")) {
        $("#nav-assets").addClass("selected");
        $("#sidenav-images").addClass("selected");
    }
    else if (path.includes("settings")) {
        $("#nav-logout").addClass("selected");
        $("#sidenav-general").addClass("selected");
    }
    else if (path.includes("account")) {
        $("#nav-logout").addClass("selected");
        $("#sidenav-account").addClass("selected");
    }
    else {
        $("#nav-home").addClass("selected");
        $("#sidenav-home").addClass("selected");
    }

    $(".sidebar-open").click(function () {
        if ($(window).width() < 512) {
            $(".nav-sidenav").css("width", "100%");
        }
        else {
            $(".nav-sidenav").css("width", "256px");
        }
        $(".nav-sidenav").addClass("show");

        var path = window.location.pathname;
        if (path.includes("pages")) {
            if ($(".hierarchy-wrapper").hasClass("show")) {
                $(".hierarchy-wrapper").removeClass("show");
                $(".hierarchy-open .fa-list-ul").show();
                $(".hierarchy-open .fa-times").hide();
            }
        }
    });

    $(".sidebar-close").click(function () {
        $(".nav-sidenav").css("width", "0");
        $(".nav-sidenav").removeClass("show");

        $("#assets-menu").removeClass("show");
        $("#assets-toggle").removeClass("selected");
        $("#account-menu").removeClass("show");
        $("#account-toggle").removeClass("selected");
    });

    $("#assets-toggle").click(function () {
        if (!$("#assets-menu").hasClass("show")) {
            $("#account-menu").removeClass("show");
            $("#account-toggle").parent().removeClass("selected");

            $("#assets-menu").addClass("show");
            $("#assets-toggle").parent().addClass("selected");
        }
        else {
            $("#assets-menu").removeClass("show");
            $("#assets-toggle").parent().removeClass("selected");
        }
    });

    $("#account-toggle").click(function () {
        if (!$("#account-menu").hasClass("show")) {
            $("#assets-menu").removeClass("show");
            $("#assets-toggle").parent().removeClass("selected");

            $("#account-menu").addClass("show");
            $("#account-toggle").parent().addClass("selected");
        }
        else {
            $("#account-menu").removeClass("show");
            $("#account-toggle").parent().removeClass("selected");
        }
    });

    $(".hierarchy-open").click(function () {
        if (!$(".hierarchy-wrapper").hasClass("show")) {
            $(".hierarchy-wrapper").addClass("show");
            $(".hierarchy-open .fa-list-ul").hide();
            $(".hierarchy-open .fa-times").show();

            if ($(".nav-sidenav").hasClass("show")) {
                $(".nav-sidenav").css("width", "0");
                $(".nav-sidenav").removeClass("show");
            }
        }
        else {
            $(".hierarchy-wrapper").removeClass("show");
            $(".hierarchy-open .fa-list-ul").show();
            $(".hierarchy-open .fa-times").hide();
        }
    });
});

$(window).resize(function () {
    var width = $(window).width();
    if (width >= 992) {
        $(".hierarchy-open").hide();
    }
    else {
        var path = window.location.pathname;
        if (path.includes("pages")) {
            $(".hierarchy-open").show();
        }
    }
});
