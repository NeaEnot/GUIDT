using Core.Models.View;
using System;
using System.Collections.Generic;

namespace UiDriver
{
    public class OrderProductPageDriver: PageDriver
    {
        #region сustomizableMethods
        public Func<ProductView> Selected { private get; set; }
        public Func<int> Count { private get; set; }
        #endregion

        private OrderView order;

        public OrderProductPageDriver(UiContext context, OrderView order, OrderProductView orderProduct) : base(context)
        {
            this.order = order;
        }

        public List<ProductView> GetAllProducts()
        {
            return context.ProductLogic.Read(null);
        }

        public int GetSum()
        {
            return Selected().Price * Count();
        }

        public void SaveOrderProduct()
        {
            order.OrderProducts.Add(
                new OrderProductView
                {
                    ProductId = Selected().Id,
                    ProductName = Selected().Name,
                    Price = Selected().Price,
                    Count = Count()
                });
        }
    }
}
