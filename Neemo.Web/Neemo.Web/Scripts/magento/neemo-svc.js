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
        addProduct: function (productId, qty, successFnc, qtyTooLargeFnc) {
            call(urls.addProduct, { productId: productId, qty: qty })
                .done(function (response) {
                    if (response.Added) {
                        successFnc(response.Item);
                    }
                    if (response.QuantityTooLarge) {
                        qtyTooLargeFnc();
                    }
                });
        },
        removeProduct: function(lineItemId) {
            call(urls.removeProduct, { lineItemId: lineItemId });
        },
        getItems: function () {
            return call(urls.getItems, null, 'GET');
        },
        updateQuantity: function (lineItemId, qty) {
            call(urls.updateQuantity, {lineItemId : lineItemId, quantity : qty });
        }
    }
})(jQuery, neemo.endpoints.cart);