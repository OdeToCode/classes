/// <reference path="../scripts/jquery-1.6.4.js" />
/// <reference path="../scripts/underscore.js" />

if (!jQuery) throw "jQuery required";

var p5 = {
	startShow: function () {
		$("section").each(function (index) {
			var section = $(this);
			if (!section.attr("id")) {
				section.attr("id", index);
			}
		});
		$(window).keydown($.proxy(p5.onkeydown, p5));
		p5.moveForward();
	},

	moveForward: function () {
		move($.fn.next, "section:first");
	},

	moveBackward: function () {
		move($.fn.prev, "section:last");
	},

	move: function (nextFunc, fallbackSelector) {
		var current = $("section.current");
		var next = nextFunc("section");
		if (!next.length) {
			next = $(fallbackSelector);
		}
		current.removeClass("current");
		next.addClass("current");
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
		end: 35
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
				p5.moveForward();
				break;
			case p5.keys.leftArrow:
			case p5.keys.upArrow:
			case p5.keys.pageUp:
				p5.moveBackward();
				break;
		}
	}
};

$(function () {
	p5.startShow();
});

