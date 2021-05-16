using Core.Models.View;
using System.Collections.Generic;

namespace UiDriver
{
    public class OrdersPageDriver
    {
        public delegate void moveToOrderPage(UiContext context, OrderView order);
        public moveToOrderPage MoveToOrderPage { private get; set; }

        public delegate OrderView selected();
        public selected Selected { get; set; }

        private UiContext context;

        public OrdersPageDriver(UiContext context)
        {
            this.context = context;
        }

        public List<OrderView> GetAllOrders()
        {
            return context.OrderLogic.Read(null);
        }

        public void AddOrder()
        {
            MoveToOrderPage(context, null);
        }
    }
}
