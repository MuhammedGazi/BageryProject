using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Products.Commands.CreateProduct;

public record CreateProductCommand(int ProductId, decimal Price, string Name, string Description, int CategoryId) : IRequest<IResult>;
