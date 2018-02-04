//$(document).ready(function() {
//    //$('#span').each(function () {
//    //    var elem = $(this);
//    //    setInterval(function () {
//    //        if (elem.css('visibility') == 'hidden') {
//    //            elem.css('visibility', 'visible');
//    //        } else {
//    //            elem.css('visibility', 'hidden');
//    //        }
//    //    }, 500);
//    //});

 
//});

$(document).ready(function () {
    setInterval(function() {
        $("#span").fadeOut(function() {
            $(this).fadeIn();
        });
    }, 300)
});
