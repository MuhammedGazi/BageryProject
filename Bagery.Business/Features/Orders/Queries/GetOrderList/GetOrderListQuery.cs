using MediatR;
using Bagery.Core.Utilities.Results;
using System.Collections.Generic;

namespace Bagery.Business.Features.Orders.Queries.GetOrderList
{
    public record GetOrderListQuery() : IRequest<IDataResult<List<GetOrderListQueryResult>>>;
}
