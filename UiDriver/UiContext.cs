using Core.Interfaces;

namespace UiDriver
{
    public class UiContext
    {
        public IOrderLogic OrderLogic { get; private set; }

        public IProductLogic ProductLogic { get; private set; }

        public UiContext(IOrderLogic orderLogic, IProductLogic productLogic)
        {
            OrderLogic = orderLogic;
            ProductLogic = productLogic;
        }
    }
}
