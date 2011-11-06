
module("About Arrays (topics/about_arrays.js)");

test("array literal syntax and indexing", function() {
    var favouriteThings = ["cellar door", 42, true]; // note that array elements do not have to be of the same type
    equals(favouriteThings[0], "cellar door", 'what is in the first position of the array?');
    equals(favouriteThings[1], 42, 'what is in the second position of the array?');
    equals(favouriteThings[2], true, 'what is in the third position of the array?');
});

test("array type", function() {
    equals(typeof([]), "object", 'what is the type of an array?');
});

test("length", function() {
    var collection = ['a','b','c'];
    equals(collection.length, 3, 'what is the length of the collection array?');
});

test("splice", function() {
    var daysOfWeek = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];
    var workingWeek = daysOfWeek.splice(0,5);
    ok(workingWeek.equalTo(['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday']), 'what is the value of workingWeek?');
    ok(daysOfWeek.equalTo(['Saturday', 'Sunday']), 'what is the value of daysOfWeek?');
});

test("stack methods", function() {
    var stack = [];
    stack.push("first");
    stack.push("second");

    equals(stack.pop(), "second", 'what will be the first value poped off the stack?');
    equals(stack.pop(), "first", 'what will be the second value poped off the stack?');
});
