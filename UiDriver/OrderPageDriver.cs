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
        public Func<OrderProductView> SelectedOrderProduct { private get; set; }
        #endregion

        private OrderView order;

        public OrderPageDriver(UiContext context, OrderView order) : base(context)
        {
            this.order = order ?? new OrderView { Id = -1 };
        }

        public List<OrderProductView> GetAllOrderProducts()
        {
            return order.OrderProducts.ToList();
        }

        public void DeleteOrderProduct()
        {
            try
            {
                OrderProductView op = SelectedOrderProduct();
                order.OrderProducts.Remove(op);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        public void AddOrderProduct()
        {
            try
            {
                MoveToOrderProductPage(context, order, null);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        public void UpdateOrderProduct()
        {
            try
            {
                MoveToOrderProductPage(context, order, SelectedOrderProduct());
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        public bool SaveOrder()
        {
            try
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

                if (model.OrderProducts.Count <= 0)
                {
                    throw new Exception("List of products is empty");
                }

                if (order.Id < 0)
                {
                    context.OrderLogic.Create(model);
                    ShowInfoMessage("Order was created");
                    return true;
                }
                else
                {
                    context.OrderLogic.Update(model);
                    ShowInfoMessage("Order №" + model.Id + " was updated");
                    return true;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
                return false;
            }
        }
    }
}
