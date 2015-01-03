neemo = neemo || {};

neemo.ui = (function ($, broadcaster, svc, shoppingcart, lineItem) {

    var ui = {};

    var searchFilter = (function (querystring) {
        var q = this;
        q.originalQuery = querystring;
        q.items = querystring.replace('?', '').split('&');
        q.addOrUpdate = function (keyPair) {
            var addOrUpdate = this;
            addOrUpdate.keyPair = keyPair;
            addOrUpdate.exists = false;

            // Locate the item and update it
            $.each(q.items, function(idx,val) {
                if (val.startsWith(addOrUpdate.keyPair.key)) {
                    q.items[idx] = addOrUpdate.keyPair.key + '=' + addOrUpdate.keyPair.newVal;
                    addOrUpdate.exists = true;
                    console.log('exists');
                }
            });
            if (!addOrUpdate.exists) {
                console.log('new');
                q.items.push(keyPair.key + '=' + keyPair.newVal);
            }
            debugger;
        }
        return{
            withpage : function(pageNum) {
                q.addOrUpdate({key: 'page', newVal:pageNum});
            }
        };
    })(window.location.search);

    $('.btn-cart').on('click', function () {
        var me = $(this);
        var qty = 1;

        // Get the QTY from the UI (if any)
        var $qty = me.prev('input');
        if ($qty.length > 0) {
            qty = $qty.val();
            if (qty == '')
                return false;
        }

        svc.addProduct(me.data().productid, qty,
            function (item) {
                broadcaster.success('Your order has been added.');
                ui.cart.items.push(new lineItem( item ));
            },
            function () {
                broadcaster.error('Not enough items in stock for your request.');
            });

        // In case this is a button we'll return false
        return false;
    });

    $.ajaxSetup({
        error: function () {
            broadcaster.error('Oh no. Something went wrong on our server or your connection dropped out.');
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

    $('[data-page-num]').on('click', function () {
        searchFilter.withpage($(this).text());
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