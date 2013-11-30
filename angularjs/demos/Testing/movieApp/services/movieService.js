(function (app) {

    var movieService = function ($http) {

        var getAll = function () {

            return $http.get("/movieApp/data/movies.json",
                    {
                        headers: { "X-Custom-Header": "CustomValue" },
                        cache: true
                    }
                );
        };

        return {
            getAll: getAll
        };
    };

    app.factory("movieService", movieService);

}(angular.module("movieApp")));