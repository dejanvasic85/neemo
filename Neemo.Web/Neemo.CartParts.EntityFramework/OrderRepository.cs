using AutoMapper;
using Neemo.Orders;

namespace Neemo.CarParts.EntityFramework
{
    public class OrderRepository : IOrderRepository
    {
        public void CreateOrder(Order order)
        {
            using (var context = DbContextFactory.Create())
            {
                var dbOrder = Mapper.Map<Orders.Order, Models.OrderHeader>(order);

                context.OrderHeaders.Add(dbOrder);

                context.SaveChanges();
            }
        }
    }
}