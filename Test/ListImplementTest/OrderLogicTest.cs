using Core.Models.Binding;
using Core.Models.View;
using ListImplement.Implements;
using System.Collections.Generic;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
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
        }

        [Fact]
        public void TestCreate()
        {
            OrderLogic logic = new OrderLogic();

            try
            {
                logic.Create(new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() });

                List<OrderView> list = logic.Read(null);

                Assert.Single(list);
                Assert.Equal(1, list[0].Id);
            }
            finally
            {
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestCreateWithOrderProducts()
        {
            OrderLogic logicO = new OrderLogic();
            ProductLogic logicP = new ProductLogic();

            try
            {
                OrderBinding model = new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() };
                model.OrderProducts.Add(new OrderProductBinding { Count = 10, ProductId = 1 });
                model.OrderProducts.Add(new OrderProductBinding { Count = 13, ProductId = 2 });
                logicP.Create(new ProductBinding { Id = 1, Name = "0", Price = 10 });
                logicP.Create(new ProductBinding { Id = 2, Name = "1", Price = 5 });
                logicO.Create(model);

                List<OrderView> list = logicO.Read(null);

                Assert.Equal(2, list[0].OrderProducts.Count);
                Assert.Equal(5, list[0].OrderProducts[1].Price);
            }
            finally
            {
                logicO.Delete(null);
                logicP.Delete(null);
            }
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

            try
            {
                OrderBinding model1 = new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() };
                OrderBinding model2 = new OrderBinding { Id = 2, OrderProducts = new List<OrderProductBinding>() };
                logic.Create(model1);
                logic.Create(model2);
                logic.Delete(model1);

                List<OrderView> list = logic.Read(null);

                Assert.Single(list);
                Assert.Equal(2, list[0].Id);
            }
            finally
            {
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestDeleteOrderProducts()
        {
            OrderLogic logicO = new OrderLogic();
            ProductLogic logicP = new ProductLogic();

            try
            {
                OrderBinding model1 = new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() };
                model1.OrderProducts.Add(new OrderProductBinding { ProductId = 1 });
                logicP.Create(new ProductBinding());
                logicO.Create(model1);
                logicO.Delete(model1);
                OrderBinding model2 = new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() };
                model2.OrderProducts.Add(new OrderProductBinding { ProductId = 1 });
                logicO.Create(model2);

                List<OrderView> list = logicO.Read(null);

                Assert.Single(list[0].OrderProducts);
            }
            finally
            {
                logicO.Delete(null);
                logicP.Delete(null);
            }
        }

        [Fact]
        public void TestReadSingle()
        {
            OrderLogic logic = new OrderLogic();

            try
            {
                OrderBinding model1 = new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() };
                OrderBinding model2 = new OrderBinding { Id = 2, OrderProducts = new List<OrderProductBinding>() };
                logic.Create(model1);
                logic.Create(model2);

                List<OrderView> list = logic.Read(model1);

                Assert.Single(list);
                Assert.Equal(1, list[0].Id);
            }
            finally
            {
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestOrderAutoId()
        {
            OrderLogic logic = new OrderLogic();

            try
            {
                OrderBinding model1 = new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() };
                OrderBinding model2 = new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() };
                logic.Create(model1);
                logic.Create(model2);

                List<OrderView> list = logic.Read(null);

                Assert.Equal(1, list[0].Id);
                Assert.Equal(2, list[1].Id);
            }
            finally
            {
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestOrderProductAutoId()
        {
            OrderLogic logicO = new OrderLogic();
            ProductLogic logicP = new ProductLogic();

            try
            {
                OrderBinding model1 = new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() };
                OrderBinding model2 = new OrderBinding { Id = 1, OrderProducts = new List<OrderProductBinding>() };
                model1.OrderProducts.Add(new OrderProductBinding { ProductId = 1 });
                model1.OrderProducts.Add(new OrderProductBinding { ProductId = 2 });
                model2.OrderProducts.Add(new OrderProductBinding { ProductId = 1 });
                logicP.Create(new ProductBinding { Name = "0" });
                logicP.Create(new ProductBinding { Name = "1" });
                logicO.Create(model1);
                logicO.Create(model2);

                List<OrderView> list = logicO.Read(null);

                Assert.Equal(1, list[0].OrderProducts[0].Id);
                Assert.Equal(2, list[0].OrderProducts[1].Id);
                Assert.Equal(3, list[1].OrderProducts[0].Id);
                Assert.Equal(1, list[0].OrderProducts[0].OrderId);
                Assert.Equal(1, list[0].OrderProducts[1].OrderId);
                Assert.Equal(2, list[1].OrderProducts[0].OrderId);
            }
            finally
            {
                logicO.Delete(null);
                logicP.Delete(null);
            }
        }

        [Fact]
        public void TestUpdate()
        {
            OrderLogic logicO = new OrderLogic();
            ProductLogic logicP = new ProductLogic();

            try
            {
                logicP.Create(new ProductBinding { Name = "0" });
                logicP.Create(new ProductBinding { Name = "1" });
                OrderBinding model = new OrderBinding { OrderProducts = new List<OrderProductBinding>() };
                model.OrderProducts.Add(new OrderProductBinding { ProductId = 1, Count = 3 });
                logicO.Create(model);
                OrderView ov = logicO.Read(null)[0];
                OrderBinding model2 = new OrderBinding { Id = ov.Id, OrderProducts = new List<OrderProductBinding>() };
                model2.OrderProducts.Add(new OrderProductBinding { ProductId = 1, Count = 4 });
                model2.OrderProducts.Add(new OrderProductBinding { ProductId = 2, Count = 6 });
                logicO.Update(model2);

                List<OrderView> list = logicO.Read(null);

                Assert.Equal(2, list[0].OrderProducts.Count);
                Assert.Equal(1, list[0].OrderProducts[0].ProductId);
                Assert.Equal(4, list[0].OrderProducts[0].Count);
                Assert.Equal(2, list[0].OrderProducts[1].ProductId);
                Assert.Equal(6, list[0].OrderProducts[1].Count);
            }
            finally
            {
                logicO.Delete(null);
                logicP.Delete(null);
            }
        }

        [Fact]
        public void TestCreateSeveralOPWithSameProductId()
        {
            OrderLogic logicO = new OrderLogic();
            ProductLogic logicP = new ProductLogic();

            try
            {
                OrderBinding model = new OrderBinding { OrderProducts = new List<OrderProductBinding>() };
                model.OrderProducts.Add(new OrderProductBinding { ProductId = 1, Count = 3 });
                model.OrderProducts.Add(new OrderProductBinding { ProductId = 1, Count = 2 });
                logicP.Create(new ProductBinding { Id = 1 });
                logicO.Create(model);

                List<OrderView> list = logicO.Read(null);

                Assert.Single(list[0].OrderProducts);
                Assert.Equal(1, list[0].OrderProducts[0].ProductId);
                Assert.Equal(5, list[0].OrderProducts[0].Count);
            }
            finally
            {
                logicO.Delete(null);
                logicP.Delete(null);
            }
        }

        [Fact]
        public void TestUpdateSeveralOPWithSameProductId()
        {
            OrderLogic logicO = new OrderLogic();
            ProductLogic logicP = new ProductLogic();

            try
            {
                logicP.Create(new ProductBinding { Name = "0" });
                logicP.Create(new ProductBinding { Name = "1" });
                OrderBinding model = new OrderBinding { OrderProducts = new List<OrderProductBinding>() };
                model.OrderProducts.Add(new OrderProductBinding { ProductId = 1, Count = 3 });
                logicO.Create(model);
                OrderView ov = logicO.Read(null)[0];
                OrderBinding model2 = new OrderBinding { Id = ov.Id, OrderProducts = new List<OrderProductBinding>() };
                model2.OrderProducts.Add(new OrderProductBinding { ProductId = 1, Count = 3 });
                model2.OrderProducts.Add(new OrderProductBinding { ProductId = 1, Count = 2 });
                model2.OrderProducts.Add(new OrderProductBinding { ProductId = 2, Count = 1 });
                model2.OrderProducts.Add(new OrderProductBinding { ProductId = 2, Count = 5 });
                logicO.Update(model2);

                List<OrderView> list = logicO.Read(null);

                Assert.Equal(2, list[0].OrderProducts.Count);
                Assert.Equal(1, list[0].OrderProducts[0].ProductId);
                Assert.Equal(5, list[0].OrderProducts[0].Count);
                Assert.Equal(2, list[0].OrderProducts[1].ProductId);
                Assert.Equal(6, list[0].OrderProducts[1].Count);
            }
            finally
            {
                logicO.Delete(null);
                logicP.Delete(null);
            }
        }

        [Fact]
        public void TestOrderProductName()
        {
            OrderLogic logicO = new OrderLogic();
            ProductLogic logicP = new ProductLogic();

            try
            {
                ProductBinding product = new ProductBinding { Name = "Test", Price = 20 };
                OrderBinding order = new OrderBinding { OrderProducts = new List<OrderProductBinding>() };
                order.OrderProducts.Add(new OrderProductBinding { ProductId = 1, Count = 2 });
                logicP.Create(product);
                logicO.Create(order);

                List<OrderView> list = logicO.Read(null);

                Assert.Equal("Test", list[0].OrderProducts[0].ProductName);
            }
            finally
            {
                logicO.Delete(null);
                logicP.Delete(null);
            }
        }

        [Fact]
        public void TestOrderProductUndefinedName()
        {
            OrderLogic logicO = new OrderLogic();
            ProductLogic logicP = new ProductLogic();

            try
            {
                ProductBinding product = new ProductBinding { Name = "Test", Price = 20 };
                OrderBinding order = new OrderBinding { OrderProducts = new List<OrderProductBinding>() };
                order.OrderProducts.Add(new OrderProductBinding { ProductId = 1, Count = 2 });
                logicP.Create(product);
                logicO.Create(order);
                logicP.Delete(new ProductBinding { Id = 1 });

                List<OrderView> list = logicO.Read(null);

                Assert.Equal("Undefined", list[0].OrderProducts[0].ProductName);
            }
            finally
            {
                logicO.Delete(null);
                logicP.Delete(null);
            }
        }

        [Fact]
        public void TestOrderProductPrice()
        {
            OrderLogic logicO = new OrderLogic();
            ProductLogic logicP = new ProductLogic();

            try
            {
                ProductBinding product = new ProductBinding { Name = "Test", Price = 20 };
                OrderBinding order = new OrderBinding { OrderProducts = new List<OrderProductBinding>() };
                order.OrderProducts.Add(new OrderProductBinding { ProductId = 1, Count = 2 });
                logicP.Create(product);
                logicO.Create(order);

                List<OrderView> list = logicO.Read(null);

                Assert.Equal(20, list[0].OrderProducts[0].Price);
            }
            finally
            {
                logicO.Delete(null);
                logicP.Delete(null);
            }
        }
    }
}
