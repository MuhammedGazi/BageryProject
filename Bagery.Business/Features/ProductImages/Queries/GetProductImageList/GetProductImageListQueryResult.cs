using Bagery.Business.Features.Products.Queries.GetProductList;

namespace Bagery.Business.Features.ProductImages.Queries.GetProductImageList;

public record GetProductImageListQueryResult(int ProductImageId, string ImageUrl, string ImagePublicId, string ThumbnailUrl, int ProductId, GetProductListQueryResult Product);
