/// <reference path="jquery-1.4.4-vsdoc.js" />
/// <reference path="jQuery.tmpl.js" />

$(document).ready(function () {

    $(".movieTitle")
        .hover(
            function () { $(this).css("text-decoration", "underline") },
            function () { $(this).css("text-decoration", "none") })
        .click(showMovieDetail);
});

function showMovieDetail() {
    var element = $(this);
    var data = { id: element.attr("id") };
    $.getJSON("Movie/QuickDetails", data,
                    function (detail) {
                        $("#detailTemplate").tmpl(detail)
                                            .appendTo(element);
                    });
}
