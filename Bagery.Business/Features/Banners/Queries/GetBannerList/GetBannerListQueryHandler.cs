using MediatR;
using Bagery.Core.Utilities.Results;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bagery.Business.Features.Banners.Queries.GetBannerList
{
    public class GetBannerListQueryHandler(IGenericRepository<Banner> repository) : IRequestHandler<GetBannerListQuery, IDataResult<List<GetBannerListQueryResult>>>
    {
        public async Task<IDataResult<List<GetBannerListQueryResult>>> Handle(GetBannerListQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<List<GetBannerListQueryResult>>(null);
        }
    }
}
