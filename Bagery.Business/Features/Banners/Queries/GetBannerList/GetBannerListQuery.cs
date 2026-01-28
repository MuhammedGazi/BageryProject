using MediatR;
using Bagery.Core.Utilities.Results;
using System.Collections.Generic;

namespace Bagery.Business.Features.Banners.Queries.GetBannerList
{
    public record GetBannerListQuery() : IRequest<IDataResult<List<GetBannerListQueryResult>>>;
}
