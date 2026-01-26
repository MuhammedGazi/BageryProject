using Bagery.Business.DTOs.OrderDTOs;
using Bagery.Core.Consts;
using Bagery.Core.Entities;

namespace Bagery.Business.Features.Orders.Queries.GetOrderById
{
    public record GetOrderByIdQueryResult(int Id, DateTime Date, decimal TotalPrice, OrderStatus OrderStatus, int CustomerId, AppUser Customer, ICollection<OrderItemDto> OrderDetails);
}
