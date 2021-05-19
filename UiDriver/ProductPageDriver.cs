using Core.Models.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace UiDriver
{
    public class ProductPageDriver : PageDriver
    {
        #region сustomizableMethods
        public Func<string> ProductName { get; set; }
        #endregion

        public ProductPageDriver(UiContext context, ProductView product) : base(context)
        {

        }
    }
}
