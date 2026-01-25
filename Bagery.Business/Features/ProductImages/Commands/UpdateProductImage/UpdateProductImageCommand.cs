using Bagery.Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Bagery.Business.Features.ProductImages.Commands.UpdateProductImage;

public class UpdateProductImageCommand : IRequest<IResult>
{
    public int ProductImageId { get; set; }
    public string ImageUrl { get; set; }
    public string ImagePublicId { get; set; }
    public string ThumbnailUrl { get; set; }
    public int ProductId { get; set; }
    public IFormFile ImageFile { get; set; }
}