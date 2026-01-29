namespace Bagery.Business.Features.Banners.Queries.GetBannerList;

public record GetBannerListQueryResult(int BannerId, string Title, string Description, string? ImageUrl, string? ImagePublicId);
