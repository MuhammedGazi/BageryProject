using Bagery.Business.Constants;
using Bagery.Business.Services.CloudinaryServices;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.Banners.Commands.DeleteBanner
{
    public class DeleteBannerCommandHandler(IGenericRepository<Banner> _repository,
                                            IUnitOfWork _unitOfWork,
                                            ILogger<DeleteBannerCommandHandler> _logger,
                                            ICloudinaryService _cloudinaryService) : IRequestHandler<DeleteBannerCommand, IResult>
    {
        public async Task<IResult> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _repository.GetByIdAsync(request.Id);
            if (banner is null)
            {
                _logger.LogError(Messages.BannerNotFound, request.Id);
                return new ErrorResult(Messages.BannerNotFound);
            }
            if (!string.IsNullOrEmpty(banner.ImagePublicId))
            {
                await _cloudinaryService.DeleteImageAsync(banner.ImagePublicId);
            }
            _repository.Delete(banner);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.BannerDeleted) : new ErrorResult(Messages.BannerDeletedFailed);
        }
    }
}
