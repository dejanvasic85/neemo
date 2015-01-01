neemo = neemo || {};

(function ($, accounting) {

    neemo.lineItem = function (cartViewItem) {
        var me = this;

        me.productId = ko.observable(cartViewItem.ProductId);
        me.lineItemId = ko.observable(cartViewItem.LineItemId);
        me.title = ko.observable(cartViewItem.Title);
        me.price = ko.observable(cartViewItem.Price);
        me.qty = ko.observable(cartViewItem.Quantity);

        me.subTotal = function () {
            return me.price() * me.qty;
        }
    };

    neemo.shoppingCart = function (items) {
        var me = this;
        me.items = ko.observableArray(items);
        me.subTotal = function () {
            var total = 0;
            $.each(this.items(), function () {
                total += (this.Price * this.Quantity);
            });
            return accounting.formatMoney(total);
        };
        me.totalQuantity = function () {
            var total = 0;
            $.each(this.items(), function () {
                total += this.Quantity;
            });
            return total;
        };
        me.removeItem = function (item) {
            me.items.remove(item);
            neemo.svc.removeProduct(item.LineItemId);
        };
    };

})(jQuery, accounting);