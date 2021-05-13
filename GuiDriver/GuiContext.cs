using Core.Interfaces;

namespace GuiDriver
{
    public class GuiContext
    {
        public IOrderLogic OrderLogic { get; private set; }

        public IProductLogic ProductLogic { get; private set; }

        public GuiContext(IOrderLogic orderLogic, IProductLogic productLogic)
        {
            OrderLogic = orderLogic;
            ProductLogic = productLogic;
        }
    }
}
