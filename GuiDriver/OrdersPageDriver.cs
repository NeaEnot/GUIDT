using Core.Models.View;
using System.Collections.Generic;

namespace GuiDriver
{
    public class OrdersPageDriver
    {
        public delegate void moveToOrderPage(GuiContext context, OrderView order);
        public moveToOrderPage MoveToOrderPage { private get; set; }

        public delegate OrderView selected();
        public selected Selected { get; set; }

        private GuiContext context;

        public OrdersPageDriver(GuiContext context)
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
