namespace UiDriver
{
    public class OrderPageDriver
    {
        public int? orderId;

        public OrderPageDriver(UiContext context, int? orderId)
        {
            this.orderId = orderId;
        }
    }
}
