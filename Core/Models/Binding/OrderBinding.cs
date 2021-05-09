using System.Collections.Generic;

namespace Core.Models.Binding
{
    public class OrderBinding
    {
        public int Id { get; set; }

        public List<OrderProductBinding> OrderProducts { get; set; }
    }
}
