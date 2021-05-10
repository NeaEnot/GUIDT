using Core.Models.Binding;
using Core.Models.View;
using ListImplement.Implements;
using System.Collections.Generic;
using Xunit;

namespace Test.ListImplementTest
{
    public class ProductLogicTest
    {
        [Fact]
        public void TestRead()
        {
            ProductLogic logic = new ProductLogic();

            List<ProductView> list = logic.Read(null);

            Assert.Empty(list);
        }

        [Fact]
        public void TestCreate()
        {
            ProductLogic logic = new ProductLogic();

            try
            {
                ProductBinding model = new ProductBinding { Name = "Test", Price = 10 };
                logic.Create(model);

                List<ProductView> list = logic.Read(null);

                Assert.Single(list);
                Assert.Equal(1, list[0].Id);
                Assert.Equal("Test", list[0].Name);
                Assert.Equal(10, list[0].Price);
            }
            finally
            {
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestReadSingle()
        {
            ProductLogic logic = new ProductLogic();

            try
            {
                ProductBinding model1 = new ProductBinding { Name = "Test1", Price = 10 };
                ProductBinding model2 = new ProductBinding { Name = "Test2", Price = 20 };
                logic.Create(model1);
                logic.Create(model2);

                List<ProductView> list = logic.Read(new ProductBinding { Id = 1 });

                Assert.Single(list);
                Assert.Equal(1, list[0].Id);
                Assert.Equal("Test1", list[0].Name);
                Assert.Equal(10, list[0].Price);
            }
            finally
            {
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestUpdate()
        {
            ProductLogic logic = new ProductLogic();

            try
            {
                ProductBinding model1 = new ProductBinding { Name = "Test1", Price = 10 };
                logic.Create(model1);
                ProductBinding model2 = new ProductBinding { Id = 1, Name = "Test2", Price = 20 };
                logic.Update(model2);

                List<ProductView> list = logic.Read(null);

                Assert.Single(list);
                Assert.Equal(1, list[0].Id);
                Assert.Equal("Test2", list[0].Name);
                Assert.Equal(20, list[0].Price);
            }
            finally
            { 
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestDelete()
        {
            ProductLogic logic = new ProductLogic();

            try
            {
                ProductBinding model = new ProductBinding { Name = "Test", Price = 10 };
                logic.Create(model);
                logic.Delete(null);

                List<ProductView> list = logic.Read(null);

                Assert.Empty(list);
            }
            finally
            {
                logic.Delete(null);
            }
        }

        [Fact]
        public void TestDeleteSingle()
        {
            ProductLogic logic = new ProductLogic();

            try
            {
                ProductBinding model1 = new ProductBinding { Name = "Test1", Price = 10 };
                ProductBinding model2 = new ProductBinding { Name = "Test2", Price = 20 };
                logic.Create(model1);
                logic.Create(model2);
                logic.Delete(new ProductBinding { Id = 2 });

                List<ProductView> list = logic.Read(null);

                Assert.Single(list);
                Assert.Equal(1, list[0].Id);
                Assert.Equal("Test1", list[0].Name);
                Assert.Equal(10, list[0].Price);
            }
            finally
            {
                logic.Delete(null);
            }
        }
    }
}
