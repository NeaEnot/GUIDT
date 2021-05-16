using Core.Interfaces;
using UiDriver;
using ListImplement.Implements;
using Xunit;

namespace Test.GuiDriverTest
{
    public class UiContextTest
    {
        [Fact]
        public void TestGuiContext()
        {
            UiContext context = new UiContext(new OrderLogic(), new ProductLogic());

            IOrderLogic logicO = context.OrderLogic;
            IProductLogic logicP = context.ProductLogic;

            Assert.IsType<OrderLogic>(logicO);
            Assert.IsType<ProductLogic>(logicP);
        }
    }
}
