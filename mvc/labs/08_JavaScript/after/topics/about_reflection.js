module("About Reflection (topics/about_reflection.js)");

test("typeof", function() {
    equals(typeof({}), "object", 'what is the type of an empty object?');
    equals(typeof('apple'), "string", 'what is the type of a string?');
    equals(typeof(-5), "number", 'what is the type of -5?');
    equals(typeof(false), "boolean", 'what is the type of false?');		
});

test("property enumeration", function() {
    var keys = [];
    var values = [];
    var person = {name: 'Amory Blaine', age: 102, unemployed: true};
    for(propertyName in person) {
        keys.push(propertyName);
        values.push(person[propertyName]);
    }
    ok(keys.equalTo(['name','age','unemployed']), 'what are the property names of the object?');
    ok(values.equalTo(['Amory Blaine',102, true]), 'what are the property values of the object?');
});

test("hasOwnProperty", function() {
    // hasOwnProperty returns true if the parameter is a property directly on the object, 
    // but not if it is a property accessible via the prototype chain.
    var keys = [];
    var fruits =  ['apple', 'orange'];
    for(propertyName in fruits) {
        keys.push(propertyName);
    }
    ok(keys.equalTo(['0', '1', 'equalTo']), 'what are the properties of the array?');

    var ownKeys = [];
    for(propertyName in fruits) {
        if (fruits.hasOwnProperty(propertyName)) {
            ownKeys.push(propertyName);
        }
    }
    ok(ownKeys.equalTo(['0', '1']), 'what are the own properties of the array?');
});

test("eval", function() {
    // eval executes a string
    var result = "";
    eval("result = 'apple' + ' ' + 'pie'");
    equals(result, "apple pie", 'what is the value of result?');
});
