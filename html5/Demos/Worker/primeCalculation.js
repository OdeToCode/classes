var isPrime = true;
var n = 1000000000;

while (true) {
    n += 1;
    isPrime = true;
    for (var i = 2; i <= Math.sqrt(n); i += 1) {
        if (n % i == 0) {
            isPrime = false;
            continue;
        }
    }
    // found a prime!
    if (isPrime) {
        postMessage(n);
    }
}