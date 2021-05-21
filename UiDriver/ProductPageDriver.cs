﻿using Core.Models.Binding;
using Core.Models.View;
using System;

namespace UiDriver
{
    public class ProductPageDriver : PageDriver
    {
        #region сustomizableMethods
        public Func<string> ProductName { get; set; }
        public Func<int> ProductPrice { get; set; }
        #endregion

        private ProductView product;

        public ProductPageDriver(UiContext context, ProductView product) : base(context)
        {
            this.product = product ?? new ProductView { Id = -1 };
        }

        public void Save()
        {
            ProductBinding model =
                new ProductBinding
                {
                    Id = product.Id,
                    Name = ProductName(),
                    Price = ProductPrice()
                };

            if (product.Id < 0)
            {
                context.ProductLogic.Create(model);
            }
            else
            {
                context.ProductLogic.Update(model);
            }
        }
    }
}
