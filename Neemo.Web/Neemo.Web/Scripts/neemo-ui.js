var neemo = neemo || {};

neemo.ui = (function ($, broadcaster, svc, shoppingcart, lineItem) {

    var ui = {};

    ui.queryManager = (function (querystring) {

        // Create local variable to manage the query string
        var q = {
            originalQuery: querystring,
            newQuery: querystring,
            targetUrl: window.location.pathname,
            items: getCurrentItems()
        };

        function getCurrentItems() {
            if (querystring === '') {
                return [];
            }
            return querystring.replace('?', '').split('&');
        }

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
                if (val) {
                    if (val.startsWith(self.keyPair.key + '=')) {
                        if (self.keyPair.newVal === '') {
                            remove(self.keyPair.key);
                        } else {
                            q.items[idx] = self.keyPair.key + '=' + self.keyPair.newVal;
                        }
                        self.exists = true;
                    }
                }
            });

            if (!self.exists && keyPair.newVal !== '') {
                q.items.push(keyPair.key + '=' + keyPair.newVal);
            }

            // Update the query 
            q.newQuery = q.items.join('&');
            if (go) {
                goWithNewQuery();
            } return q;
        }

        function goWithNewQuery() {
            window.location.search = q.newQuery;
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
        setFilter: function (filter, val) {
            ui.queryManager.addOrUpdate({ key: filter, newVal: val }, false);
            return searchFilters;
        },
        clearFilter: function (key) {
            ui.queryManager.addOrUpdate({ key: key, newVal: '' }, true);
            return searchFilters;
        },
        apply: function () {
            ui.queryManager.goWithNewQuery();
            return searchFilters;
        }
    };

    $('.btn-cart').on('click', function () {
        var me = $(this).attr('data-loading-text', 'Please wait...').button('loading');
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
                me.button('reset');
            },
            function () {
                broadcaster.error('Not enough items in stock for your request.');
                me.button('reset');
            },
            function () {
                broadcaster.error('Item is no longer available.');
                me.button('reset');
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
        searchFilters.setPageNumber($(this).attr('data-page-num'));
    });

    $('#checkoutAsGuest').on('click', function () {
        $('#checkoutForm').submit();
    });

    $('[data-page-size').on('change', function () {
        searchFilters.setPageSize($(this).val());
    });

    $('[data-apply-filters]').on('click', function () {
        var $filterContainer = $(this).closest('.product-filters');

        var filter = searchFilters
            .setKeyword($filterContainer.find('#Keyword').val())
            .setSortBy($filterContainer.find('#SortBy').val())
            .setPriceMin($filterContainer.find('#PriceMin').val())
            .setPriceMax($filterContainer.find('#PriceMax').val());

        $filterContainer.find('[data-search-filter]').each(function (index, item) {
            var sf = $(this).data().searchFilter;
            var value = $(this).val();
            filter.setFilter(sf, value);
        });

        $(this).button('loading');

        filter.apply();
    });

    $('[data-apply-provider-filters]').on('click', function () {
        var $filterContainer = $(this).closest('.product-filters');

        var filter = searchFilters
            .setKeyword($filterContainer.find('#Keyword').val())
            .setSortBy($filterContainer.find('#SortBy').val());

        $filterContainer.find('[data-search-filter]').each(function (index, item) {
            var sf = $(this).data().searchFilter;
            var value = $(this).val();
            filter.setFilter(sf, value);
        });

        $(this).button('loading');
        filter.apply();
    });

    // Changing the category is not a regular filter
    // Todo - It needs ability to reset the existing filters!
    $('[data-category-filter]').on('click', function () {
        searchFilters.setCategory($(this).attr('data-category-filter'));
    });

    // Load all the search filters
    $('[data-select-filter]').each(function () {
        var me = $(this);
        var selected = me.data().selectFilter;
        me.attr('disabled', 'disabled');
        me.append('<option>Loading...</option>');
        var url = me.data().url;
        $.getJSON(url).done(function (data) {
            me.empty().append("<option value=''>-- Any --</option>");
            $.each(data, function (index, option) {
                if (selected == option.Value) {
                    me.append('<option selected value="' + option.Value + '">' + option.Text + '</option>');
                } else {
                    me.append('<option value="' + option.Value + '">' + option.Text + '</option>');
                }
            });
            me.removeAttr('disabled');
        });
    });

    $('[remove-filter]').on('click', function () {
        searchFilters.clearFilter($(this).attr('remove-filter'));
    });

    $('#getShippingEstimate').button();

    $('#getShippingEstimate').on('click', function () {
        var $btn = $(this);
        $btn.button('loading');
        svc.calculateEstimate($('#postcode').val(), function (data) {
            var $estimates = $('#estimates');
            var $tbody = $estimates.find('tbody');
            $tbody.empty();
            $.each(data, function (index, item) {
                $tbody.append('<tr><td>' + item.ShippingType + '</td><td>' + accounting.formatMoney(item.Cost) + '</td></tr>');
            });
            $btn.button('reset');
            $estimates.slideDown();
        });
    });

    $('#getShippingEstimateForProduct').on('click', function () {
        var $btn = $(this);
        $btn.button('loading');
        svc.calculateEstimateForProduct($btn.data().productid, $('#postcode').val(), function (data) {
            var $estimates = $('#estimates');
            var $tbody = $estimates.find('tbody');
            $tbody.empty();
            $.each(data, function (index, item) {
                $tbody.append('<tr><td>' + item.ShippingType + '</td><td>' + accounting.formatMoney(item.Cost) + '</td></tr>');
            });
            $btn.button('reset');
            $estimates.slideDown();
        });
    });

    $('[data-show-orders]').on('click', function () {
        var $btn = $(this);
        if ($btn.text().indexOf('Hide') > -1) {
            $btn.closest('tr').next().hide();
            $btn.html('View <i class="fa fa-chevron-down"></i>');
        } else {
            $btn.closest('tr').next().show();
            $btn.html('Hide <i class="fa fa-chevron-up"></i>');
        }
        return false;
    });

    // Button - please wait
    $('form').find('button[type=submit]').attr('data-loading-text', 'Please wait...');
    $('form').submit(function () {
        $(this).find('button[type=submit]').button('loading');
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

    /*
     * Advanced search
     */
    $('#advancedSearchBtn').on('click', function () {
        $('#advancedSearch').slideDown(2000);
        $(this).hide();
    });

    /*
     * Google Maps
     */
    $('.provider-map').each(function () {

        var $me = $(this);

        var latitude = $me.data().latitude,
            longitude = $me.data().longitude,
            address = $me.data().providerAddress;

        var mapCanvas = $(this).get(0);

        function initialize() {
            var latLng = new google.maps.LatLng(latitude, longitude);
            var mapOptions = {
                center: latLng,
                zoom: 16,
                mapTypeId: google.maps.MapTypeId.ROADMAP,
                scrollwheel: false
            };
            var map = new google.maps.Map(mapCanvas, mapOptions);

            var marker = new google.maps.Marker({
                position: latLng,
                title: address,
                visible: true
            });
            marker.setMap(map);
        }

        initialize();
    });

    return ui;

})(jQuery, toastr, neemo.svc, neemo.shoppingCart, neemo.lineItem);