using Core.Models.View;
using System.Collections.Generic;

namespace UiDriver
{
    public class ProductsPageDriver : PageDriver
    {
        public ProductsPageDriver(UiContext context) : base(context)
        { }

        public List<ProductView> GetAllProducts()
        {
            return context.ProductLogic.Read(null);
        }
    }
}
