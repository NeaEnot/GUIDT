using Core.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UiDriver
{
    public class OrderProductPageDriver: PageDriver
    {
        #region сustomizableMethods
        public Func<ProductView> SelectedProduct { private get; set; }
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
            try
            {
                if (Count() <= 0)
                {
                    throw new Exception("Invalid value");
                }

                return SelectedProduct().Price * Count();
            }
            catch (Exception ex)
            {
                return 0;
            }
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

        public bool SaveOrderProduct()
        {
            try
            {
                if (SelectedProduct() == null)
                {
                    throw new Exception("Product is not selected");
                }
                if (Count() <= 0)
                {
                    throw new Exception("Invalid value");
                }

                orderProduct.ProductId = SelectedProduct().Id;
                orderProduct.ProductName = SelectedProduct().Name;
                orderProduct.Price = SelectedProduct().Price;
                orderProduct.Count = Count();

                if (orderProduct.Id < 0)
                {
                    order.OrderProducts.Add(orderProduct);
                }

                return true;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
                return false;
            }
        }
    }
}
