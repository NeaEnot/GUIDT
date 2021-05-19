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
    }
}
