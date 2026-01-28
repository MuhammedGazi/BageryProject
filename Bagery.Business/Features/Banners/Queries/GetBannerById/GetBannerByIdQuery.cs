using MediatR;
using Bagery.Core.Utilities.Results;
using System.Collections.Generic;

namespace Bagery.Business.Features.Banners.Queries.GetBannerById
{
    public record GetBannerByIdQuery(int Id) : IRequest<IDataResult<GetBannerByIdQueryResult>>;
}
