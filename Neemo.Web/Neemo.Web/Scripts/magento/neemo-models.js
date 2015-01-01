neemo = neemo || {};

(function ($, accounting, cartSvc, broadcaster) {

    neemo.lineItem = function (cartViewItem) {
        var me = this;

        // Todo - make these properties lowercase (like other js conventions)
        me.Id = ko.observable(cartViewItem.Id);
        me.LineItemId = ko.observable(cartViewItem.LineItemId);
        me.Title = ko.observable(cartViewItem.Title);
        me.Price = ko.observable(cartViewItem.Price);
        me.Quantity = ko.observable(cartViewItem.Quantity).extend({numeric: 0});
        me.ImageId = ko.observable(cartViewItem.ImageId);

        me.Total = function () {
            return me.Price() * me.Quantity();
        }

        me.Quantity.subscribe(function (newValue) {
            cartSvc.updateQuantity(me.LineItemId(), me.Id(), newValue, function() {
                broadcaster.success('Your quantity was updated.');
            }, function() {
                broadcaster.error('Not enough items in stock for your request.');
            });
        });
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
                total += parseInt(this.Quantity());
            });
            return total;
        };

        me.removeItem = function (item) {
            me.items.remove(item);
            cartSvc.removeProduct(item.LineItemId());
        };
    };

})(jQuery, accounting, neemo.svc, toastr);