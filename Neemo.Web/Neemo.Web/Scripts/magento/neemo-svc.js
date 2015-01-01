neemo = neemo || {};
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
            return call(urls.getItems, null, 'GET');
        }
    }
})(jQuery, neemo.endpoints.cart);