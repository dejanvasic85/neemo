neemo = neemo || {};

(function ($, accounting) {

    neemo.lineItem = function (cartViewItem) {
        var me = this;

        me.Id = ko.observable(cartViewItem.Id);
        me.LineItemId = ko.observable(cartViewItem.LineItemId);
        me.Title = ko.observable(cartViewItem.Title);
        me.Price = ko.observable(cartViewItem.Price);
        me.Quantity = ko.observable(cartViewItem.Quantity);
        me.ImageId = ko.observable(cartViewItem.ImageId);

        me.Total = function () {
            return me.Price() * me.Quantity();
        }
    };

    neemo.shoppingCart = function (items) {
        var me = this;
        me.items = ko.observableArray(items);
        me.subTotal = function () {
            var total = 0;
            $.each(this.items(), function () {
                total += (this.Price() * this.Quantity());
            });
            return accounting.formatMoney(total);
        };

        me.totalQuantity = function () {
            var total = 0;
            $.each(this.items(), function () {
                total += parseInt( this.Quantity() );
            });
            return total;
        };

        me.removeItem = function (item) {
            me.items.remove(item);
            neemo.svc.removeProduct(item.LineItemId());
        };
    };

})(jQuery, accounting);