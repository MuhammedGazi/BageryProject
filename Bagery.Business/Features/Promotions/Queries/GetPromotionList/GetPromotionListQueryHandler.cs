using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Promotions.Queries.GetPromotionList
{
    public class GetPromotionListQueryHandler(IGenericRepository<Promotion> _repository) : IRequestHandler<GetPromotionListQuery, IDataResult<List<GetPromotionListQueryResult>>>
    {
        public async Task<IDataResult<List<GetPromotionListQueryResult>>> Handle(GetPromotionListQuery request, CancellationToken cancellationToken)
        {
            var promotion = await _repository.GetAllAsync();
            var result = promotion.Adapt<List<GetPromotionListQueryResult>>();
            return new SuccessDataResult<List<GetPromotionListQueryResult>>(result, Messages.PromotionsListed);
        }
    }
}
