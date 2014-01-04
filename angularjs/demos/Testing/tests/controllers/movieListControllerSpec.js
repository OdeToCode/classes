'use strict';

describe('MovieListController', function () {

    beforeEach(module('movieApp'));

    var controller;
    var scope;
    var movieServiceSpy;
    var moviesDeferred;

    var fakeMovieService;

    beforeEach(inject(function ($controller, $rootScope, movieService, $q) {
        scope = $rootScope.$new();
        moviesDeferred = $q.defer();                
        movieServiceSpy = movieService;

        fakeMovieService = {            
          getAll: function() {
              moviesDeferred = $q.defer();
              moviesDeferred.resolve([{}, {}, {}, {}]);
              return moviesDeferred;
          }  
        };

        spyOn(movieServiceSpy, "getAll").andReturn(moviesDeferred.promise);
        controller = $controller('MovieListController',
            { $scope: scope, movieService: movieServiceSpy });
    }));

    it('should be able to create controller', function () {
        expect(controller).toBeTruthy();
    });

    it('should try to retrieve movies', function () {
        expect(movieServiceSpy.getAll).toHaveBeenCalled();
    });

    it('should set movies on an OK response', function () {
        moviesDeferred.resolve({ data: [{}, {}, {}, {}] });
        scope.$apply();
        expect(scope.movies.length).toBe(4);
    });

    it('should not set movies on an error response', function () {
        moviesDeferred.reject("error!");
        scope.$apply();
        expect(scope.movies).toBeUndefined();
    });

    it('should retrieve movies during refresh', function () {
        scope.refresh();
        expect(movieServiceSpy.getAll.calls.length).toEqual(2);
    });
});
