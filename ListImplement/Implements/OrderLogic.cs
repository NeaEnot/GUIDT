using Core.Models.Binding;
using Core.Models.View;
using ListImplement.Models;
using System.Collections.Generic;
using System.Linq;

namespace ListImplement.Implements
{
    public class OrderLogic
    {
        private ContextSingleton context = ContextSingleton.GetInstance();

        public void Create(OrderBinding model)
        {
            context.Orders.Add(new Order { Id = model.Id });
        }

        public List<OrderView> Read(OrderBinding model)
        {
            return 
                context.Orders
                .Select(rec => new OrderView { Id = rec.Id })
                .ToList();
        }
    }
}
