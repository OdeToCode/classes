$(document).bind("pagecreate", function () {
    "use strict";
    $("#toggler").change(function () {

        var selected = this[this.selectedIndex].value;

        if (selected == "on") {
            perfSurf.start();
        }
        else {
            perfSurf.stop();
        }
    });
});

(function($) {
    "use strict";
    $.fn.rgraph = function(points) {
        return this.each(function() {                        
            RGraph.Clear(this);
            var graph = new RGraph.Line(this, points);
            graph.Set('chart.background.grid', false);
            graph.Set('chart.linewidth', 2);
            if (!document.all || RGraph.isIE9up()) {
                graph.Set('chart.shadow', true);
            }
            graph.Set('chart.tickmarks', null);
            graph.Set('chart.background.grid.autofit', true);
            graph.Set('chart.curvy', 1);
            graph.Draw();                     
        });
    };          
})(jQuery);

var perfSurf = function () {
    "use strict";

    var counterResults = {};
    var perfCounters = $.connection.performanceCounter;

    perfCounters.updateCounters = function (data) {
        drawResults(data);
    };

    var start = function () {
        reset();
        $.connection.hub.start().then(function() {
            perfCounters.connect();
        });
        
    };

    var stop = function () {
        $.connection.hub.stop();
    };

    var reset = function () {
        $("#perfOutput").empty();
        counterResults = {};
    };

    var drawResults = function (data) {
        if ($("#perfOutput > div").length == 0) {
            createOutputs(data);
        }
        for (var i in data) {
            var result = data[i];
            var points = counterResults[result.Name];
            points.push(result.Value);
            if (points.length > 100) {
                points.splice(0, 1);
            }
            var outputSection = $("#" + result.Name);
            $(".sparkline", outputSection).sparkline(points);
            $(".rgraph", outputSection).rgraph(points);
        }
    };

    var createOutputs = function (data) {
        for (var i in data) {
            var name = data[i].Name;
            $("#counterTemplate").tmpl(data[i])
                                 .appendTo("#perfOutput")
                                 .collapsible();
            counterResults[name] = [];
        }
    };

    return {
        start: start,
        stop: stop
    };
} ();