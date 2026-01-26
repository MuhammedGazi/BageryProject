using Bagery.Core.Consts;

namespace Bagery.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public int CustomerId { get; set; }
        public AppUser Customer { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
