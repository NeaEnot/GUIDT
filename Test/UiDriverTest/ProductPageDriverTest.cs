using Core.Models.Binding;
using Core.Models.View;
using ListImplement.Implements;
using System.Collections.Generic;
using UiDriver;
using Xunit;

namespace Test.UiDriverTest
{
    public class ProductPageDriverTest
    {
        [Fact]
        public void TestMethodSaveCreatedProduct()
        {
            string message = "";
            ProductLogic logic = new ProductLogic();

            try
            {
                ProductPageDriver driver = new ProductPageDriver(new UiContext(new OrderLogic(), logic), null);
                driver.ProductName = () => "Banan";
                driver.ProductPrice = () => 38;
                driver.ShowInfoMessage = (msg) => message = msg;

                driver.Save();
                List<ProductView> list = logic.Read(null);

                Assert.Single(list);
                Assert.Equal("Banan", list[0].Name);
                Assert.Equal(38, list[0].Price);
                Assert.Equal("Product was created", message);
            }
            finally
            {
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestMethodSaveUpdatedProduct()
        {
            string message = "";
            ProductLogic logic = new ProductLogic();

            try
            {
                logic.Create(new ProductBinding { Name = "Ananas", Price = 87 });
                ProductPageDriver driver = new ProductPageDriver(new UiContext(new OrderLogic(), logic), logic.Read(null)[0]);
                driver.ProductName = () => "Banan";
                driver.ProductPrice = () => 38;
                driver.ShowInfoMessage = (msg) => message = msg;

                driver.Save();
                List<ProductView> list = logic.Read(null);

                Assert.Single(list);
                Assert.Equal("Banan", list[0].Name);
                Assert.Equal(38, list[0].Price);
                Assert.Equal("Product was updated", message);
            }
            finally
            {
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestGetEmptyProductData()
        {
            ProductPageDriver driver = new ProductPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), null);
            
            string name = driver.GetName();
            int price = driver.GetPrice();

            Assert.Equal("", name);
            Assert.Equal(0, price);
        }

        [Fact]
        public void TestGetFullProductData()
        {
            ProductPageDriver driver = new ProductPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), new ProductView { Name = "Banan", Price = 13 });

            string name = driver.GetName();
            int price = driver.GetPrice();

            Assert.Equal("Banan", name);
            Assert.Equal(13, price);
        }
    }
}
