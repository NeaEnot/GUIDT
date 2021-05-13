using Core.Models.View;
using GuiDriver;
using ListImplement.Implements;
using System.Collections.Generic;
using Xunit;

namespace Test.GuiDriverTest
{
    public class OrdersPageDriverTest
    {
        [Fact]
        public void TestOrdersListEmpty()
        {
            OrdersPageDriver driver = new OrdersPageDriver(new GuiContext(new OrderLogic(), new ProductLogic()));

            List<OrderView> list = driver.GetAllOrders();

            Assert.Empty(list);
        }
    }
}
