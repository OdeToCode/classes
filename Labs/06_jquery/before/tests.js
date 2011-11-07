test("get theForm's method value", function () {

    var theForm = $("___");
    var method = theForm.___;

    equal(1, theForm.length);
    equal(method, "post");
});

test("give theSection a class of happy", function () {

    var section = $("____");
    section.____;

    ok(section.hasClass("happy"));
});

test("get the width of theDiv", function () {

    var theDiv = $("____");
    var width = theDiv.____;

    equal(width, 250);
});

test("store and retrieve data", function () {

    $("body").____("secret", { foo: 1, bar: 2 });

    var data = $("body").____;

    equal(data.foo, 1);
    equal(data.bar, 2);

});

test("wire up a click event on theButton", function () {
    $("____").____(function() {
        // ...
    });

    ok($("#theButton").data("events").click[0].handler);
});

test("get the value of input elements", function () {
    
    var value1 = $("____").____().____();
    var value2 = $("____").____().____();

    equal(value1, "123");
    equal(value2, "abc");
});

test("iterate with each", function() {    
    var array = ["1", 2, null];
    var result = 0;
    
    $.each(array, ____);

    equal(result, 2);
});

test("use extend", function() {
    var object1 = { animal: "cardinal", color: "red" };
    var object2 = { firstName: "woody", color: "blue" };
    
    var result = $.extend(____);

    ok(result.firstName, "woody");
    ok(result.color, "blue");
});

test("parse json", function() {
    var json = '{"name":"animal", "age":2}';
    var result = $.____(json);

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

    var proxy = $.____(employee.getName, ____);

    equal(proxy(), "Scott");
});

test("get the text of theDiv", function () {
    var text = $("____").____;
    equal(text, "Hello, World!");
});

test("get the children of the unordered list", function () {
    var children = $("____").____();
    equal(children.length, 4);
});

test("get the second list item", function () {
    var child = $("____").____(1);
    equal(child.text(), "2");
});

test("get all but the third list item", function() {
    var allBut = $("____").___(".three");
    equal(allBut.length, 3);
});

test("get the element previous to list", function () {
    var theList = $("____");
    var previous = theList.____();

    ok(previous.hasClass("target"));
});

test("find disabled elements", function () {
    var disabled = $("____");
    equal(disabled.length, 1);
});

test("select all forms and unordered lists", function () {
    var formsAndUls = $("_____");
    equal(formsAndUls.length, 2);
});

test("select everything with an id that starts with 'the'", function() {
    var thes = $("_____");
    equal(thes.length, 4);
});

test("wire up and programatically trigger a blur event", function () {
    var input = $("input").first();
    var triggered = false;

    input.____(function () {
        triggered = true;
    });

    input.____("blur");

    ok(triggered);
});

test("remove children from target", function() {
    var target = $(".target");
    target.append("<div>");

    target.____();

    equal(target.children().length, 0);

});

test("use jQuery map function to square the numbers", function () {
    var numbers = [1, 2, 3, 4, 5];
    var result = $.map(numbers, _____);

    deepEqual(result, [1, 4, 9, 16, 25]);
});

test("select even numbered table cells", function () {
    var evens = $("____");
    ok(evens.length, 2);
});

test("serialize a form", function () {

    var result = $("____").____();
    equal(result, "1=123&3=abc");
});


