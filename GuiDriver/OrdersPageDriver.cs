using Core.Models.View;
using System.Collections.Generic;

namespace GuiDriver
{
    public class OrdersPageDriver
    {
        private GuiContext context;

        public OrdersPageDriver(GuiContext context)
        {
            this.context = context;
        }

        public List<OrderView> GetAllOrders()
        {
            return context.OrderLogic.Read(null);
        }
    }
}
