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

        $scope.add = function() {
            $scope.movies.push({ title: "New Movie" });
        };

        $scope.delete = function(index) {
            $scope.movies.splice(index, 1);
        };

        $scope.refresh = function() {
            fetchMovies();
        };
        $scope.http = $http.defaults;
    };

    app.controller("MovieListController", MovieListController);

}(angular.module("movieApp")));


