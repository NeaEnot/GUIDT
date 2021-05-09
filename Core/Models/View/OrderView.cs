using System.Collections.Generic;

namespace Core.Models.View
{
    public class OrderView
    {
        public int Id { get; set; }

        public int Sum { get; set; }

        public List<OrderProductView> OrderProducts { get; set; }
    }
}
