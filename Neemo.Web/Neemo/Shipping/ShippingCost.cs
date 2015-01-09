namespace Neemo.Shipping
{
    public class ShippingCost
    {
        public ShippingCost(decimal cost, ShippingType type)
        {
            this.ShippingType = type;
            this.Cost = cost;
        }

        public ShippingType ShippingType { get; private set; }
        public decimal Cost { get; private set; }
    }
}