'use strict';

describe('MovieService', function () {

    beforeEach(module('movieApp'));

    var service;
    var httpBackend;

    beforeEach(inject(function ($http, $httpBackend, movieService) {
        service = movieService;
        httpBackend = $httpBackend;
        httpBackend.when("GET", "/movieApp/data/movies.json").respond([{}, {}]);        
    }));

    it("returns three movies", function() {
        var movies;
        service.getAll().then(function (result) {
            movies = result.data;
        });
        httpBackend.flush();
        expect(movies.length).toEqual(2);
    });
    
    it("returns three movies (with expect)", function () {
        httpBackend.expectGET('/movieApp/data/movies.json');
        service.getAll();
        httpBackend.flush();        
    });

});
