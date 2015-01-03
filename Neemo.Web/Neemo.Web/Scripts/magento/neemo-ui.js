neemo = neemo || {};

neemo.ui = (function ($, broadcaster, svc, shoppingcart, lineItem) {

    var ui = {};
    
    ui.queryManager = (function (querystring) {
        var q = this;
        q.originalQuery = querystring;
        q.newQuery = querystring;
        q.items = querystring.replace('?', '').split('&');

        function addOrUpdate(keyPair, go) {
            var self = this;
            self.keyPair = keyPair;
            self.exists = false;

            // Locate the item and update it
            $.each(q.items, function (idx, val) {
                if (val.startsWith(self.keyPair.key + '=')) {
                    q.items[idx] = self.keyPair.key + '=' + self.keyPair.newVal;
                    self.exists = true;
                }
            });

            if (!self.exists) {
                q.items.push(keyPair.key + '=' + keyPair.newVal);
            }

            // Update the query 
            q.newQuery = '?' + q.items.join('&');
            if (go) {
                goWithNewQuery();
            }
            return q;
        }

        function goWithNewQuery() {
            window.location.href = q.newQuery;
        }

        function remove(key) {
            self.key = key;
            self.index = null;
            $.each(q.items, function (idx, val) {
                if (val.startsWith(self.key + '=')) {
                    self.index = idx;
                }
            });
            if (self.index != null) {
                q.items.splice(self.index, 1);
            }
        }

        return {
            addOrUpdate: addOrUpdate,
            goWithNewQuery: goWithNewQuery,
            remove : remove
        }
    })(window.location.search);

    var searchFilters = {
        // Manages the query string parameters for the search page
        // Note: the key must match the FindModelView properties (filters)
        setPageNumber: function(pageNumber) {
            ui.queryManager.addOrUpdate({ key: 'page', newVal: pageNumber }, true);
        },
        setPageSize : function(pageSize) {
            ui.queryManager.remove('page');
            ui.queryManager.addOrUpdate({ key: 'pageSize', newVal: pageSize }, true);
        }
    };

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
                ui.cart.items.push(new lineItem(item));
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
        searchFilters.setPageNumber($(this).text());
    });

    $('[data-page-size').on('change', function () {
        searchFilters.setPageSize($(this).val());
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