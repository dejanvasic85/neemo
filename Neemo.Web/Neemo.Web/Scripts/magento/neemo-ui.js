neemo = neemo || {};

neemo.ui = (function ($, toastr, svc, shoppingcart, lineItem) {

    var ui = {};

    $('.btn-cart').on('click', function () {
        var me = $(this);
        var qty = 1;

        // Get the QTY from the UI (if any)
        var $qty = me.prev('input');
        if ($qty.length > 0) {
            qty = $qty.val();
        }

        svc.addProduct(me.data().productid, qty,
            function (item) {
                toastr.success('Your order has been added.');
                ui.cart.items.push(new lineItem( item ));
            },
            function () {
                toastr.error('Not enough items in stock for your request.');
            });

        // In case this is a button we'll return false
        return false;
    });


    $.ajaxSetup({
        error: function () {
            toastr.error('Oh no. Something went wrong on our server or your connection dropped out.');
        }
    });


    $('input[data-numbers-only]').on('keypress', function (e) {
        if ((e.which < 48 || e.which > 57)) {
            if (e.which === 8 || e.which === 46 || e.which === 0) {
                return true;
            } else {
                return false;
            }
        }
    });

    // Initialise the shopping cart
    svc.getItems().then(function (items) {
        var viewModels = [];
        $.each(items, function () {
            viewModels.push(new lineItem(this));
        });
        var cart = new shoppingcart(viewModels);
        ui.cart = cart;
        ko.applyBindings(cart);
    });

    return ui;

})(jQuery, toastr, neemo.svc, neemo.shoppingCart, neemo.lineItem);