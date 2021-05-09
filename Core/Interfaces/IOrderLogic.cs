using Core.Models.Binding;
using Core.Models.View;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IOrderLogic
    {
        void Create(OrderBinding model);

        List<OrderView> Read(OrderBinding model);

        void Update(OrderBinding model);

        void Delete(OrderBinding model);
    }
}
