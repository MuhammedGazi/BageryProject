using Bagery.Business.Features.Products.Queries.GetProductList;

namespace Bagery.Business.Features.ProductImages.Queries.GetProductImageById;

public record GetProductImageByIdQueryResult(int ProductImageId, string ImageUrl, string ImagePublicId, string ThumbnailUrl, int ProductId, GetProductListQueryResult Product);
