(function(app) {

    app.run(function($rootScope) {

    	$rootScope.count = 1;

        $rootScope.$on("myEmitEvent", function(event, args) {
            $rootScope.count += args.count;
        });

        $rootScope.broadcastMessage = function() {
        	$rootScope.$broadcast("myBroadcastEvent", {
                a: "b"
            });
        };
    });

    var SimpleController = function($scope, simpleService) {

        var incrementCount = function() {

            $scope.$apply(function() {
                $scope.count += 1;
            });
        	
            setTimeout(incrementCount, 1000);
        };
        setTimeout(incrementCount, 1000);

    	$scope.count = 1;
        
        $scope.$on("myBroadcastEvent", function() {
            $scope.args = arguments;
        });

        $scope.emitMessage = function() {
        	$scope.$emit("myEmitEvent", { count: 1 });
            simpleService.getValue()
                .then(function(result) {
                    $scope.simpleResult = result;
                });
        };

        $scope.changeMessage = function() {
            $scope.message = "Hello, " + $scope.firstName;
        };
    };

    app.controller("SimpleController", SimpleController);
   

}(angular.module("viewApp", [])));