"use strict";
/// <reference path="../scripts/jquery-1.6.4.js" />

if (!jQuery) throw "jQuery required";
if (!prettyPrint) throw "google-code-prettifier required";

var p5 = {
    startShow: function () {
        p5.assignSectionIds();
        $(window).bind("keydown", $.proxy(p5.onkeydown, p5))
                 .bind("hashchange", $.proxy(p5.hashchange, p5));

        if (window.location.hash) {
            p5.moveTo(window.location.hash);
        }
        else {
            p5.moveForward();
        }
    },

    assignSectionIds: function () {
        $("section").each(function (index) {
            var section = $(this);
            if (!section.attr("id")) {
                section.attr("id", index + 1);
            }
        });
    },

    moveForward: function () {
        p5.move(function (current) {
            var result = current.next("section");
            if (!result.length) {
                result = $("section:first");
            }
            return result;
        });
    },

    moveBackward: function () {
        p5.move(function (current) {
            var result = current.prev("section");
            if (!result.length) {
                result = $("section:last");
            }
            return result;
        });
    },

    moveTo: function (id) {
        p5.move(function () {
            return $(id);
        });
    },

    move: function (nextFunc) {
        var current = $("section.current");
        var next = nextFunc(current);

        current.removeClass("current");
        next.addClass("current");
        window.history.pushState({ id: next.attr("id").toString() }, null,
		                         "#" + next.attr("id").toString());
        
        if (p5.options.showNextText) {
            p5.setNextText();
        }
    },

    setNextText: function () {
        var current = $("section.current");
        var next = current.next("section");
        var header = (next && $("h1", next).text()) || "";
        var nextDiv = $(".nextText");
        if (!nextDiv.length) {
            nextDiv = $("<div></div>").addClass("nextText");
            nextDiv.css({ position: "absolute", bottom: 0, left: 0 });
            $("body").append(nextDiv);
        }
        nextDiv.text("Next: " + header);
    },

    keys: {
        rightArrow: 39,
        downArrow: 40,
        pageDown: 34,
        space: 32,
        leftArrow: 37,
        upArrow: 38,
        pageUp: 33,
        home: 36,
        end: 35,
        s: 83
    },

    isSpecialKeyDown: function (event) {
        return event.altKey || event.ctrlKey;
    },

    onkeydown: function (event) {
        if (p5.isSpecialKeyDown(event)) {
            return;
        }

        switch (event.keyCode) {
            case p5.keys.rightArrow:
            case p5.keys.downArrow:
            case p5.keys.pageDown:
            case p5.keys.space:
                event.preventDefault();
                p5.moveForward();
                break;
            case p5.keys.leftArrow:
            case p5.keys.upArrow:
            case p5.keys.pageUp:
                event.preventDefault();
                p5.moveBackward();
                break;
        }
    },

    hashchange: function () {
        p5.startShow();
    },
    
    options: {
        showNextText: true
    }
};

$(function () {
	
	$("section > h1").addClass("row span16 center");
	$("section > ul").addClass("row span16");
	$("section pre").addClass("row span16 prettyprint");
	
    prettyPrint();
	p5.startShow();
});

