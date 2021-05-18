using Core.Models.Binding;
using Core.Models.View;
using ListImplement.Implements;
using System.Collections.Generic;
using UiDriver;
using Xunit;

namespace Test.UiDriverTest
{
    public class OrderPageDriverTest
    {
        [Fact]
        public void TestConstructor()
        {
            OrderPageDriver driver1 = new OrderPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), new OrderView { Id = 10 });
            OrderPageDriver driver2 = new OrderPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), null);

            Assert.Equal(10, driver1.order.Id);
            Assert.Equal(-1, driver2.order.Id);
        }

        [Fact]
        public void TestGetAllOrderProducts()
        {
            OrderView order = new OrderView();
            order.OrderProducts.Add(new OrderProductView { Id = 2, ProductId = 8, Price = 50, Count = 4, ProductName = "Test1" });
            order.OrderProducts.Add(new OrderProductView { Id = 3, ProductId = 3, Price = 25, Count = 1, ProductName = "Test2" });
            order.OrderProducts.Add(new OrderProductView { Id = 5, ProductId = 6, Price = 1, Count = 100, ProductName = "Test3" });
            OrderPageDriver driver = new OrderPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), order);

            List<OrderProductView> list = driver.GetAllOrderProducts();

            Assert.Equal(2, list[0].Id);
            Assert.Equal(8, list[0].ProductId);
            Assert.Equal("Test1", list[0].ProductName);
            Assert.Equal(3, list[1].Id);
            Assert.Equal(25, list[1].Price);
            Assert.Equal("Test2", list[1].ProductName);
            Assert.Equal(5, list[2].Id);
            Assert.Equal(100, list[2].Count);
            Assert.Equal("Test3", list[2].ProductName);
        }

        [Fact]
        public void TestDeleteOrderProduct()
        {
            OrderView order = new OrderView();
            order.OrderProducts.Add(new OrderProductView { Id = 2, ProductId = 8, Price = 50, Count = 4, ProductName = "Test1" });
            order.OrderProducts.Add(new OrderProductView { Id = 3, ProductId = 3, Price = 25, Count = 1, ProductName = "Test2" });
            order.OrderProducts.Add(new OrderProductView { Id = 5, ProductId = 6, Price = 1, Count = 100, ProductName = "Test3" });
            OrderPageDriver driver = new OrderPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), order);
            driver.Selected = () => order.OrderProducts[1];

            driver.DeleteOrderProduct();
            List<OrderProductView> list = driver.GetAllOrderProducts();

            Assert.Equal(2, list.Count);
            Assert.Equal(2, list[0].Id);
            Assert.Equal("Test1", list[0].ProductName);
            Assert.Equal(5, list[1].Id);
            Assert.Equal("Test3", list[1].ProductName);
        }

        [Fact]
        public void TestMethodMoveToOrderProductPage()
        {
            string msg = "";
            OrderView order = new OrderView();
            OrderPageDriver driver = new OrderPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), order);

            driver.MoveToOrderProductPage = 
                (context, order, orderProduct) => 
                {
                    if (orderProduct == null)
                    {
                        msg += "!";
                    }
                    else
                    {
                        msg += "~";
                    }
                };
            driver.Selected = () => new OrderProductView();

            driver.AddOrderProduct();
            driver.UpdateOrderProduct();
            driver.AddOrderProduct();

            Assert.Equal("!~!", msg);
        }

        [Fact]
        public void TestExceptionInSelected()
        {
            string message = "";
            OrderPageDriver driver = new OrderPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), new OrderView());

            driver.MoveToOrderProductPage = (context, order, orderProduct) => { };
            driver.Selected = () => (new List<OrderProductView>())[0];
            driver.ShowErrorMessage = (msg) => { message = msg; };

            driver.UpdateOrderProduct();
            Assert.Equal("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')", message);
            message = "";

            driver.DeleteOrderProduct();
            Assert.Equal("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')", message);
        }

        [Fact]
        public void TestMethodSaveCreatedOrder()
        {
            string message = "";
            OrderLogic logicO = new OrderLogic();
            ProductLogic logicP = new ProductLogic();
            OrderPageDriver driver = new OrderPageDriver(new UiContext(logicO, logicP), null);
            driver.ShowInfoMessage = (msg) => { message = msg; };

            try
            {
                logicP.Create(new ProductBinding { Price = 10 });
                driver.MoveToOrderProductPage = (context, order, orderProduct) => order.OrderProducts.Add(new OrderProductView { ProductId = 1 });
                driver.AddOrderProduct();
                driver.AddOrderProduct();
                driver.AddOrderProduct();

                driver.SaveOrder();
                List<OrderView> list = logicO.Read(null);

                Assert.Single(list);
                Assert.Single(list[0].OrderProducts);
                Assert.Equal("Order was created", message);
            }
            finally
            {
                logicO.Delete(null);
                logicP.Delete(null);
            }
        }

        [Fact]
        public void TestMethodSaveUpdatedOrder()
        {
            string message = "";
            OrderLogic logicO = new OrderLogic();
            ProductLogic logicP = new ProductLogic();

            try
            {
                logicP.Create(new ProductBinding { Price = 10 });
                logicO.Create(new OrderBinding());
                OrderPageDriver driver = new OrderPageDriver(new UiContext(logicO, logicP), logicO.Read(null)[0]);
                driver.ShowInfoMessage = (msg) => { message = msg; };
                driver.MoveToOrderProductPage = (context, order, orderProduct) => order.OrderProducts.Add(new OrderProductView { ProductId = 1 });
                driver.AddOrderProduct();
                driver.AddOrderProduct();
                driver.AddOrderProduct();

                driver.SaveOrder();
                List<OrderView> list = logicO.Read(null);

                Assert.Single(list);
                Assert.Single(list[0].OrderProducts);
                Assert.Equal("Order №1 was updated", message);
            }
            finally
            {
                logicO.Delete(null);
                logicP.Delete(null);
            }
        }

        [Fact]
        public void TestMethodSaveOrderWithoutOrderProducts()
        {
            string message = "";
            OrderLogic logicO = new OrderLogic();
            OrderPageDriver driver = new OrderPageDriver(new UiContext(logicO, new ProductLogic()), null);
            driver.ShowErrorMessage = (msg) => { message = msg; };

            try
            {
                driver.SaveOrder();
                List<OrderView> list = logicO.Read(null);

                Assert.Empty(list);
                Assert.Equal("List of products is empty", message);
            }
            finally
            {
                logicO.Delete(null);
            }
        }
    }
}
