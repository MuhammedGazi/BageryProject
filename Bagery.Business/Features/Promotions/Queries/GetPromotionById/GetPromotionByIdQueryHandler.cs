using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.Promotions.Queries.GetPromotionById
{
    public class GetPromotionByIdQueryHandler(IGenericRepository<Promotion> _repository,
                                              ILogger<GetPromotionByIdQueryHandler> _logger) : IRequestHandler<GetPromotionByIdQuery, IDataResult<GetPromotionByIdQueryResult>>
    {
        public async Task<IDataResult<GetPromotionByIdQueryResult>> Handle(GetPromotionByIdQuery request, CancellationToken cancellationToken)
        {
            var promotion = await _repository.GetByIdAsync(request.Id);
            if (promotion == null)
            {
                _logger.LogError(Messages.PromotionNotFound, request.Id);
                return new ErrorDataResult<GetPromotionByIdQueryResult>(Messages.PromotionNotFound);
            }
            var result = promotion.Adapt<GetPromotionByIdQueryResult>();
            return new SuccessDataResult<GetPromotionByIdQueryResult>(result, Messages.ProductListed);
        }
    }
}
