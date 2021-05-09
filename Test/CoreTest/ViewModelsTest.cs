using Core.Models.View;
using System.Collections.Generic;
using Xunit;

namespace Test.CoreTest
{
    public class ViewModelsTest
    {
        [Fact]
        public void TestProductView()
        {
            ProductView pv = new ProductView { Id = 0, Name = "Test", Price = 100 };

            Assert.Equal(0, pv.Id);
            Assert.Equal("Test", pv.Name);
            Assert.Equal(100, pv.Price);
        }

        [Fact]
        public void TestOrderProductView()
        {
            OrderProductView opv = new OrderProductView { Id = 0, OrderId = 0, ProductId = 0, ProductName = "Test", Count = 10, Price = 100 };

            Assert.Equal(0, opv.Id);
            Assert.Equal(0, opv.OrderId);
            Assert.Equal(0, opv.ProductId);
            Assert.Equal("Test", opv.ProductName);
            Assert.Equal(10, opv.Count);
            Assert.Equal(100, opv.Price);
        }

        [Fact]
        public void TestOrderView()
        {
            OrderView ov = new OrderView { Id = 0, OrderProducts = new List<OrderProductView>() };
            ov.OrderProducts.Add(new OrderProductView { Id = 0, OrderId = 0, ProductId = 0, Count = 10, Price = 10 });
            ov.OrderProducts.Add(new OrderProductView { Id = 1, OrderId = 0, ProductId = 1, Count = 5, Price = 2 });

            Assert.Equal(0, ov.Id);
            Assert.Equal(110, ov.Sum);
            Assert.Equal(0, ov.OrderProducts[0].ProductId);
            Assert.Equal(1, ov.OrderProducts[1].ProductId);
            Assert.Equal(10, ov.OrderProducts[0].Count);
            Assert.Equal(5, ov.OrderProducts[1].Count);
        }
    }
}
