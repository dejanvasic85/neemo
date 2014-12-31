var neemojs = (function ($, toastr) {

    // Cart functions
    $('.btn-cart').on('click', function () {
        var me = $(this);
        var id = me.data().productid;
        var qty = 1;

        // Get the from the UI (if any)
        var $qty = me.prev('input');
        if ($qty) {
            qty = $qty.val();
        }

        $.ajax({
            url: me.data().carturl,
            type: 'POST',
            data: JSON.stringify({ productId: id, qty: qty }),
            dataType: 'json',
            contentType: 'application/json',
            success: function (response) {
                toastr.info('Item has been added to your cart');
            }
        });
    });

    //jQuery hooks
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

    // Service
    function cartService() {
        
    }

})(jQuery, toastr);