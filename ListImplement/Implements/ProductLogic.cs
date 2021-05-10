using Core.Models.Binding;
using Core.Models.View;
using ListImplement.Models;
using System.Collections.Generic;
using System.Linq;

namespace ListImplement.Implements
{
    public class ProductLogic
    {
        private List<Product> products = new List<Product>();

        public void Create(ProductBinding model)
        {
            Product product = MapProduct(model);
            product.Id = products.Count > 0 ? products.Max(rec => rec.Id) + 1 : 1;
            products.Add(product);
        }

        public List<ProductView> Read(ProductBinding model)
        {
            return
                products
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => MapProductView(rec))
                .ToList();
        }

        private Product MapProduct(ProductBinding model)
        {
            return
                new Product 
                {
                    Name = model.Name, 
                    Price = model.Price 
                };
        }

        private ProductView MapProductView(Product product)
        {
            return
                 new ProductView
                 {
                     Id = product.Id,
                     Name = product.Name,
                     Price = product.Price
                 };
        }
    }
}
