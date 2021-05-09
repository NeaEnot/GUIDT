using Core.Models.Binding;
using System.Collections.Generic;
using Xunit;

namespace Test.CoreTest
{
    public class BindingModelsTest
    {
        [Fact]
        public void TestProductBinding()
        {
            ProductBinding pv = new ProductBinding { Id = 0, Name = "Test", Price = 100 };

            Assert.Equal(0, pv.Id);
            Assert.Equal("Test", pv.Name);
            Assert.Equal(100, pv.Price);
        }

        [Fact]
        public void TestOrderProductBinding()
        {
            OrderProductBinding opv = new OrderProductBinding { Id = 0, OrderId = 0, ProductId = 0, Count = 10, Price = 100 };

            Assert.Equal(0, opv.Id);
            Assert.Equal(0, opv.OrderId);
            Assert.Equal(0, opv.ProductId);
            Assert.Equal(10, opv.Count);
            Assert.Equal(100, opv.Price);
        }

        [Fact]
        public void TestOrderBinding()
        {
            OrderBinding ov = new OrderBinding { Id = 0, OrderProducts = new List<OrderProductBinding>() };
            ov.OrderProducts.Add(new OrderProductBinding { Id = 0, OrderId = 0, ProductId = 0, Count = 10 });
            ov.OrderProducts.Add(new OrderProductBinding { Id = 1, OrderId = 0, ProductId = 1, Count = 5 });

            Assert.Equal(0, ov.Id);
            Assert.Equal(0, ov.OrderProducts[0].ProductId);
            Assert.Equal(1, ov.OrderProducts[1].ProductId);
            Assert.Equal(10, ov.OrderProducts[0].Count);
            Assert.Equal(5, ov.OrderProducts[1].Count);
        }
    }
}
