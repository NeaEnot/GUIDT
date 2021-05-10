using Core.Models.Binding;
using Core.Models.View;
using ListImplement.Models;
using System.Collections.Generic;
using System.Linq;

namespace ListImplement.Implements
{
    public class ProductLogic
    {
        private ContextSingleton context = ContextSingleton.GetInstance();

        public void Create(ProductBinding model)
        {
            Product product = MapProduct(model);
            product.Id = context.Products.Count > 0 ? context.Products.Max(rec => rec.Id) + 1 : 1;
            context.Products.Add(product);
        }

        public List<ProductView> Read(ProductBinding model)
        {
            return
                context.Products
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => MapProductView(rec))
                .ToList();
        }

        public void Update(ProductBinding model)
        {
            Product product = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
            if (product != null)
            {
                product.Name = model.Name;
                product.Price = model.Price;
            }
        }

        public void Delete(ProductBinding model)
        {
            context.Products.RemoveAll(rec => model == null || rec.Id == model.Id);
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
