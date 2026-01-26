using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler(IGenericRepository<Order> repository) : IRequestHandler<GetOrderByIdQuery, IDataResult<GetOrderByIdQueryResult>>
    {
        public async Task<IDataResult<GetOrderByIdQueryResult>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<GetOrderByIdQueryResult>("");
        }
    }
}
