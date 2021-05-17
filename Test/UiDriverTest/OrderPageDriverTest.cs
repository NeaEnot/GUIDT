using Core.Models.View;
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
            OrderPageDriver driver1 = new OrderPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), new OrderView { Id = 10 });
            OrderPageDriver driver2 = new OrderPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), null);

            Assert.Equal(10, driver1.order.Id);
            Assert.Equal(null, driver2.order);
        }

        //[Fact]
        //public void TestGetAllOrderProducts()
        //{
        //    OrderPageDriver driver = new OrderPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), 1);
        //}
    }
}
