/// <reference path="jquery-1.4.4-vsdoc.js" />
/// <reference path="jquery.validate-vsdoc.js" />
/// <reference path="jquery.validate.unobtrusive.js" />

jQuery.validator.unobtrusive.adapters.addSingleVal(
    "wordcount", "maxwords");

jQuery.validator.addMethod("wordcount", 
        function (value, element, maxWords) {
   if (value) {
        var wordCount = value.split(' ').length;
        if (wordCount <= maxWords) {
            return true;
        }
        return false;
    }
    return true;
});