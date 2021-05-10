using ListImplement.Models;
using System.Collections.Generic;

namespace ListImplement
{
    internal class ContextSingleton
    {
        private static ContextSingleton instance;

        internal List<Order> Orders { get; set; }

        internal List<OrderProduct> OrderProducts { get; set; }

        internal List<Product> Products { get; set; }

        private ContextSingleton()
        {
            Orders = new List<Order>();
            OrderProducts = new List<OrderProduct>();
            Products = new List<Product>();
        }

        internal static ContextSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new ContextSingleton();
            }

            return instance;
        }
    }
}
