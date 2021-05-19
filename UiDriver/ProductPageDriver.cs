using Core.Models.Binding;
using Core.Models.View;
using System;

namespace UiDriver
{
    public class ProductPageDriver : PageDriver
    {
        #region сustomizableMethods
        public Func<string> ProductName { get; set; }
        public Func<int> ProductPrice { get; set; }
        #endregion

        public ProductPageDriver(UiContext context, ProductView product) : base(context)
        {

        }

        public void Save()
        {
            context.ProductLogic.Create(
                new ProductBinding
                {
                    Name = ProductName(),
                    Price = ProductPrice()
                });
        }
    }
}
