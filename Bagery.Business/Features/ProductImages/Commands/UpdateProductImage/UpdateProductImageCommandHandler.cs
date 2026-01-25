using Bagery.Business.Constants;
using Bagery.Business.Features.ProductImages.Commands.CreateProductImage;
using Bagery.Business.Services.CloudinaryServices;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.ProductImages.Commands.UpdateProductImage
{
    public class UpdateProductImageCommandHandler(IGenericRepository<ProductImage> repository,
                                                  ICloudinaryService _cloudinaryService,
                                                  ILogger<CreateProductImageCommandHandler> _logger,
                                                  IUnitOfWork _unitOfWork) : IRequestHandler<UpdateProductImageCommand, IResult>
    {
        public async Task<IResult> Handle(UpdateProductImageCommand request, CancellationToken cancellationToken)
        {
            var ýmage = await repository.GetByIdAsync(request.ProductImageId);
            var result = false;
            if (request.ImageFile != null)
            {
                if (!string.IsNullOrEmpty(request.ImagePublicId))
                {
                    await _cloudinaryService.DeleteImageAsync(ýmage.ImagePublicId);
                }
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
                repository.Update(ýmage);
                result = await _unitOfWork.SaveChangeAsync();
            }
            return result ? new SuccessResult(Messages.ProductImageUpdated) : new ErrorResult(Messages.ProductImageUpdatedFailed);
        }
    }
}
