using Core.Models.Binding;
using Core.Models.View;
using System;
using System.Collections.Generic;

namespace UiDriver
{
    public class ProductsPageDriver : PageDriver
    {
        #region сustomizableMethods
        public Action<UiContext, ProductView> MoveToProductPage { private get; set; }
        public Func<ProductView> Selected { private get; set; }
        #endregion

        public ProductsPageDriver(UiContext context) : base(context)
        { }

        public List<ProductView> GetAllProducts()
        {
            return context.ProductLogic.Read(null);
        }

        public void AddProduct()
        {
            MoveToProductPage(context, null);
        }

        public void UpdateProduct()
        {
            MoveToProductPage(context, Selected());
        }

        public void DeleteProduct()
        {
            context.ProductLogic.Delete(new ProductBinding { Id = Selected().Id });
        }
    }
}
