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

    $("#new").bind('click', function (event) {
        event.preventDefault();
        var elem = this;
        $.ajax({
            'url': "/Movie/CreateAjax",
            'type': 'GET',
            'cache': false,
            'success': function (data) {
                OpenDialog(data);
            }
        });
    });

    function OpenDialog(data) {
        $('#CreateDialog').html(data);
        $('#CreateDialog').dialog({
            'modal': true,
            'width': '70em',
            'buttons': {
                'Save': function (event) {
                    if ($('form').valid()) {
                        PostData();
                    }
                },
                'Cancel': function () {
                    $(this).dialog("close");
                }
            }
        });
    }

    function PostData() {
        $.ajax({
            'url': "/Movie/CreateAjax",
            'type': 'POST',
            'data': $('form').serialize(),
            'success': function (data) {
                if (data.url != undefined) {
                    window.location = data.url;
                }
                $('#CreateDialog').html(data);
            },
            'error': function (data) {
                $('.error').dialog('open');
            }
        });
    }

});