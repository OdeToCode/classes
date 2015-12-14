/// <reference path="jquery-1.3.2.min-vsdoc.js" />

$(document).ready(function() {

    $("input").hide().blur(function() {
        getEvaluationResults();
    });
    getEvaluationResults();
});

function getEvaluationResults() {
    $.ajax({
        url: "/Home/EvaluateMovie",
        type: "POST",
        dataType: "json",
        data: $("form").serialize(),
        success: processEvaluationResults
    });
}

function processEvaluationResults(results) {
    if (results.result == 0) {
        $(".header").text("Needs more information");
    }
    else if (results.result == 1) {
        $(".header").text("You've made a great Movie!");
    }
    else if (results.result == 2) {
        $(".header").text("This is terrible");
    }

    $(results.required).each(function() {
        
        $("#" + this).show();

    });
    
    
    
    
}