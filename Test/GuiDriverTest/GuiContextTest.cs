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
            GuiContext<OrderLogic, ProductLogic> context = new GuiContext<OrderLogic, ProductLogic>();

            IOrderLogic logicO = context.OrderLogic;
            IProductLogic logicP = context.ProductLogic;

            Assert.IsType<OrderLogic>(logicO);
            Assert.IsType<ProductLogic>(logicP);
        }
    }
}
