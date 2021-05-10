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
                ProductBinding model = new ProductBinding { Id = 1, Name = "Test", Price = 10 };
                logic.Create(model);

                List<ProductView> list = logic.Read(null);

                Assert.Single(list);
                Assert.Equal(1, list[0].Id);
                Assert.Equal("Test", list[0].Name);
                Assert.Equal(10, list[0].Price);
            }
            finally
            { }
        }
    }
}
