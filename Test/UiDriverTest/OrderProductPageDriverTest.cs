using Core.Models.Binding;
using Core.Models.View;
using ListImplement.Implements;
using System.Collections.Generic;
using UiDriver;
using Xunit;

namespace Test.UiDriverTest
{
    public class OrderProductPageDriverTest
    {
        [Fact]
        public void TestGetAllProductsEmpty()
        {
            OrderProductPageDriver driver = new OrderProductPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), new OrderView(), null);

            List<ProductView> list = driver.GetAllProducts();

            Assert.Empty(list);
        }

        [Fact]
        public void TestGetAllProducts()
        {
            ProductLogic logic = new ProductLogic();

            try
            {
                logic.Create(new ProductBinding { Name = "Test1", Price = 10 });
                logic.Create(new ProductBinding { Name = "Test2", Price = 15 });

                OrderProductPageDriver driver = new OrderProductPageDriver(new UiContext(new OrderLogic(), logic), new OrderView(), null);

                List<ProductView> list = driver.GetAllProducts();

                Assert.Equal(2, list.Count);
                Assert.Equal("Test1", list[0].Name);
                Assert.Equal(10, list[0].Price);
                Assert.Equal("Test2", list[1].Name);
                Assert.Equal(15, list[1].Price);
            }
            finally
            {
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestGetSum()
        {
            List<ProductView> products = new List<ProductView>();
            products.Add(new ProductView { Name = "Test1", Price = 10 });
            products.Add(new ProductView { Name = "Test2", Price = 15 });
            products.Add(new ProductView { Name = "Test3", Price = 23 });
            OrderProductPageDriver driver = new OrderProductPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), new OrderView(), null);

            driver.Selected = () => products[1];
            driver.Count = () => 10;

            Assert.Equal(150, driver.GetSum());
        }

        [Fact]
        public void TestGetSelectedProduct()
        {
            ProductLogic logic = new ProductLogic();

            try
            {
                logic.Create(new ProductBinding { Name = "Test1", Price = 10 });
                OrderProductView orderProduct = new OrderProductView { ProductId = 1 };

                OrderProductPageDriver driver = new OrderProductPageDriver(new UiContext(new OrderLogic(), logic), new OrderView(), orderProduct);
                ProductView product1 = driver.GetSelectedProduct();
                driver = new OrderProductPageDriver(new UiContext(new OrderLogic(), logic), new OrderView(), null);
                ProductView product2 = driver.GetSelectedProduct();

                Assert.Equal("Test1", product1.Name);
                Assert.Equal(10, product1.Price);
                Assert.Null(product2);
            }
            finally
            {
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestSaveCreatedOrderProduct()
        {
            OrderView order = new OrderView();
            OrderProductPageDriver driver = new OrderProductPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), order, null);
            driver.Selected = () => new ProductView { Name = "Banan", Price = 11 };
            driver.Count = () => 3;

            driver.SaveOrderProduct();

            Assert.Single(order.OrderProducts);
            Assert.Equal("Banan", order.OrderProducts[0].ProductName);
            Assert.Equal(11, order.OrderProducts[0].Price);
            Assert.Equal(3, order.OrderProducts[0].Count);
        }

        [Fact]
        public void TestSaveUpdatedOrderProduct()
        {
            OrderView order = new OrderView();
            order.OrderProducts.Add(new OrderProductView { ProductName = "Banan", Price = 11 });
            OrderProductPageDriver driver = new OrderProductPageDriver(new UiContext(new OrderLogic(), new ProductLogic()), order, order.OrderProducts[0]);
            driver.Selected = () => new ProductView { Name = "Ananas", Price = 14 };
            driver.Count = () => 1;

            driver.SaveOrderProduct();

            Assert.Single(order.OrderProducts);
            Assert.Equal("Ananas", order.OrderProducts[0].ProductName);
            Assert.Equal(14, order.OrderProducts[0].Price);
            Assert.Equal(1, order.OrderProducts[0].Count);
        }
    }
}
