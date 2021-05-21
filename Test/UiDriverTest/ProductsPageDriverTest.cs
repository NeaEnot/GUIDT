using Core.Models.Binding;
using Core.Models.View;
using ListImplement.Implements;
using System.Collections.Generic;
using UiDriver;
using Xunit;

namespace Test.UiDriverTest
{
    public class ProductsPageDriverTest
    {
        [Fact]
        public void TestGetAllProductsEmpty()
        {
            ProductsPageDriver driver = new ProductsPageDriver(new UiContext(new OrderLogic(), new ProductLogic()));

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

                ProductsPageDriver driver = new ProductsPageDriver(new UiContext(new OrderLogic(), logic));

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
        public void TestMethodMoveToProductPage()
        {
            string message = "";
            ProductsPageDriver driver = new ProductsPageDriver(new UiContext(new OrderLogic(), new ProductLogic()));
            driver.Selected = () => new ProductView();
            driver.MoveToProductPage =
                (context, product) =>
                {
                    if (product == null)
                    {
                        message += "!";
                    }
                    else
                    {
                        message += "~";
                    }
                };

            driver.AddProduct();
            driver.UpdateProduct();

            Assert.Equal("!~", message);
        }

        [Fact]
        public void TestMethodDeleteProduct()
        {
            string message = "";
            ProductLogic logic = new ProductLogic();

            try
            {
                logic.Create(new ProductBinding { Name = "Test1", Price = 10 });
                logic.Create(new ProductBinding { Name = "Test2", Price = 15 });
                logic.Create(new ProductBinding { Name = "Test3", Price = 23 });
                ProductsPageDriver driver = new ProductsPageDriver(new UiContext(new OrderLogic(), logic));
                List<ProductView> list = driver.GetAllProducts();
                driver.Selected = () => list[1];
                driver.ShowInfoMessage = (msg) => { message = msg; };

                driver.DeleteProduct();
                list = driver.GetAllProducts();

                Assert.Equal(2, list.Count);
                Assert.Equal("Test1", list[0].Name);
                Assert.Equal(10, list[0].Price);
                Assert.Equal("Test3", list[1].Name);
                Assert.Equal(23, list[1].Price);
                Assert.Equal("Product №2 was deleted", message);
            }
            finally
            {
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestExceptionSelected()
        {
            List<string> messages = new List<string>();
            ProductsPageDriver driver = new ProductsPageDriver(new UiContext(new OrderLogic(), new ProductLogic()));
            driver.Selected = () => (new List<ProductView>())[0];
            driver.ShowErrorMessage = (msg) => { messages.Add(msg); };

            driver.UpdateProduct();
            driver.DeleteProduct();

            Assert.Equal("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')", messages[0]);
            Assert.Equal("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')", messages[1]);
        }

        [Fact]
        public void TestExceptionMoveToProductPage()
        {
            List<string> messages = new List<string>();
            ProductsPageDriver driver = new ProductsPageDriver(new UiContext(new OrderLogic(), new ProductLogic()));
            driver.MoveToProductPage = null;
            driver.ShowErrorMessage = (msg) => { messages.Add(msg); };

            driver.AddProduct();

            Assert.Equal("Object reference not set to an instance of an object.", messages[0]);
        }
    }
}
