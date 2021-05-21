using Core.Interfaces;

namespace UiDriver
{
    public class UiContext
    {
        internal IOrderLogic OrderLogic { get; private set; }

        internal IProductLogic ProductLogic { get; private set; }

        public UiContext(IOrderLogic orderLogic, IProductLogic productLogic)
        {
            OrderLogic = orderLogic;
            ProductLogic = productLogic;
        }
    }
}
