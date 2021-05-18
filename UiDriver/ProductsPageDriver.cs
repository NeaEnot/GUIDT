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
            try
            {
                MoveToProductPage(context, Selected());
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }

        public void DeleteProduct()
        {
            try
            {
                int id = Selected().Id;
                context.ProductLogic.Delete(new ProductBinding { Id = id });
                ShowInfoMessage("Product №" + id + " was deleted");
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
    }
}
