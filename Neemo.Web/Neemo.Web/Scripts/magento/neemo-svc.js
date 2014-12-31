﻿neemo = neemo || {};
neemo.svc = (function ($, urls) {

    function call(url, data, type) {
        type = type || 'POST';
        return $.ajax({
            url: url,
            type: type,
            data: JSON.stringify( data ),
            dataType: 'json',
            contentType: 'application/json'
        });
    }
    
    return {
        addProduct: function (productId, qty, successFnc, noStockFnc, qtyTooLargeFnc) {
            call(urls.addProduct, { productId: productId, qty: qty })
                .done(function(response) {
                    if (response.Added) {
                        successFnc();
                    }
                    if (response.NotAvailable) {
                        noStockFnc();
                    }
                    if (response.QuantityTooLarge) {
                        qtyTooLargeFnc();
                    }
                });
        },
        getItems : function() {
            call(urls.getItems, null, 'GET').done(function (items) {
                debugger;
                return items;
            });
        }
    }
})(jQuery, neemo.endpoints.cart);