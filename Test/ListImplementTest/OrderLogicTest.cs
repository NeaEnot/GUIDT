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

        [Fact]
        public void TestCreateWithOrderProducts()
        {
            OrderLogic logic = new OrderLogic();
            OrderBinding model = new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() };
            model.OrderProducts.Add(new OrderProductBinding { Id = 1, Count = 10, OrderId = 1, Price = 10, ProductId = 1 });
            model.OrderProducts.Add(new OrderProductBinding { Id = 2, Count = 13, OrderId = 1, Price = 5, ProductId = 2 });
            logic.Create(model);

            List<OrderView> list = logic.Read(null);

            Assert.Equal(2, list[0].OrderProducts.Count);
            Assert.Equal(5, list[0].OrderProducts[1].Price);
        }
    }
}
