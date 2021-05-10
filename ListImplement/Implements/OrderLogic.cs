using Core.Interfaces;
using Core.Models.Binding;
using Core.Models.View;
using ListImplement.Models;
using System.Collections.Generic;
using System.Linq;

namespace ListImplement.Implements
{
    public class OrderLogic: IOrderLogic
    {
        private ContextSingleton context = ContextSingleton.GetInstance();

        public void Create(OrderBinding model)
        {
            Order order = new Order { Id = context.Orders.Count > 0 ? context.Orders.Max(rec => rec.Id) + 1 : 1 };
            context.Orders.Add(order);

            foreach (OrderProductBinding orderProduct in model.OrderProducts)
            {
                context.OrderProducts.Add(MapOrderProduct(orderProduct, order.Id));
            }
        }

        public List<OrderView> Read(OrderBinding model)
        {
            return 
                context.Orders
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => MapOrderView(rec))
                .ToList();
        }

        public void Update(OrderBinding model)
        {
            Order order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

            if (order == null)
            {
                return;
            }

            List<int> ids = new List<int>();

            foreach (OrderProductBinding op in model.OrderProducts)
            {
                OrderProduct orderProduct = context.OrderProducts.FirstOrDefault(rec => rec.OrderId == order.Id && rec.ProductId == op.ProductId);
                if (orderProduct == null)
                {
                    context.OrderProducts.Add(MapOrderProduct(op, order.Id));
                }
                else
                {
                    orderProduct.ProductId = op.ProductId;
                    orderProduct.Count = op.Count;
                    orderProduct.Price = op.Price;
                }

                ids.Add(op.ProductId);
            }

            context.OrderProducts.RemoveAll(rec => rec.OrderId == order.Id && !ids.Contains(rec.ProductId));
        }

        public void Delete(OrderBinding model)
        {
            List<Order> orders = context.Orders.Where(rec => model == null || rec.Id == model.Id).ToList();

            foreach (Order order in orders)
            {
                context.Orders.Remove(order);
                context.OrderProducts.RemoveAll(rec => rec.OrderId == order.Id);
            }
        }

        private OrderProduct MapOrderProduct(OrderProductBinding orderProduct, int orderId)
        {
            return
                new OrderProduct
                {
                    Id = context.OrderProducts.Count > 0 ? context.OrderProducts.Max(rec => rec.Id) + 1 : 1,
                    OrderId = orderId,
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
