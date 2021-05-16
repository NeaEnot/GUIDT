using Core.Models.Binding;
using Core.Models.View;
using System;
using System.Collections.Generic;

namespace UiDriver
{
    public class OrdersPageDriver
    {
        #region сustomizableMethods
        /// <summary>
        /// Тут необходимо указать, например, функцию открытия нового окна
        /// </summary>
        public Action<UiContext, OrderView> MoveToOrderPage { private get; set; }
        /// <summary>
        /// Тут необходимо указать, например, функцию открытия нового окна
        /// </summary>
        public Action MoveToProductsPage { private get; set; }
        public Func<OrderView> Selected { private get; set; }
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

        public void UpdateOrder()
        {
            MoveToOrderPage(context, Selected());
        }

        public void DeleteOrder()
        {
            context.OrderLogic.Delete(new OrderBinding { Id = Selected().Id });
        }

        public void ToProducts()
        {
            MoveToProductsPage();
        }
    }
}
