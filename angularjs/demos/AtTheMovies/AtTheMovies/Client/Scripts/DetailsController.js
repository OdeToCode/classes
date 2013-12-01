(function (app) {

    var DetailsController = function ($scope, $routeParams, movieService) {

        movieService.getById($routeParams.id)
                    .success(function(movie) {
                        $scope.movie = movie;
                    });

        $scope.edit = function () {
            $scope.edit.movie = angular.copy($scope.movie);
        };        
    };
    DetailsController.$inject = ["$scope", "$routeParams", "movieService"];

    app.controller("DetailsController", DetailsController);

}(angular.module("AtTheMovies")));