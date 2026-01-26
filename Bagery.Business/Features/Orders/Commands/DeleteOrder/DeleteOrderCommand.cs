using MediatR;
using Bagery.Core.Utilities.Results;

namespace Bagery.Business.Features.Orders.Commands.DeleteOrder
{
    public record DeleteOrderCommand(int Id) : IRequest<IResult>;
}
