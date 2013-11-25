"use strict";    
(function () {

    var app = angular.module("movieApp", []);

    app.config(function () {
        // configure the application
        //  example: configure routes
    });

    app.run(function ($rootScope) {
        $rootScope.message = "Hi!";
    });

}());

