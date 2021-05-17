using ListImplement.Implements;
using UiDriver;
using Xunit;

namespace Test.UiDriverTest
{
    public class OrderPageDriverTest
    {
        [Fact]
        public void TestConstructor()
        {
            OrderPageDriver driver1 = new OrderPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), 10);
            OrderPageDriver driver2 = new OrderPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), null);

            Assert.Equal(10, driver1.orderId);
            Assert.Equal(null, driver2.orderId);
        }
    }
}
