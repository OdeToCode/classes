$(function () {
    var canvas = document.getElementById("theCanvas");
    var ctx = canvas.getContext("2d");
    var angle = 0;

    var image = new Image();
    image.src = "fireball.png";
    image.onload = function () {
        ctx.drawImage(image, 0, 0);
        $(canvas).click(function () {
            angle = 0;
            coolDown();
        });
    };

    function coolDown() {

        ctx.fillStyle = "rgba(255,255,255,0.8)";
        ctx.moveTo(90, 90);
        ctx.beginPath();
        ctx.arc(90, 90, 130, angle * Math.PI / 180, (angle + 4) * Math.PI / 180, false);
        ctx.lineTo(90, 90);
        ctx.fill();
        ctx.closePath();
        angle += 3;
        if (angle < 360) {
            setTimeout(coolDown, 20);
        } else {
            ctx.drawImage(image, 0, 0);
        }
    }
});              