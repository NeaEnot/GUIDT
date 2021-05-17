using Core.Models.View;
using System;
using System.Collections.Generic;

namespace UiDriver
{
    public class OrderPageDriver
    {
        public Func<OrderProductView> Selected { get; set; }

        public OrderView order;

        public OrderPageDriver(UiContext context, OrderView order)
        {
            this.order = order;
        }

        public List<OrderProductView> GetAllOrderProducts()
        {
            return order.OrderProducts;
        }

        public void DeleteOrderProduct()
        {
            order.OrderProducts.Remove(Selected());
        }
    }
}
