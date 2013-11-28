"use strict";    
(function () {

    var app = angular.module("movieApp", []);

    app.config(function ($httpProvider) {
        $httpProvider.defaults.headers.common["X-Config"] = "Configured";
    });

    app.run(function ($rootScope) {
        $rootScope.message = "Hi!";
    });

}());

angular.element(document).ready(function () {
    angular.bootstrap(document, ['movieApp']);
});

