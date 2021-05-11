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
            ProductBinding pb = new ProductBinding { Id = 0, Name = "Test", Price = 100 };

            Assert.Equal(0, pb.Id);
            Assert.Equal("Test", pb.Name);
            Assert.Equal(100, pb.Price);
        }

        [Fact]
        public void TestOrderProductBinding()
        {
            OrderProductBinding opb = new OrderProductBinding { ProductId = 0, Count = 10, Price = 100 };

            Assert.Equal(0, opb.ProductId);
            Assert.Equal(10, opb.Count);
            Assert.Equal(100, opb.Price);
        }

        [Fact]
        public void TestOrderBinding()
        {
            OrderBinding ob = new OrderBinding { Id = 0, OrderProducts = new List<OrderProductBinding>() };
            ob.OrderProducts.Add(new OrderProductBinding { ProductId = 0, Count = 10 });
            ob.OrderProducts.Add(new OrderProductBinding { ProductId = 1, Count = 5 });

            Assert.Equal(0, ob.Id);
            Assert.Equal(0, ob.OrderProducts[0].ProductId);
            Assert.Equal(1, ob.OrderProducts[1].ProductId);
            Assert.Equal(10, ob.OrderProducts[0].Count);
            Assert.Equal(5, ob.OrderProducts[1].Count);
        }
    }
}
