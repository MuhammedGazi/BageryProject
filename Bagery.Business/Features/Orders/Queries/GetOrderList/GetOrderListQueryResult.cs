using Bagery.Core.Consts;
using Bagery.Core.Entities;

namespace Bagery.Business.Features.Orders.Queries.GetOrderList
{
    public record GetOrderListQueryResult(int Id, DateTime Date, decimal TotalPrice, OrderStatus OrderStatus, int CustomerId, AppUser Customer, ICollection<OrderDetail> OrderDetails);
}
