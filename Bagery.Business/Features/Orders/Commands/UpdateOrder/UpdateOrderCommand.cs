using Bagery.Business.DTOs.OrderDTOs;
using Bagery.Core.Consts;
using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Orders.Commands.UpdateOrder
{
    public record UpdateOrderCommand(int Id, DateTime Date, decimal TotalPrice, OrderStatus OrderStatus, int CustomerId, ICollection<OrderItemDto> OrderDetails) : IRequest<IResult>;
}
