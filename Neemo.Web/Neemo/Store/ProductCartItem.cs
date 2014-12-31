namespace Neemo.Store
{
    using ShoppingCart;

    public class ProductCartItem : ICartItem
    {
        private readonly Product _product;
        public int Quantity { get; private set; }
        public int Id { get; private set; }

        public ProductCartItem(Product product, int quantity)
        {
            if(product==null)
                throw new CartException("Product cannot be null when adding to the shopping cart");

            if (quantity <= 0)
                throw new CartException("Quantity must be greater than zero when adding to the shopping cart");

            this.Quantity = quantity;
            this.Id = product.ProductId;
            this._product = product;
        }

        public decimal CalculatePrice()
        {
            // Consider discounts later
            return _product.Price * Quantity;
        }
    }
}