
module("About Numbers (topics/about_numbers.js)");

test("types", function() {
    var typeOfIntegers = typeof(6);
    var typeOfFloats = typeof(3.14159);
    equals(typeOfIntegers === typeOfFloats, true, 'are ints and floats the same type?');
    equals(typeOfIntegers, "number", 'what is the javascript numeric type?');
    equals(1.0, 1, 'what is a integer number equivalent to 1.0?');
});

test("NaN", function() {
    var resultOfFailedOperations = 7/'apple';
    equals(isNaN(resultOfFailedOperations), true, 'what will satisfy the equals assertion?');
    equals(resultOfFailedOperations == NaN, false, 'is NaN == NaN?');
});
