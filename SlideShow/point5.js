/// <reference path="../scripts/jquery-1.6.4.js" />

if (!jQuery) throw "jQuery required";

var p5 = {
	startShow: function () {
		$(window).keydown($.proxy(p5.onkeydown, p5));
		p5.moveForward();
	},

	moveForward: function () {
		var currentSlide = $("section.current");
		var nextSlide = currentSlide.next("section");
		if (!nextSlide.length) {
			nextSlide = $("section:first");
		}
		currentSlide.removeClass("current");
		nextSlide.addClass("current");
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
		}
	}
};

$(function () {
	p5.startShow();
});

