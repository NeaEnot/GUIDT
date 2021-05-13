using Core.Attributes;

namespace Core.Models.View
{
    public class OrderProductView
    {
        [Column(title: "Номер", visible: false)]
        public int Id { get; set; }

        [Column(title: "Номер заказа", visible: false)]
        public int OrderId { get; set; }

        [Column(title: "Номер продукта", visible: false)]
        public int ProductId { get; set; }

        [Column(title: "Продукт", visible: true)]
        public string ProductName { get; set; }

        [Column(title: "Количество", visible: true)]
        public int Count { get; set; }

        [Column(title: "Цена шт.", visible: true)]
        public int Price { get; set; }
    }
}
