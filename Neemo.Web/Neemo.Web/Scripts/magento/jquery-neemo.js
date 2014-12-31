(function ($) {
    $('input[data-numbers-only]').on('keypress', function (e) {
        if ((e.which < 48 || e.which > 57)) {
            if (e.which == 8 || e.which == 46 || e.which == 0) {
                return true;
            }
            else {
                return false;
            }
        }
    });
})(jQuery);