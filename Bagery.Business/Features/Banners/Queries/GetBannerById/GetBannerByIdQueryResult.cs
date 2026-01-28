using System;

namespace Bagery.Business.Features.Banners.Queries.GetBannerById
{
    public record GetBannerByIdQueryResult(int BannerId, string Title, string Description, string? ImageUrl, string? ImagePublicId);
}
