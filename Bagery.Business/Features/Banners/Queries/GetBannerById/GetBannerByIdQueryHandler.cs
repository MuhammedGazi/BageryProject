using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.Banners.Queries.GetBannerById
{
    public class GetBannerByIdQueryHandler(IGenericRepository<Banner> _repository,
                                            ILogger<GetBannerByIdQueryHandler> _logger) : IRequestHandler<GetBannerByIdQuery, IDataResult<GetBannerByIdQueryResult>>
    {
        public async Task<IDataResult<GetBannerByIdQueryResult>> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var banner = await _repository.GetByIdAsync(request.Id);
            if (banner == null)
            {
                _logger.LogError(Messages.BannerNotFound, request.Id);
                return new ErrorDataResult<GetBannerByIdQueryResult>(Messages.BannerNotFound);
            }
            var result = banner.Adapt<GetBannerByIdQueryResult>();
            return new SuccessDataResult<GetBannerByIdQueryResult>(result, Messages.BannerListed);
        }
    }
}
