using Core.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Core.Models.View
{
    public class OrderView
    {
        [Column(title: "Номер", visible: true)]
        public int Id { get; set; }

        [Column(title: "Сумма", visible: true)]
        public int Sum { get { return OrderProducts.Sum(rec => rec.Price * rec.Count); } }

        public List<OrderProductView> OrderProducts { get; set; }

        public OrderView()
        {
            OrderProducts = new List<OrderProductView>();
        }
    }
}
