using Core.Models.View;
using System.Collections.Generic;

namespace GuiDriver.Models
{
    public class OrdersResponse
    {
        public List<OrderView> Orders { get; set; }

        public bool[] VisibleColumns { get; set; }
    }
}
