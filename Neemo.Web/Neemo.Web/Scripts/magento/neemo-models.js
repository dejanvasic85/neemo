neemo = neemo || {};

neemo.lineItem = function (id, qty) {
    var me = this;
    me.id = ko.observable(id);
    me.qty = ko.observable(qty);
};

neemo.shoppingCart = function (items) {
    var me = this;
    me.items = ko.observableArray(items);
};