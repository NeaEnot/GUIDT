using Core.Models.View;
using System;
using System.Collections.Generic;

namespace UiDriver
{
    public class ProductsPageDriver : PageDriver
    {
        #region сustomizableMethods
        public Func<ProductView> Selected { get; set; }
        #endregion

        public ProductsPageDriver(UiContext context) : base(context)
        { }

        public List<ProductView> GetAllProducts()
        {
            return context.ProductLogic.Read(null);
        }
    }
}
