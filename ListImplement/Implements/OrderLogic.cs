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
            foreach (OrderProductBinding orderProduct in model.OrderProducts)
            {
                context.OrderProducts.Add(MapOrderProduct(orderProduct));
            }
        }

        public List<OrderView> Read(OrderBinding model)
        {
            return 
                context.Orders
                .Select(rec => MapOrderView(rec))
                .ToList();
        }

        private OrderProduct MapOrderProduct(OrderProductBinding orderProduct)
        {
            return
                new OrderProduct
                {
                    Id = orderProduct.Id,
                    OrderId = orderProduct.OrderId,
                    ProductId = orderProduct.ProductId,
                    Count = orderProduct.Count,
                    Price = orderProduct.Price
                };
        }

        private OrderView MapOrderView(Order order)
        {
            return
                new OrderView
                {
                    Id = order.Id,
                    OrderProducts =
                        context.OrderProducts
                        .Where(rec => rec.OrderId == order.Id)
                        .Select(rec => MapOrderProductView(rec))
                        .ToList()
                };
        }

        private OrderProductView MapOrderProductView(OrderProduct orderProduct)
        {
            return
                new OrderProductView
                {
                    Id = orderProduct.Id,
                    OrderId = orderProduct.OrderId,
                    ProductId = orderProduct.ProductId,
                    Count = orderProduct.Count,
                    Price = orderProduct.Price
                };
        }
    }
}
