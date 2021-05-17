using Core.Models.View;
using System.Collections.Generic;

namespace UiDriver
{
    public class OrderPageDriver
    {
        public OrderView order;

        public OrderPageDriver(UiContext context, OrderView order)
        {
            this.order = order;
        }

        public List<OrderProductView> GetAllOrderProducts()
        {
            return order.OrderProducts;
        }
    }
}
