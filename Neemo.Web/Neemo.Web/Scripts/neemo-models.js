var neemo = neemo || {};

(function ($, accounting, cartSvc, broadcaster, endpoint) {

    neemo.lineItem = function (cartViewItem) {
        var me = this;

        // Todo - make these properties lowercase (like other js conventions)
        me.Id = ko.observable(cartViewItem.Id);
        me.LineItemId = ko.observable(cartViewItem.LineItemId);
        me.Title = ko.observable(cartViewItem.Title);
        me.Price = ko.observable(cartViewItem.Price);
        me.Quantity = ko.observable(cartViewItem.Quantity).extend({ numeric: 0 });
        me.ImageFileName = cartViewItem.ImageId;
        me.ImageUrl = ko.computed(function () {
            return endpoint.img.get(me.ImageFileName);
        });
        me.PriceWithoutTax = ko.computed(function () {
            return me.Price() * 0.9;
        });

        me.Total = function () {
            return me.Price() * me.Quantity();
        };
        me.TotalWithoutTax = function () {
            return me.PriceWithoutTax() * me.Quantity();
        };

        me.Quantity.subscribeChanged(function (newValue, oldValue) {
            var meFnc = this;
            meFnc.newValue = newValue;
            meFnc.oldValue = oldValue;
            cartSvc.updateQuantity(me.LineItemId(), me.Id(), newValue, function () {
                broadcaster.success('Your quantity was updated.');
            }, function () {
                broadcaster.error('Not enough items in stock for your request.');
                return false;
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
            return total;
        };
        me.subTotalWithoutTax = function () {
            return me.subTotal() * 0.9;
        };

        me.totalQuantity = function () {
            var total = 0;
            $.each(this.items(), function () {
                total += parseInt(this.Quantity());
            });
            return total;
        };

        me.tax = ko.computed(function () {
            return me.subTotal() * 0.1;
        });

        me.grandTotal = ko.computed(function () {
            return me.subTotal() + me.tax();
        });

        me.grandTotalWithoutTax = ko.computed(function () {
            return me.grandTotal() - me.tax();
        });

        me.removeItem = function (item) {
            if (confirm('Are you sure you want to remove the order from the shopping cart?')) {
                cartSvc.removeProduct(item.LineItemId())
                    .then(me.items.remove(item));
            }
        };

        me.clearAllItems = function () {
            if (confirm('Are you sure you want to clear all items?')) {
                $.each(this.items(), function (index, targetItem) {
                    cartSvc.removeProduct(targetItem.LineItemId());
                });
                this.items.removeAll();
            }
        }
    };

})(jQuery, accounting, neemo.svc, toastr, neemo.endpoints);