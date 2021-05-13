using Core.Interfaces;

namespace GuiDriver
{
    public class GuiContext<O, P> 
        where O: IOrderLogic, new()
        where P: IProductLogic, new()
    {
        public IOrderLogic OrderLogic { get; private set; }

        public IProductLogic ProductLogic { get; private set; }

        public GuiContext()
        {
            OrderLogic = new O();
            ProductLogic = new P();
        }
    }
}
