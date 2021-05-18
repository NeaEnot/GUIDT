using Core.Models.Binding;
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

        [Fact]
        public void TestGetAllProducts()
        {
            ProductLogic logic = new ProductLogic();

            try
            {
                logic.Create(new ProductBinding { Name = "Test1", Price = 10 });
                logic.Create(new ProductBinding { Name = "Test2", Price = 15 });

                ProductsPageDriver driver = new ProductsPageDriver(new UiContext(new OrderLogic(), logic));

                List<ProductView> list = driver.GetAllProducts();

                Assert.Equal(2, list.Count);
                Assert.Equal("Test1", list[0].Name);
                Assert.Equal(10, list[0].Price);
                Assert.Equal("Test2", list[1].Name);
                Assert.Equal(15, list[1].Price);
            }
            finally
            {
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestSelect()
        {
            ProductsPageDriver driver = new ProductsPageDriver(new UiContext(new OrderLogic(), new ProductLogic()));
            driver.Selected = () => new ProductView { Id = 2, Name = "Apple", Price = 9 };

            ProductView item = driver.Selected();

            Assert.Equal(2, item.Id);
            Assert.Equal("Apple", item.Name);
            Assert.Equal(9, item.Price);
        }
    }
}
