neemo = neemo || {};

neemo.ui = (function ($, broadcaster, svc, shoppingcart, lineItem) {

    var ui = {};

    ui.queryManager = (function (querystring) {
        var q = this;
        q.originalQuery = querystring;
        q.newQuery = querystring;
        q.targetUrl = window.location.pathname;
        q.items = querystring.replace('?', '').split('&');

        function addOrUpdate(keyPair, go, ensureUrl) {
            var self = this;
            self.keyPair = keyPair;
            self.exists = false;

            // Clear if different from ensure url
            if (q.targetUrl !== ensureUrl && ensureUrl !== undefined) {
                q.targetUrl = ensureUrl;
            }

            // Locate the item and update it
            $.each(q.items, function (idx, val) {
                if (val.startsWith(self.keyPair.key + '=')) {
                    if (self.keyPair.newVal === '') {
                        remove(self.keyPair.key);
                    } else {
                        q.items[idx] = self.keyPair.key + '=' + self.keyPair.newVal;
                    }
                    self.exists = true;
                }
            });

            if (!self.exists && keyPair.newVal !== '') {
                q.items.push(keyPair.key + '=' + keyPair.newVal);
            }

            // Update the query 
            q.newQuery = '?' + q.items.join('&');
            if (go) {
                goWithNewQuery();
            } return q;
        }

        function goWithNewQuery() {
            window.location = q.targetUrl + q.newQuery;
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
            remove: remove
        }
    })(window.location.search);

    var searchFilters = {
        // Manages the query string parameters for the search page
        // Note: the key must match the FindModelView properties (filters)
        setPageNumber: function (pageNumber) {
            ui.queryManager.addOrUpdate({ key: 'page', newVal: pageNumber }, true);
        },
        setPageSize: function (pageSize) {
            ui.queryManager.remove('page'); // When updating size, we need to remove page number
            ui.queryManager.addOrUpdate({ key: 'pageSize', newVal: pageSize }, true);
        },
        setCategory: function (categoryId) {
            ui.queryManager.addOrUpdate({ key: 'categoryId', newVal: categoryId }, true, neemo.endpoints.product.search);
        },
        setKeyword: function (keyword) {
            ui.queryManager.addOrUpdate({ key: 'keyword', newVal: keyword }, false);
            return searchFilters; // Allow chaining
        },
        setSortBy: function (sortBy) {
            if (sortBy === 'NewestFirst') {
                ui.queryManager.remove('sortBy');
                return searchFilters;
            }
            ui.queryManager.addOrUpdate({ key: 'sortBy', newVal: sortBy }, false);
            return searchFilters;
        },
        setPriceMin: function (priceMin) {
            ui.queryManager.addOrUpdate({ key: 'priceMin', newVal: priceMin }, false);
            return searchFilters;
        },
        setPriceMax: function (priceMax) {
            ui.queryManager.addOrUpdate({ key: 'priceMax', newVal: priceMax }, false);
            return searchFilters;
        },
        apply: function () {
            ui.queryManager.goWithNewQuery();
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

    $('[data-apply-filters').on('click', function () {
        searchFilters
            .setKeyword($('#Keyword').val())
            .setSortBy($('#SortBy').val())
            .setPriceMin($('#PriceMin').val())
            .setPriceMax($('#PriceMax').val())
            .apply();
    });

    $('[data-category-filter]').on('click', function() {
        searchFilters.setCategory($(this).attr('data-category-filter'));
    });

    $('#getShippingEstimate').on('click', function() {
        
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