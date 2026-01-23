namespace Bagery.Business.Features.Promotions.Queries.GetPromotionById;

public record GetPromotionByIdQueryResult(int PromotionId, string IconUrl, decimal Price, string Title, string Description);
