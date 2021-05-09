using System.Collections.Generic;
using System.Linq;

namespace Core.Models.View
{
    public class OrderView
    {
        public int Id { get; set; }

        public int Sum { get { return OrderProducts.Sum(rec => rec.Price * rec.Count); } }

        public List<OrderProductView> OrderProducts { get; set; }
    }
}
