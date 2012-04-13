$(function () {

    $('.movie a.image').bind('click', function (event) {
        var elem = $(this).parent();
        elem.hide();
        elem.next("section.trailer").show();
        event.preventDefault();
    });

    $('section.trailer a.close').bind('click', function (event) {
        var elem = $(this).parent();
        elem.hide();
        elem.prev().show();
        event.preventDefault();
    });
});