using Neemo.ShoppingCart;

namespace Neemo.Orders
{
    public interface IOrderService
    {
        Order CreateOrder(ShoppingCart.Cart cart);
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
    }
}