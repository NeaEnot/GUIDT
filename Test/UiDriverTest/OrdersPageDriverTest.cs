﻿using Core.Models.Binding;
using Core.Models.View;
using UiDriver;
using ListImplement.Implements;
using System.Collections.Generic;
using Xunit;

namespace Test.UiDriverTest
{
    public class OrdersPageDriverTest
    {
        [Fact]
        public void TestOrdersListEmpty()
        {
            OrdersPageDriver driver = new OrdersPageDriver(new UiContext(new OrderLogic(), new ProductLogic()));

            List<OrderView> list = driver.GetAllOrders();

            Assert.Empty(list);
        }

        [Fact]
        public void TestOrdersListNotEmpty()
        {
            OrderLogic orderLogic = new OrderLogic();
            OrdersPageDriver driver = new OrdersPageDriver(new UiContext(orderLogic, new ProductLogic()));

            try
            {
                orderLogic.Create(new OrderBinding { OrderProducts = new List<OrderProductBinding>() });
                orderLogic.Create(new OrderBinding { OrderProducts = new List<OrderProductBinding>() });

                List<OrderView> list = driver.GetAllOrders();

                Assert.Equal(2, list.Count);
            }
            finally
            {
                orderLogic.Delete(null);
            }
        }

        [Fact]
        public void TestMethodMoveToOrderPage()
        {
            OrderLogic orderLogic = new OrderLogic();
            OrdersPageDriver driver = new OrdersPageDriver(new UiContext(new OrderLogic(), new ProductLogic()));

            try
            {
                driver.MoveToOrderPage =
                    (context, order) =>
                    {
                        orderLogic.Create(new OrderBinding());
                        orderLogic.Create(new OrderBinding());
                    };

                driver.AddOrder();
                driver.AddOrder();
                List<OrderView> list = driver.GetAllOrders();

                Assert.Equal(4, list.Count);
            }
            finally
            {
                orderLogic.Delete(null);
            }
        }

        [Fact]
        public void TestMethodDelete()
        {
            OrderLogic orderLogic = new OrderLogic();
            OrdersPageDriver driver = new OrdersPageDriver(new UiContext(new OrderLogic(), new ProductLogic()));

            try
            {
                orderLogic.Create(new OrderBinding { OrderProducts = new List<OrderProductBinding>() });
                orderLogic.Create(new OrderBinding { OrderProducts = new List<OrderProductBinding>() });
                orderLogic.Create(new OrderBinding { OrderProducts = new List<OrderProductBinding>() });
                driver.Selected = () => orderLogic.Read(null)[1];

                driver.DeleteOrder();
                List<OrderView> list = driver.GetAllOrders();

                Assert.Equal(2, list.Count);
                Assert.Equal(1, list[0].Id);
                Assert.Equal(3, list[1].Id);
            }
            finally
            {
                orderLogic.Delete(null);
            }
        }

        [Fact]
        public void TestMethodUpdate()
        {
            OrderLogic orderLogic = new OrderLogic();
            OrdersPageDriver driver = new OrdersPageDriver(new UiContext(new OrderLogic(), new ProductLogic()));

            try
            {
                driver.MoveToOrderPage =
                    (context, order) =>
                    {
                        for (int i = 0; i < order.Id; i++)
                        {
                            orderLogic.Create(new OrderBinding());
                        }
                    };
                driver.Selected = () => new OrderView { Id = 3 };

                driver.UpdateOrder();
                driver.UpdateOrder();
                List<OrderView> list = driver.GetAllOrders();

                Assert.Equal(6, list.Count);
            }
            finally
            {
                orderLogic.Delete(null);
            }
        }
    }
}
