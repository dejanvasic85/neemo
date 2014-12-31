neemo = neemo || {};
neemo.svc = (function ($, urls) {
    return {
        addProduct: function (productId, qty, successFnc, noStockFnc, qtyTooLargeFnc) {
            $.ajax({
                url: urls.addProduct,
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
})(jQuery, neemo.endpoints.cart);