(function () {
    'use strict';
    
    function onActivated() {        
        setFavoriteNumber(WinJS.Application.sessionState.favoriteNumber);
        var setFavorite = document.getElementById("setFavorite");
        setFavorite.addEventListener("click", function () {
            var number = getFavoriteNumber();
            var output = document.getElementById("output");
            output.textContent = "Your favorite number is " + number;
        });
    }

    function getFavoriteNumber() {
        return document.querySelector("[name='favorite']").value;
    }

    function setFavoriteNumber(number) {
        document.querySelector("[name='favorite']").value = number;
    }

    function onCheckpoint() {
        WinJS.Application.sessionState.favoriteNumber
            = getFavoriteNumber();
    }

    WinJS.Application.addEventListener("activated", onActivated);
    WinJS.Application.addEventListener("checkpoint", onCheckpoint);
    WinJS.Application.start();
})();