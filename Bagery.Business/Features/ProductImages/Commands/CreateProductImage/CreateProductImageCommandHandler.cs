using Bagery.Business.Constants;
using Bagery.Business.Services.CloudinaryServices;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.ProductImages.Commands.CreateProductImage
{
    public class CreateProductImageCommandHandler(IGenericRepository<ProductImage> repository,
                                                  ICloudinaryService _cloudinaryService,
                                                  ILogger<CreateProductImageCommandHandler> _logger,
                                                  IUnitOfWork _unitOfWork) : IRequestHandler<CreateProductImageCommand, IResult>
    {
        public async Task<IResult> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
        {
            ProductImage ýmage = new ProductImage();
            var result = false;
            if (request.ImageFile != null)
            {
                var uploadResult = await _cloudinaryService.UploadImageAsync(request.ImageFile, "products");
                if (uploadResult.Success)
                {
                    request.ImagePublicId = uploadResult.PublicId;
                    request.ImageUrl = uploadResult.SecureUrl;
                    request.ThumbnailUrl = _cloudinaryService.GetThumbnailUrl(uploadResult.PublicId, 200);
                }
                else
                {
                    _logger.LogError(Messages.ProductImageAddedFailed, request.ImageFile.Name);
                    return new ErrorResult(Messages.ProductImageAddedFailed);
                }
                ýmage.ImageUrl = request.ImageUrl;
                ýmage.ImagePublicId = request.ImagePublicId;
                ýmage.ThumbnailUrl = request.ThumbnailUrl;
                ýmage.ProductId = request.ProductId;
                await repository.CreateAsync(ýmage);
                result = await _unitOfWork.SaveChangeAsync();
            }
            return result ? new SuccessResult(Messages.ProductImageAdded) : new ErrorResult(Messages.ProductImageAddedFailed);
        }
    }
}
