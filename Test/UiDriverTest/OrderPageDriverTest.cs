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
            Assert.Equal(null, driver2.order);
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
                (context, orderProduct) => 
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

            driver.MoveToOrderProductPage = (context, orderProduct) => { };
            driver.Selected = () => (new List<OrderProductView>())[0];
            driver.ShowErrorMessage = (msg) => { message = msg; };

            driver.UpdateOrderProduct();
            Assert.Equal("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')", message);
            message = "";

            driver.DeleteOrderProduct();
            Assert.Equal("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')", message);
        }
    }
}
