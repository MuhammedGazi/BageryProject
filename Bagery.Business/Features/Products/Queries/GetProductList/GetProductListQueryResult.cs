using Bagery.Business.Features.Categories.Queries.GetCategoryList;

namespace Bagery.Business.Features.Products.Queries.GetProductList;

public record GetProductListQueryResult(int ProductId, decimal Price, string Name, string Description, GetCategoryListQueryResult Category);

//IList<ProductImage> ProductImages