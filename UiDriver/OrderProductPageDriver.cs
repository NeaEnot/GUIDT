using Core.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UiDriver
{
    public class OrderProductPageDriver: PageDriver
    {
        #region сustomizableMethods
        public Func<ProductView> Selected { private get; set; }
        public Func<int> Count { private get; set; }
        #endregion

        private OrderView order;
        private OrderProductView orderProduct;

        public OrderProductPageDriver(UiContext context, OrderView order, OrderProductView orderProduct) : base(context)
        {
            this.order = order;
            this.orderProduct = orderProduct ?? new OrderProductView { Id = -1 };
        }

        public List<ProductView> GetAllProducts()
        {
            return context.ProductLogic.Read(null);
        }

        public int GetSum()
        {
            return Selected().Price * Count();
        }

        public ProductView GetSelectedProduct()
        {
            if (orderProduct.Id < 0)
            {
                return null;
            }
            else
            {
                return context.ProductLogic.Read(null).FirstOrDefault(rec => rec.Id == orderProduct.ProductId);
            }
        }

        public void SaveOrderProduct()
        {
            try
            {
                if (Selected() == null)
                {
                    throw new Exception("Product is not selected");
                }

                orderProduct.ProductId = Selected().Id;
                orderProduct.ProductName = Selected().Name;
                orderProduct.Price = Selected().Price;
                orderProduct.Count = Count();

                if (orderProduct.Id < 0)
                {
                    order.OrderProducts.Add(orderProduct);
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
    }
}
