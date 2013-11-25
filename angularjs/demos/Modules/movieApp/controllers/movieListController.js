"use strict";
(function (app) {

    var MovieListController = function ($scope) {

        $scope.movies = [
            { title: "Star Wars" },
            { title: "Hunger Games" },
            { title: "Indiana Jones" }
        ];
    };

    app.controller("MovieListController", MovieListController);

}(angular.module("movieApp")));


