using Core.Models.View;
using System;
using System.Collections.Generic;

namespace UiDriver
{
    public class OrderProductPageDriver: PageDriver
    {
        #region сustomizableMethods
        public Func<ProductView> Selected { get; set; }
        #endregion

        public OrderProductPageDriver(UiContext context, OrderView order, OrderProductView orderProduct) : base(context)
        {
        }

        public List<ProductView> GetAllProducts()
        {
            return context.ProductLogic.Read(null);
        }
    }
}
