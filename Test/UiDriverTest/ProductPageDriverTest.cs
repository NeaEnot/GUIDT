using ListImplement.Implements;
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
    }
}
