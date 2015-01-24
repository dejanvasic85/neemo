using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Order> GetOrdersForUser(string username)
        {
            using (var context = DbContextFactory.Create())
            {
                var dbOrders = context.OrderHeaders
                    .Where(o => o.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && o.Active)
                    .ToList();

                return dbOrders.Select(Mapper.Map<Models.OrderHeader, Orders.Order>);
            }
        }
    }
}