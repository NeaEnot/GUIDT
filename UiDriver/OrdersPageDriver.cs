using Core.Models.Binding;
using Core.Models.View;
using System.Collections.Generic;

namespace UiDriver
{
    public class OrdersPageDriver
    {
        #region delegates
        public delegate void moveToOrderPage(UiContext context, OrderView order);
        public delegate OrderView selected();
        #endregion

        #region сustomizableMethods
        public moveToOrderPage MoveToOrderPage { private get; set; }
        public selected Selected { get; set; }
        #endregion

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

        public void DeleteOrder()
        {
            context.OrderLogic.Delete(new OrderBinding { Id = Selected().Id });
        }
    }
}
