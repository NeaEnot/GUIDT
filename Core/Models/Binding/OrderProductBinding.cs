﻿namespace Core.Models.Binding
{
    public class OrderProductBinding
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Count { get; set; }

        public int Price { get; set; }
    }
}