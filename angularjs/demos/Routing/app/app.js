    
angular.module('ngViewExample', ['ngRoute'])

.config(function ($routeProvider, $locationProvider) {
    $routeProvider.when('/Book/:bookId', {
        templateUrl: '/app/templates/book.html',
        controller: BookCntl,
        resolve: {
            delay: function ($q, $timeout) {
                var delay = $q.defer();
                $timeout(delay.resolve, 1000);
                return delay.promise;
            }
        }
    });
    $routeProvider.when('/Book/:bookId/ch/:chapterId', {
        templateUrl: '/app/templates/chapter.html',
        controller: ChapterCntl
    });
    //$routeProvider.otherwise({
    //    redirectTo: "Book/1"
    //});
    
    $locationProvider.html5Mode(true);
});

function MainCntl($scope, $route, $routeParams, $location) {
    $scope.$route = $route;
    $scope.$location = $location;
    $scope.$routeParams = $routeParams;
}

function BookCntl($scope, $routeParams) {
    $scope.name = "BookCntl";
    $scope.params = $routeParams;
}

function ChapterCntl($scope, $routeParams) {
    $scope.name = "ChapterCntl";
    $scope.params = $routeParams;
}