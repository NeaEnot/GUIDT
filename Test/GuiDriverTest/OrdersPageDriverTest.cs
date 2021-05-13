using Core.Models.View;
using GuiDriver;
using System.Collections.Generic;
using Xunit;

namespace Test.GuiDriverTest
{
    public class OrdersPageDriverTest
    {
        [Fact]
        public void TestOrdersListEmpty()
        {
            OrdersPageDriver driver = new OrdersPageDriver();

            List<OrderView> list = driver.GetAllOrders();

            Assert.Empty(list);
        }
    }
}
