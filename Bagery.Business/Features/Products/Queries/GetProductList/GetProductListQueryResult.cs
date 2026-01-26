using Bagery.Business.Features.Categories.Queries.GetCategoryList;
using Bagery.Business.Features.ProductImages.Queries.GetProductImageList;

namespace Bagery.Business.Features.Products.Queries.GetProductList;

public record GetProductListQueryResult(int ProductId, decimal Price, string Name, string Description, GetCategoryListQueryResult Category, IList<GetProductImageListQueryResult> ProductImages);

