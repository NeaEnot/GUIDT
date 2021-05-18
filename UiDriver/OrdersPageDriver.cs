using Core.Models.Binding;
using Core.Models.View;
using System;
using System.Collections.Generic;

namespace UiDriver
{
    public class OrdersPageDriver: PageDriver
    {
        #region сustomizableMethods
        public Action<UiContext, OrderView> MoveToOrderPage { private get; set; }
        public Action MoveToProductsPage { private get; set; }
        public Func<OrderView> Selected { private get; set; }
        #endregion

        public OrdersPageDriver(UiContext context)
        {
            this.context = context;
        }

        public List<OrderView> GetAllOrders()
        {
            List<OrderView> list = new List<OrderView>();

            try
            {
                list = context.OrderLogic.Read(null);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }

            return list;
        }

        public void AddOrder()
        {
            MoveToOrderPage(context, null);
        }

        public void UpdateOrder()
        {
            try
            {
                MoveToOrderPage(context, Selected());
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        public void DeleteOrder()
        {
            try
            {
                int id = Selected().Id;
                context.OrderLogic.Delete(new OrderBinding { Id = id });
                ShowInfoMessage("Order №" + id + " was deleted");
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        public void ToProducts()
        {
            MoveToProductsPage();
        }
    }
}
