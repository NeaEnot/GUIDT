using Core.Models.View;
using System.Collections.Generic;

namespace UiDriver
{
    public class OrderProductPageDriver: PageDriver
    {
        private UiContext context;

        public OrderProductPageDriver(UiContext context, OrderView order, OrderProductView orderProduct)
        {
            this.context = context;
        }

        public List<ProductView> GetAllProducts()
        {
            return context.ProductLogic.Read(null);
        }
    }
}
