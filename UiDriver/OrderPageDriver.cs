using Core.Models.View;
using System;
using System.Collections.Generic;

namespace UiDriver
{
    public class OrderPageDriver
    {
        #region сustomizableMethods
        public Action<UiContext, OrderProductView> MoveToOrderProductPage { private get; set; }
        public Func<OrderProductView> Selected { get; set; }
        #endregion

        public OrderView order;
        private UiContext context;

        public OrderPageDriver(UiContext context, OrderView order)
        {
            this.context = context;
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

        public void AddOrderProduct()
        {
            MoveToOrderProductPage(context, null);
        }

        public void UpdateOrderProduct()
        {
            MoveToOrderProductPage(context, Selected());
        }
    }
}
