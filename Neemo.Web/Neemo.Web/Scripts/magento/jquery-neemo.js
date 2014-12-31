neemo = neemo || {};

neemo.svc = (function ($, urls) {
    return {
        addOrUpdate: function (productId, qty, successFnc, noStockFnc, qtyTooLargeFnc) {
            $.ajax({
                url: urls.cart.addOrUpdate,
                type: 'POST',
                data: JSON.stringify({ productId: productId, qty: qty }),
                dataType: 'json',
                contentType: 'application/json',
                success: function (response) {
                    if (response.Added) {
                        successFnc();
                    }
                    if (response.NotAvailable) {
                        noStockFnc();
                    }
                    if (response.QuantityTooLarge) {
                        qtyTooLargeFnc();
                    }
                }
            });
        }
    }
})(jQuery, neemo.endpoints);

neemo.ui = (function ($, toastr, svc) {

    $('.btn-cart').on('click', function () {
        var me = $(this);
        var qty = 1;

        // Get the QTY from the UI (if any)
        var $qty = me.prev('input');
        if ($qty) {
            qty = $qty.val();
        }

        svc.addOrUpdate(me.data().productid, qty,
            function () {
                toastr.success(qty + ' item(s) added to cart');
            },
            function () {
                toastr.error('Looks like we are out of stock!');
            },
            function() {
                toastr.error('The quantity requested is too large.');
            });
    });


    $.ajaxSetup({
        error: function () {
            toastr.error('Oh no. We were unable to connect to our server. Check your internet connection and try again.');
        }
    });


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

})(jQuery, toastr, neemo.svc);