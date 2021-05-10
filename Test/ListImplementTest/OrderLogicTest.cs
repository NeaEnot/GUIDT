using Core.Models.View;
using ListImplement.Implements;
using System.Collections.Generic;
using Xunit;

namespace Test.ListImplementTest
{
    public class OrderLogicTest
    {
        [Fact]
        public void TestRead()
        {
            OrderLogic logic = new OrderLogic();

            List<OrderView> list = logic.Read(null);

            Assert.Empty(list);
        }
    }
}
