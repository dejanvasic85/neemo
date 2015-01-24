using System.Collections.Generic;

namespace Neemo.Orders
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        IEnumerable<Order> GetOrdersForUser(string username);
    }
}