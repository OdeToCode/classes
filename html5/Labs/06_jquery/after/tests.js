module("attributes");

test("get theForm's method attribute value", function () {

    var theForm = $("form[name='theForm']");
    var method = theForm.attr("method");

    equal(1, theForm.length);
    equal(method, "post");
});

test("give theSection a class of happy", function () {

    var section = $("#theSection");
    section.addClass("happy");

    ok(section.hasClass("happy"));
});

test("get the width of theDiv", function () {

    var theDiv = $("#theDiv");
    var width = theDiv.width();

    equal(width, 250);
});

test("store and retrieve data", function () {

    $("body").data("secret", { foo: 1, bar: 2 });

    var data = $("body").data("secret");

    equal(data.foo, 1);
    equal(data.bar, 2);

});

test("wire up a click event on theButton", function () {
    $("#theButton").click(function() {
        // ...
    });

    ok($("#theButton").data("events").click[0].handler);
});

test("get the value of input elements", function () {
    
    var value1 = $("form > input").first().val();
    var value2 = $("form > input").last().val();

    equal(value1, "123");
    equal(value2, "abc");
});

test("iterate with each", function() {
    var result = 0;
    var array = ["1", 2, null];

    $.each(array, function(index, value) {
        if(index === 1) {
            result = value;
          }
    });

    equal(result, 2);
});

test("use extend", function() {
    var object1 = { animal: "cardinal", color: "red" };
    var object2 = { firstName: "woody", color: "blue" };
    
    var result = $.extend(false, object1, object2);

    ok(result.firstName, "woody");
    ok(result.color, "blue");
});

test("use parseJSON", function() {
    var json = '{"name":"animal", "age":2}';
    var result = $.parseJSON(json);

    equal(result.age, 2);
    equal(result.name, "animal");
});

test("proxy a function", function () {

    var employee = {
        name: "Scott",
        getName: function () {
            return this.name;
        }
    };

    var proxy = $.proxy(employee.getName, employee);

    equal(proxy(), "Scott");
});

test("get the text of theDiv", function () {
    var text = $("#theDiv").text();
    equal(text, "Hello, World!");
});

test("get the children of the unordered list", function () {
    var children = $("#theList").children();
    equal(children.length, 4);
});

test("get the second list item", function () {
    var child = $("#theList > li").eq(1);
    equal(child.text(), "2");
});

test("get all but the third list item", function() {
    var allBut = $("#theList > li").not(".three");
    equal(allBut.length, 3);
});

test("get the element previous to list", function () {
    var theList = $("#theList");
    var previous = theList.prev();

    ok(previous.hasClass("target"));
});

test("find disabled elements", function () {
    var disabled = $(":disabled");
    equal(disabled.length, 1);
});

test("select all forms and unordered lists", function () {
    var formsAndUls = $("form, ul");
    equal(formsAndUls.length, 2);
});

test("select everything with an id that starts with 'the'", function() {
    var thes = $("[id^=the]");
    equal(thes.length, 4);
});

test("wire up and programatically trigger a blur event", function () {
    var input = $("input").first();
    var triggered = false;

    input.blur(function () {
        triggered = true;
    });

    input.trigger("blur");

    ok(triggered);
});

test("remove children from target", function() {
    var target = $(".target");
    target.append("<div>");

    target.empty();

    equal(target.children().length, 0);

});

test("use jQuery map function", function () {
    var numbers = [1, 2, 3, 4, 5];
    var result = $.map(numbers, function (value) {
        return value * value;
    });

    deepEqual(result, [1, 4, 9, 16, 25]);
});

test("select even numbered table cells", function () {
    var evens = $("tr:even");
    ok(evens.length, 2);
});

test("serialize a form", function () {

    var result = $("form").serialize();
    equal(result, "1=123&3=abc");
});


