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

            try
            {
                List<ProductView> list = logic.Read(null);

                Assert.Empty(list);
            }
            finally
            { }
        }
    }
}
