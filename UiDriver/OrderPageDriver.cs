using Core.Models.View;

namespace UiDriver
{
    public class OrderPageDriver
    {
        public OrderView order;

        public OrderPageDriver(UiContext context, OrderView order)
        {
            this.order = order;
        }
    }
}
