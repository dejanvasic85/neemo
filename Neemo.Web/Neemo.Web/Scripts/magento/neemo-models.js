neemo = neemo || {};

(function ($, accounting) {
    
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
        me.totalQuantity = function() {
            var total = 0;
            $.each(this.items(), function () {
                total += this.Quantity;
            });
            return total;
        };
    };

})(jQuery, accounting);