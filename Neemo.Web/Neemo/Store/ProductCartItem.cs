namespace Neemo.Store
{
    using System;
    using ShoppingCart;
    using Tax;

    public class ProductCartItem : ICartItem
    {
        private readonly Product _product;

        public int Quantity { get; private set; }
        public string LineItemId { get; private set; }
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string ImageId { get; private set; }
        public decimal Price { get; private set; }

        public decimal PriceWithoutTax
        {
            get { return Price - CalculateTaxPerItem(); }
        }

        public ProductCartItem(Product product, int quantity)
        {
            if (product == null)
                throw new CartException("Product cannot be null when adding to the shopping cart");

            if (quantity <= 0)
                throw new CartException("Quantity must be greater than zero when adding to the shopping cart");

            Quantity = quantity;
            Id = product.ProductId;
            Title = product.Title;
            ImageId = product.ImageId;
            Price = product.Price;
            LineItemId = Guid.NewGuid().ToString();

            _product = product;
        }

        public TaxCost CalculateTaxPerItem()
        {
            var taxService = new GstTaxCalculator(new SysConfig());
            return taxService.CalculateForAmountIncludingTax(this.Price);
        }

        public decimal CalculateSubTotal()
        {
            return _product.Price * Quantity;
        }

        public decimal CalculateSubTotalWithoutTax()
        {
            return PriceWithoutTax * Quantity;
        }

        public TaxCost CalculateTotalTax()
        {
            return CalculateTaxPerItem() * Quantity;
        }

        public void UpdateQuantity(int qty)
        {
            this.Quantity = qty;
        }
    }
}