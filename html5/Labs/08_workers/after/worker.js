self.onmessage = function (event) {
    findPrimeNumber(event.data.min, event.data.max);    
};

function findPrimeNumber(min, max) {          
    for(var n = min; n < max; n++) {          
        var isPrime = true;
        for(var i = 2; i < Math.sqrt(n); i++) {
            if(n % i == 0) {
                isPrime = false;
                continue;
            }
        }
        if(isPrime) {
            postMessage(n);
        }
    }
}