using Core.Models.Binding;
using Core.Models.View;
using UiDriver;
using ListImplement.Implements;
using System.Collections.Generic;
using Xunit;
using Core.Interfaces;

namespace Test.UiDriverTest
{
    public class OrdersPageDriverTest
    {
        private class OrderLogicNI : IOrderLogic
        {
            public void Create(OrderBinding model)
            {
                throw new System.NotImplementedException();
            }

            public void Delete(OrderBinding model)
            {
                throw new System.NotImplementedException();
            }

            public List<OrderView> Read(OrderBinding model)
            {
                throw new System.NotImplementedException();
            }

            public void Update(OrderBinding model)
            {
                throw new System.NotImplementedException();
            }
        }

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
            string msg = "";
            OrdersPageDriver driver = new OrdersPageDriver(new UiContext(new OrderLogic(), new ProductLogic()));

            driver.MoveToOrderPage = (context, order) => { msg += "!"; };

            driver.AddOrder();
            driver.AddOrder();

            Assert.Equal("!!", msg);
        }

        [Fact]
        public void TestMethodDelete()
        {
            string message = "";
            OrderLogic orderLogic = new OrderLogic();
            OrdersPageDriver driver = new OrdersPageDriver(new UiContext(new OrderLogic(), new ProductLogic()));
            driver.ShowInfoMessage = (msg) => { message = msg; };

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
                Assert.Equal("Order №2 was deleted", message);
            }
            finally
            {
                orderLogic.Delete(null);
            }
        }

        [Fact]
        public void TestMethodUpdate()
        {
            string msg = "";
            OrdersPageDriver driver = new OrdersPageDriver(new UiContext(new OrderLogic(), new ProductLogic()));

            driver.MoveToOrderPage =
                (context, order) =>
                {
                    for (int i = 0; i < order.Id; i++)
                    {
                        msg += "!";
                    }
                };
            driver.Selected = () => new OrderView { Id = 3 };

            driver.UpdateOrder();
            driver.UpdateOrder();

            Assert.Equal("!!!!!!", msg);
        }

        [Fact]
        public void TestMethodMoveToProductsPage()
        {
            string msg = "";
            OrdersPageDriver driver = new OrdersPageDriver(new UiContext(new OrderLogic(), new ProductLogic()));

            driver.MoveToProductsPage = () => { msg = "!"; };

            driver.ToProducts();

            Assert.Equal("!", msg);
        }

        [Fact]
        public void TestExceptionInSelected()
        {
            string message = "";
            OrdersPageDriver driver = new OrdersPageDriver(new UiContext(new OrderLogic(), new ProductLogic()));

            driver.MoveToOrderPage = (context, order) => {};
            driver.Selected = () => (new List<OrderView>())[0];
            driver.ShowErrorMessage = (msg) => { message = msg; };

            driver.UpdateOrder();
            Assert.Equal("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')", message);
            message = "";

            driver.DeleteOrder();
            Assert.Equal("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')", message);
        }

        [Fact]
        public void TestExceptionInGetAllOrders()
        {
            string message = "";
            OrdersPageDriver driver = new OrdersPageDriver(new UiContext(new OrderLogicNI(), new ProductLogic()));
            driver.ShowErrorMessage = (msg) => { message = msg; };

            List<OrderView> list = driver.GetAllOrders();

            Assert.Equal("The method or operation is not implemented.", message);
        }
    }
}
