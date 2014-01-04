(function (app) {

    var ListController = function ($scope, movieService) {

        movieService.getAll().success(function (movies) {
            $scope.movies = movies;
        });

        var removeMovieById = function (id) {
            for (var i = 0; i < $scope.movies.length; i++) {
                if ($scope.movies[i].id == id) {
                    $scope.movies.splice(i, 1);
                }
            }
        };      

        $scope.create = function () {
            $scope.edit = { movie: { title: "", runtime: 0, releaseYear: 0 } };
        };
    
        $scope.delete = function (movie) {
            movieService.delete(movie)
                .success(function() {
                    removeMovieById(movie.id);
                });
        };
    };
    ListController.$inject = ["$scope", "movieService"];

    app.controller("ListController", ListController);

}(angular.module("AtTheMovies")));