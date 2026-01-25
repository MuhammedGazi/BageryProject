using Bagery.Business.Constants;
using Bagery.Business.Features.ProductImages.Queries.GetProductImageById;
using Bagery.Business.Services.CloudinaryServices;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Bagery.Business.Features.ProductImages.Commands.DeleteProductImage
{
    public class DeleteProductImageCommandHandler(IGenericRepository<ProductImage> repository,
                                                  IUnitOfWork _unitOfWork,
                                                  ILogger<DeleteProductImageCommandHandler> _logger,
                                                  ICloudinaryService _cloudinaryService) : IRequestHandler<DeleteProductImageCommand, IResult>
    {
        public async Task<IResult> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            var photo = await repository.GetByIdAsync(request.Id);
            if (photo is null)
            {
                _logger.LogError(Messages.ProductImageNotFound, request.Id);
                return new ErrorDataResult<GetProductImageByIdQueryResult>(Messages.ProductImageNotFound);
            }

            await _cloudinaryService.DeleteImageAsync(photo.ImagePublicId);
            repository.Delete(photo);
            var result = await _unitOfWork.SaveChangeAsync();
            return result? new SuccessResult(Messages.ProductDeleted):new ErrorResult(Messages.ProductDeletedFailed);
        }
    }
}
