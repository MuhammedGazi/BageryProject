using Bagery.Core.Consts;
using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Orders.Commands.UpdateOrder
{
    public record UpdateOrderCommand(int Id, OrderStatus OrderStatus) : IRequest<IResult>;
}
