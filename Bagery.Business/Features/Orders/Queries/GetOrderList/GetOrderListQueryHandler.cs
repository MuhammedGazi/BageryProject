using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryHandler(IGenericRepository<Order> repository) : IRequestHandler<GetOrderListQuery, IDataResult<List<GetOrderListQueryResult>>>
    {
        public async Task<IDataResult<List<GetOrderListQueryResult>>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<List<GetOrderListQueryResult>>("");
        }
    }
}
