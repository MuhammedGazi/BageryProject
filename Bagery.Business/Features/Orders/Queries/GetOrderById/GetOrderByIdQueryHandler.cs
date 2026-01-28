using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler(IGenericRepository<Order> repository,
                                          ILogger<GetOrderByIdQueryHandler> _logger) : IRequestHandler<GetOrderByIdQuery, IDataResult<GetOrderByIdQueryResult>>
    {
        public async Task<IDataResult<GetOrderByIdQueryResult>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await repository.GetByIdAsync(request.Id);
            if (order == null)
            {
                _logger.LogError(Messages.OrderNotFound, request.Id);
                return new ErrorDataResult<GetOrderByIdQueryResult>(Messages.OrderNotFound);
            }
            var result = order.Adapt<GetOrderByIdQueryResult>();
            return new SuccessDataResult<GetOrderByIdQueryResult>(result, Messages.OrderListed);
        }
    }
}
