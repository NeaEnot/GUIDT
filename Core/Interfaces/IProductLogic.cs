using Core.Models.Binding;
using Core.Models.View;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IProductLogic
    {
        void Create(ProductBinding model);

        List<ProductView> Read(ProductBinding model);

        void Update(ProductBinding model);

        void Delete(ProductBinding model);
    }
}
