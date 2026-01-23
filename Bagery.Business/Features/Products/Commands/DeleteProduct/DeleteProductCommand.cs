using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Products.Commands.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest<IResult>;
