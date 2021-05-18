using Core.Models.Binding;
using Core.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UiDriver
{
    public class OrderPageDriver: PageDriver
    {
        #region сustomizableMethods
        public Action<UiContext, OrderView, OrderProductView> MoveToOrderProductPage { private get; set; }
        public Func<OrderProductView> Selected { private get; set; }
        #endregion

        public OrderView order;

        public OrderPageDriver(UiContext context, OrderView order)
        {
            this.context = context;
            this.order = order ?? new OrderView { Id = -1 };
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
            MoveToOrderProductPage(context, order, null);
        }

        public void UpdateOrderProduct()
        {
            try
            {
                MoveToOrderProductPage(context, order, Selected());
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        public void SaveOrder()
        {
            OrderBinding model =
                new OrderBinding
                {
                    Id = order.Id,
                    OrderProducts =
                        order.OrderProducts
                        .Select(rec =>
                        new OrderProductBinding
                        {
                            ProductId = rec.ProductId,
                            Count = rec.Count
                        })
                        .ToList()
                };

            if (order.Id < 0)
            {
                context.OrderLogic.Create(model);
                ShowInfoMessage("Order was created");
            }
            else
            {
                context.OrderLogic.Update(model);
                ShowInfoMessage("Order №" + model.Id + " was updated");
            }
        }
    }
}
