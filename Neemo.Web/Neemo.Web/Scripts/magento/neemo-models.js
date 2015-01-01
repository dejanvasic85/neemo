neemo = neemo || {};

(function ($, accounting) {

    //neemo.lineItem = function(id, price, qty, title, imageId) {
    //    var me = this;
    //    me.id = ko.observable(id);
    //    me.qty = ko.observable(qty);
    //    me.title = ko.observable(title);
    //    me.imageId = ko.observable(imageId);

    //    me.subTotal = function() {
            
    //    }
    //};

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
    };

})(jQuery, accounting);