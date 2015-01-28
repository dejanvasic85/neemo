using System.Collections;
using System.Collections.Generic;
using Neemo.ShoppingCart;

namespace Neemo.Orders
{
    public interface IOrderService
    {
        Order CreateOrder(ShoppingCart.Cart cart);
        IEnumerable<Order> GetOrdersForUser(string username);
        Order GetOrder(int? orderId);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order CreateOrder(Cart cart)
        {
            // Create new order from shopping cart
            var order = Order.FromShoppingCart(cart);

            _orderRepository.CreateOrder(order);

            return order;
        }

        public IEnumerable<Order> GetOrdersForUser(string username)
        {
            return _orderRepository.GetOrdersForUser(username);
        }

        public Order GetOrder(int? orderId)
        {
            Guard.NotNull(orderId);

            return _orderRepository.GetOrder(orderId);
        }
    }
}