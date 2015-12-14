$(function () {

    var holder = $("#imageHolder");
    var paper = Raphael(holder.get(0), 180, 180);
    paper.image("fireball.png", 0, 0, 180, 180);

    
    holder.click(function () {    
        coolDown();
    });

    function coolDown() {
        var circle = paper.circle(90, 90, 1);
        circle.attr("fill", "rgba(255,255,255,0.3)");
        circle.animate({ r: 120, fill: "rgba(0,0,0,0.3)" }, 
            1500, function () {
            circle.remove();
        });
    }   
});              