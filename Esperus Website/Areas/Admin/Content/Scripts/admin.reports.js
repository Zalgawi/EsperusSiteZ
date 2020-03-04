var _currentRange, _currentText, _currentSelected;

// Google Analytics Embed API
(function (w, d, s, g, js, fjs) {
    g = w.gapi || (w.gapi = {}); g.analytics = { q: [], ready: function (cb) { this.q.push(cb) } };
    js = d.createElement(s); fjs = d.getElementsByTagName(s)[0];
    js.src = 'https://apis.google.com/js/platform.js';
    fjs.parentNode.insertBefore(js, fjs); js.onload = function () { g.load('analytics') };
}(window, document, 'script'));

gapi.analytics.ready(function () {
    gapi.analytics.auth.authorize({
        serverAuth: {
            access_token: model.Token
        }
    });

    _currentRange = "30daysAgo";
    _currentText = "30 Days";

    displayDashboard(_currentRange);
    $(".dashboard-date-toggle").text(_currentText);
});

$(document).ready(function () {
    $('.dashboard-date').click(function () {
        _currentSelected = $(this);
        _currentRange = $(this).attr('value');
        _currentText = $(this).text();
        refreshDashboard();
    });
});

$(window).resize(function () {
    var width = $(window).width();
    if (width == 992) {
        refreshDashboard();
    }
    else if (width == 768) {
        refreshDashboard();
    }
    else if (width == 576) {
        refreshDashboard();
    }
});

function refreshDashboard() {
    $("#embed-api-chart-1").empty();
    $("#embed-api-chart-2").empty();
    $("#embed-api-chart-3").empty();
    $("#embed-api-chart-4").empty();
    $("#embed-api-chart-5").empty();

    displayDashboard(_currentRange);
    $(".dashboard-date-toggle").text(_currentText);
}

function displayDashboard(timeframe) {
    var viewSelector_1 = new gapi.analytics.ViewSelector({ container: 'embed-api-viewselect-1' });
    viewSelector_1.execute();

    var viewChart_1 = new gapi.analytics.googleCharts.DataChart({
        query: {
            metrics: ['ga:users'],
            dimensions: 'ga:date',
            'start-date': timeframe,
            'end-date': 'yesterday'
        },
        chart: {
            container: 'embed-api-chart-1',
            type: 'LINE',
            options: {
                width: '100%',
            }
        }
    });

    viewSelector_1.on('change', function (ids) {
        viewChart_1.set({ query: { ids: ids } }).execute();
    });

    var viewSelector_2 = new gapi.analytics.ViewSelector({ container: 'embed-api-viewselect-2' });
    viewSelector_2.execute();

    var viewChart_2 = new gapi.analytics.googleCharts.DataChart({
        query: {
            metrics: 'ga:pageviews',
            dimensions: 'ga:pagetitle',
            'start-date': timeframe,
            'end-date': 'yesterday',
            sort: '-ga:pageviews',
            'max-results': 15
        },
        chart: {
            container: 'embed-api-chart-2',
            type: 'TABLE',
            options: {
                width: '100%',
            }
        }
    });

    viewSelector_2.on('change', function (ids) {
        viewChart_2.set({ query: { ids: ids } }).execute();
    });

    var viewSelector_3 = new gapi.analytics.ViewSelector({ container: 'embed-api-viewselect-3' });
    viewSelector_3.execute();

    var viewChart_3 = new gapi.analytics.googleCharts.DataChart({
        query: {
            metrics: 'ga:users',
            dimensions: 'ga:usertype',
            'start-date': timeframe,
            'end-date': 'yesterday'
        },
        chart: {
            container: 'embed-api-chart-3',
            type: 'PIE',
            options: {
                width: '100%',
            }
        }
    });

    viewSelector_3.on('change', function (ids) {
        viewChart_3.set({ query: { ids: ids } }).execute();
    });

    var viewSelector_4 = new gapi.analytics.ViewSelector({ container: 'embed-api-viewselect-4' });
    viewSelector_4.execute();

    var viewChart_4 = new gapi.analytics.googleCharts.DataChart({
        query: {
            metrics: 'ga:users',
            dimensions: 'ga:devicecategory',
            'start-date': timeframe,
            'end-date': 'yesterday'
        },
        chart: {
            container: 'embed-api-chart-4',
            type: 'PIE',
            options: {
                width: '100%',
            }
        }
    });

    viewSelector_4.on('change', function (ids) {
        viewChart_4.set({ query: { ids: ids } }).execute();
    });

    var viewSelector_5 = new gapi.analytics.ViewSelector({ container: 'embed-api-viewselect-5' });
    viewSelector_5.execute();

    var viewChart_5 = new gapi.analytics.googleCharts.DataChart({
        query: {
            metrics: 'ga:organicsearches, ga:searchuniques',
            dimensions: 'ga:date',
            'start-date': timeframe,
            'end-date': 'yesterday'
        },
        chart: {
            container: 'embed-api-chart-5',
            type: 'COLUMN',
            options: {
                width: '100%',
            }
        }
    });

    viewSelector_5.on('change', function (ids) {
        viewChart_5.set({ query: { ids: ids } }).execute();
    });
}
