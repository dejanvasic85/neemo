using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                
                // Hard code the db order here ( for the moment )
                dbOrder.OrderStatusID = 1;

                context.OrderHeaders.Add(dbOrder);

                context.SaveChanges();

                // Map the Id's back
                order.OrderId = dbOrder.OrderHeaderID;
            }
        }

        public IEnumerable<Order> GetOrdersForUser(string username)
        {
            using (var context = DbContextFactory.Create())
            {
                var dbOrders = context.OrderHeaders
                    .Where(o => o.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && o.Active)
                    .Include(o => o.OrderDetails)
                    .ToList();

                return dbOrders.Select(Mapper.Map<Models.OrderHeader, Orders.Order>);
            }
        }

        public Order GetOrder(int? orderId)
        {
            using (var context = DbContextFactory.Create())
            {
                var dbOrder = context.OrderHeaders
                    .Where(o => o.OrderHeaderID == orderId && o.Active == true)
                    .Include(o => o.OrderDetails)
                    .FirstOrDefault();

                if (dbOrder == null)
                {
                    return null;
                }
                
                return Mapper.Map<Models.OrderHeader, Orders.Order>(dbOrder);
            }
        }
    }
}