﻿using Core.Models.View;
using System;
using System.Collections.Generic;

namespace UiDriver
{
    public class OrderPageDriver: PageDriver
    {
        #region сustomizableMethods
        public Action<UiContext, OrderProductView> MoveToOrderProductPage { private get; set; }
        public Func<OrderProductView> Selected { private get; set; }
        #endregion

        public OrderView order;

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
            try
            {
                OrderProductView op = Selected();
                order.OrderProducts.Remove(op);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        public void AddOrderProduct()
        {
            MoveToOrderProductPage(context, null);
        }

        public void UpdateOrderProduct()
        {
            try
            {
                MoveToOrderProductPage(context, Selected());
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
    }
}
