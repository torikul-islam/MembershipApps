$(function() {
    $(".panel-carret").click(function(e) {
        $(this).toggleClass("pressed");
        $(this).children("glyphicon-play").toggleClass("pressed");
        e.preventDefault();

    });
});