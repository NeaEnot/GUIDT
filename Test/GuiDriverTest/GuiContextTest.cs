using Core.Interfaces;
using GuiDriver;
using ListImplement.Implements;
using Xunit;

namespace Test.GuiDriverTest
{
    public class GuiContextTest
    {
        [Fact]
        public void TestGuiContext()
        {
            GuiContext context = new GuiContext(new OrderLogic(), new ProductLogic());

            IOrderLogic logicO = context.OrderLogic;
            IProductLogic logicP = context.ProductLogic;

            Assert.IsType<OrderLogic>(logicO);
            Assert.IsType<ProductLogic>(logicP);
        }
    }
}
