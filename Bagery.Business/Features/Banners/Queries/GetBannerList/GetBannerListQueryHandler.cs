using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Banners.Queries.GetBannerList
{
    public class GetBannerListQueryHandler(IGenericRepository<Banner> _repository) : IRequestHandler<GetBannerListQuery, IDataResult<List<GetBannerListQueryResult>>>
    {
        public async Task<IDataResult<List<GetBannerListQueryResult>>> Handle(GetBannerListQuery request, CancellationToken cancellationToken)
        {
            var banners = await _repository.GetAllAsync();
            var result = banners.Adapt<List<GetBannerListQueryResult>>();
            return new SuccessDataResult<List<GetBannerListQueryResult>>(result, Messages.BannersListed);
        }
    }
}
