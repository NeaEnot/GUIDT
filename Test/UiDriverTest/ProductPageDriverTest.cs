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
        public void TestProductName()
        {
            ProductPageDriver driver = new ProductPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), null);
            driver.ProductName = () => "Ananas";

            string msg = driver.ProductName();

            Assert.Equal("Ananas", msg);
        }

        [Fact]
        public void TestProductPrice()
        {
            ProductPageDriver driver = new ProductPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), null);
            driver.ProductPrice = () => 13;

            int msg = driver.ProductPrice();

            Assert.Equal(13, msg);
        }

        [Fact]
        public void TestMethodSaveCreatedProduct()
        {
            ProductLogic logic = new ProductLogic();

            try
            {
                ProductPageDriver driver = new ProductPageDriver(new UiContext(new OrderLogic(), logic), null);
                driver.ProductName = () => "Banan";
                driver.ProductPrice = () => 38;

                driver.Save();
                List<ProductView> list = logic.Read(null);

                Assert.Single(list);
                Assert.Equal("Banan", list[0].Name);
                Assert.Equal(38, list[0].Price);
            }
            finally
            {
                logic.Delete(null);
            }
        }
    }
}
