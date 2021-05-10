using ListImplement.Models;
using System.Collections.Generic;

namespace ListImplement
{
    internal class ContextSingleton
    {
        //private static ContextSingleton instance;

        public List<Order> Orders { get; set; }

        private ContextSingleton()
        {
            Orders = new List<Order>();
        }

        public static ContextSingleton GetInstance()
        {
            return new ContextSingleton();
            //if (instance == null)
            //{
            //    instance = new ContextSingleton();
            //}

            //return instance;
        }
    }
}
