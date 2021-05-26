﻿using Core.Models.Binding;
using Core.Models.View;
using System;

namespace UiDriver
{
    public class ProductPageDriver : PageDriver
    {
        #region сustomizableMethods
        public Func<string> ProductName { private get; set; }
        public Func<int> ProductPrice { private get; set; }
        #endregion

        private ProductView product;

        public ProductPageDriver(UiContext context, ProductView product) : base(context)
        {
            this.product = product ?? new ProductView { Id = -1, Name = "", Price = 0 };
        }

        public string GetName()
        {
            return product.Name;
        }

        public int GetPrice()
        {
            return product.Price;
        }

        public bool SaveProduct()
        {
            try
            {
                ProductBinding model =
                    new ProductBinding
                    {
                        Id = product.Id,
                        Name = ProductName(),
                        Price = ProductPrice()
                    };

                if (string.IsNullOrWhiteSpace(model.Name))
                {
                    throw new Exception("Field name is empty");
                }

                if (model.Price <= 0)
                {
                    throw new Exception("Incorrect price");
                }

                if (product.Id < 0)
                {
                    context.ProductLogic.Create(model);
                    ShowInfoMessage("Product was created");
                    return true;
                }
                else
                {
                    context.ProductLogic.Update(model);
                    ShowInfoMessage("Product №" + model.Id + " was updated");
                    return true;
                }
            }
            catch(Exception ex)
            {
                ShowErrorMessage(ex.Message);
                return false;
            }
        }
    }
}
