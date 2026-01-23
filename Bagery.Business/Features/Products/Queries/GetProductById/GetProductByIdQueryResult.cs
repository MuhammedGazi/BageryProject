namespace Bagery.Business.Features.Products.Queries.GetProductById;

public record GetProductByIdQueryResult(int ProductId, decimal Price, string Name, string Description, int CategoryId);
