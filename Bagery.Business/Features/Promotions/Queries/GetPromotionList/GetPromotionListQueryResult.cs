namespace Bagery.Business.Features.Promotions.Queries.GetPromotionList;

public record GetPromotionListQueryResult(int PromotionId, string IconUrl, decimal Price, string Title, string Description);
