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
        public void TestReadEmpty()
        {
            OrderLogic logic = new OrderLogic();

            List<OrderView> list = logic.Read(null);

            Assert.Empty(list);

            logic.Delete(null);
        }

        [Fact]
        public void TestCreate()
        {
            OrderLogic logic = new OrderLogic();
            logic.Create(new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() });

            List<OrderView> list = logic.Read(null);

            Assert.Single(list);
            Assert.Equal(1, list[0].Id);

            logic.Delete(null);
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

            logic.Delete(null);
        }

        [Fact]
        public void TestDeleteAll()
        {
            OrderLogic logic = new OrderLogic();
            OrderBinding model = new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() };
            logic.Create(model);
            logic.Delete(null);

            List<OrderView> list = logic.Read(null);

            Assert.Empty(list);
        }

        [Fact]
        public void TestDeleteSingle()
        {
            OrderLogic logic = new OrderLogic();
            OrderBinding model1 = new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() };
            OrderBinding model2 = new OrderBinding { Id = 2, OrderProducts = new List<OrderProductBinding>() };
            logic.Create(model1);
            logic.Create(model2);
            logic.Delete(model1);

            List<OrderView> list = logic.Read(null);

            Assert.Single(list);
            Assert.Equal(2, list[0].Id);

            logic.Delete(null);
        }

        [Fact]
        public void TestDeleteOrderProducts()
        {
            OrderLogic logic = new OrderLogic();
            OrderBinding model1 = new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() };
            model1.OrderProducts.Add(new OrderProductBinding { Id = 1, OrderId = 1 });
            logic.Create(model1);
            logic.Delete(model1);
            OrderBinding model2 = new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() };
            model2.OrderProducts.Add(new OrderProductBinding { Id = 2, OrderId = 1 });
            logic.Create(model2);

            List<OrderView> list = logic.Read(null);

            Assert.Single(list[0].OrderProducts);

            logic.Delete(null);
        }

        [Fact]
        public void TestReadSingle()
        {
            OrderLogic logic = new OrderLogic();
            OrderBinding model1 = new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() };
            OrderBinding model2 = new OrderBinding { Id = 2, OrderProducts = new List<OrderProductBinding>() };
            logic.Create(model1);
            logic.Create(model2);

            List<OrderView> list = logic.Read(model1);

            Assert.Single(list);
            Assert.Equal(1, list[0].Id);
        }
    }
}
