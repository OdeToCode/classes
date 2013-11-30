"use strict";
(function (app) {

    var MovieListController = function ($scope, movieService) {
                                        
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
    };

    app.controller("MovieListController", MovieListController);

}(angular.module("movieApp")));


