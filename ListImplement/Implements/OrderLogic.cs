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

            List<int> productIds = model.OrderProducts.GroupBy(rec => rec.ProductId).Select(rec => rec.Key).ToList();

            foreach (int productId in productIds)
            {
                List<OrderProductBinding> orderProducts = model.OrderProducts.Where(rec => rec.ProductId == productId).ToList();
                context.OrderProducts.Add(MapOrderProducts(orderProducts, order.Id));
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

            List<int> productIds = model.OrderProducts.GroupBy(rec => rec.ProductId).Select(rec => rec.Key).ToList();

            foreach (int productId in productIds)
            {
                OrderProduct orderProduct = context.OrderProducts.FirstOrDefault(rec => rec.OrderId == order.Id && rec.ProductId == productId);
                List<OrderProductBinding> orderProducts = model.OrderProducts.Where(rec => rec.ProductId == productId).ToList();
                OrderProduct newOrderProduct = MapOrderProducts(orderProducts, order.Id);

                if (orderProduct == null)
                {
                    context.OrderProducts.Add(newOrderProduct);
                }
                else
                {
                    orderProduct.Count = newOrderProduct.Count;
                    orderProduct.Price = newOrderProduct.Price;
                }
            }

            context.OrderProducts.RemoveAll(rec => rec.OrderId == order.Id && !productIds.Contains(rec.ProductId));
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

        private OrderProduct MapOrderProducts(List<OrderProductBinding> orderProducts, int orderId)
        {
            return
                new OrderProduct
                {
                    Id = context.OrderProducts.Count > 0 ? context.OrderProducts.Max(rec => rec.Id) + 1 : 1,
                    OrderId = orderId,
                    ProductId = orderProducts[0].ProductId,
                    Count = orderProducts.Sum(rec => rec.Count),
                    Price = orderProducts[0].Price
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
            Product product = context.Products.FirstOrDefault(rec => rec.Id == orderProduct.ProductId);

            return
                new OrderProductView
                {
                    Id = orderProduct.Id,
                    OrderId = orderProduct.OrderId,
                    ProductId = orderProduct.ProductId,
                    Count = orderProduct.Count,
                    Price = orderProduct.Price,
                    ProductName = product != null ? product.Name : "Undefined"
                };
        }
    }
}
