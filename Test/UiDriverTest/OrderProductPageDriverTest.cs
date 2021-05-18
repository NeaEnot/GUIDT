using Core.Models.Binding;
using Core.Models.View;
using ListImplement.Implements;
using System.Collections.Generic;
using UiDriver;
using Xunit;

namespace Test.UiDriverTest
{
    public class OrderProductPageDriverTest
    {
        [Fact]
        public void TestGetAllProductsEmpty()
        {
            OrderProductPageDriver driver = new OrderProductPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), new OrderView(), null);

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

                OrderProductPageDriver driver = new OrderProductPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), new OrderView(), null);

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
        public void TestGetSum()
        {
            List<ProductView> products = new List<ProductView>();
            products.Add(new ProductView { Name = "Test1", Price = 10 });
            products.Add(new ProductView { Name = "Test2", Price = 15 });
            products.Add(new ProductView { Name = "Test3", Price = 23 });
            OrderProductPageDriver driver = new OrderProductPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), new OrderView(), null);

            driver.Selected = () => products[1];
            driver.Count = () => 10;

            Assert.Equal(150, driver.GetSum());
        }
    }
}
