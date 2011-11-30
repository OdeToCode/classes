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

    var loaded = false;
    var imagebw = new Image();
    imagebw.src = "fireballbw.png";
    imagebw.onload = function () {
        loaded = loaded = true;
    };


    function coolDown() {

        ctx.fillStyle = ctx.createPattern(imagebw, "no-repeat");
        ctx.moveTo(90, 90);
        ctx.beginPath();
        ctx.arc(90, 90, 130, angle * Math.PI / 180, (angle + 5) * Math.PI / 180, false);
        ctx.lineTo(90, 90);
        ctx.fill();
        ctx.closePath();
        angle += 4;
        if (angle < 360) {
            setTimeout(coolDown, 20);
        } else {
            ctx.drawImage(image, 0, 0);
        }
    }
});            