using Core.Models.View;
using GuiDriver.Models;
using System.Collections.Generic;
using Xunit;

namespace Test.GuiDriverTest
{
    public class ModelsTest
    {
        [Fact]
        public void TestOrdersResponse()
        {
            OrdersResponse response = new OrdersResponse { Orders = new List<OrderView>(), VisibleColumns = new bool[] { true, true, false } };

            Assert.Empty(response.Orders);
            Assert.Equal(3, response.VisibleColumns.Length);
            Assert.True(response.VisibleColumns[0]);
            Assert.True(response.VisibleColumns[1]);
            Assert.False(response.VisibleColumns[2]);
        }
    }
}
