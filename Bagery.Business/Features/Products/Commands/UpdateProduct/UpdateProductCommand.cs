using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Products.Commands.UpdateProduct;

public record UpdateProductCommand(int ProductId, decimal Price, string Name, string Description, int CategoryId) : IRequest<IResult>;
