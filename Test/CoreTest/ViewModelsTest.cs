using Core.Models.View;
using Xunit;

namespace Test.CoreTest
{
    public class ViewModelsTest
    {
        [Fact]
        public void TestProductView()
        {
            ProductView pv = new ProductView { Id = 0, Name = "Test", Price = 100 };

            Assert.Equal(0, pv.Id);
            Assert.Equal("Test", pv.Name);
            Assert.Equal(100, pv.Price);
        }

        [Fact]
        public void TestOrderView()
        {
            OrderView ov = new OrderView { Id = 0, Sum = 1000 };

            Assert.Equal(0, ov.Id);
            Assert.Equal(1000, ov.Sum);
        }
    }
}
