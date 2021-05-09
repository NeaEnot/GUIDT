﻿using Core.Models.View;
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
        public void TestOrderView()
        {
            OrderView ov = new OrderView { Id = 0, Sum = 1000 };

            Assert.Equal(0, ov.Id);
            Assert.Equal(1000, ov.Sum);
        }

        [Fact]
        public void TestOrderProductView()
        {
            OrderProductView opv = new OrderProductView { Id = 0, OrderId = 0, ProductId = 0, Count = 10 };

            Assert.Equal(0, opv.Id);
            Assert.Equal(0, opv.OrderId);
            Assert.Equal(0, opv.ProductId);
            Assert.Equal(10, opv.Count);
        }

        [Fact]
        public void TestOrderProductsInOrderView()
        {
            OrderView ov = new OrderView { Id = 0, Sum = 1000, OrderProducts = new List<OrderProductView>() };
            ov.OrderProducts.Add(new OrderProductView { Id = 0, OrderId = 0, ProductId = 0, Count = 10 });
            ov.OrderProducts.Add(new OrderProductView { Id = 1, OrderId = 0, ProductId = 1, Count = 5 });

            Assert.Equal(0, ov.OrderProducts[0].ProductId);
            Assert.Equal(1, ov.OrderProducts[1].ProductId);
            Assert.Equal(10, ov.OrderProducts[0].Count);
            Assert.Equal(5, ov.OrderProducts[1].Count);
        }
    }
}
