using Core.Models.View;
using Xunit;

namespace Test.CoreTest
{
    public class ProductViewTest
    {
        [Fact]
        public void TestModel()
        {
            ProductView pv = new ProductView { Name = "Test", Price = 100 };

            Assert.Equal("Test", pv.Name);
            Assert.Equal(100, pv.Price);
        }
    }
}
