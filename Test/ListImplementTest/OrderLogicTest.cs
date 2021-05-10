using Core.Models.Binding;
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

        [Fact]
        public void TestCreate()
        {
            OrderLogic logic = new OrderLogic();
            logic.Create(new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() });

            List<OrderView> list = logic.Read(null);

            Assert.Single(list);
            Assert.Equal(1, list[0].Id);
        }
    }
}
