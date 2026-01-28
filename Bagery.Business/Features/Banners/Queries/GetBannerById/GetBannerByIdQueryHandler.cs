using MediatR;
using Bagery.Core.Utilities.Results;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bagery.Business.Features.Banners.Queries.GetBannerById
{
    public class GetBannerByIdQueryHandler(IGenericRepository<Banner> repository) : IRequestHandler<GetBannerByIdQuery, IDataResult<GetBannerByIdQueryResult>>
    {
        public async Task<IDataResult<GetBannerByIdQueryResult>> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<GetBannerByIdQueryResult>(null);
        }
    }
}
