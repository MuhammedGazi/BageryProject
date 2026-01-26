using MediatR;
using Bagery.Core.Utilities.Results;
using System.Collections.Generic;

namespace Bagery.Business.Features.Orders.Queries.GetOrderById
{
    public record GetOrderByIdQuery(int Id) : IRequest<IDataResult<GetOrderByIdQueryResult>>;
}
