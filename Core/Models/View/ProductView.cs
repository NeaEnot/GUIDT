using Core.Attributes;

namespace Core.Models.View
{
    public class ProductView
    {
        [Column(title: "Номер", visible: true)]
        public int Id { get; set; }

        [Column(title: "Название", visible: true)]
        public string Name { get; set; }

        [Column(title: "Цена", visible: true)]
        public int Price { get; set; }
    }
}
