"use strict";
(function (app) {

    var MovieListController = function ($scope, movieService, $http) {
                                        
        var fetchMovies = function() {
            movieService
            .getAll()
            .then(function (result) {
                $scope.movies = result.data;
            });
        };

        fetchMovies();

        $scope.refresh = function() {
            fetchMovies();
        };
        $scope.http = $http.defaults;
    };

    app.controller("MovieListController", MovieListController);

}(angular.module("movieApp")));


