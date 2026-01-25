using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.ProductImages.Commands.DeleteProductImage;

public record DeleteProductImageCommand(int Id) : IRequest<IResult>;
