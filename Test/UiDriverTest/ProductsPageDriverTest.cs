using Core.Models.View;
using ListImplement.Implements;
using System.Collections.Generic;
using UiDriver;
using Xunit;

namespace Test.UiDriverTest
{
    public class ProductsPageDriverTest
    {
        [Fact]
        public void TestGetAllProductsEmpty()
        {
            ProductsPageDriver driver = new ProductsPageDriver(new UiContext(new OrderLogic(), new ProductLogic()));

            List<ProductView> list = driver.GetAllProducts();

            Assert.Empty(list);
        }
    }
}
