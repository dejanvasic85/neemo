namespace Neemo.Orders
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}