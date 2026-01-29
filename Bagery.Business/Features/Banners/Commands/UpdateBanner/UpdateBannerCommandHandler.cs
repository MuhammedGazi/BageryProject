using Bagery.Business.Constants;
using Bagery.Business.Services.CloudinaryServices;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.Banners.Commands.UpdateBanner
{
    public class UpdateBannerCommandHandler(IGenericRepository<Banner> _repository,
                                            IUnitOfWork _unitOfWork,
                                            ILogger<UpdateBannerCommandHandler> _logger,
                                            ICloudinaryService _cloudinaryService) : IRequestHandler<UpdateBannerCommand, IResult>
    {
        public async Task<IResult> Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var dBbanner = await _repository.GetByIdAsync(request.BannerId);
            if (dBbanner is null)
            {
                _logger.LogError(Messages.BannerNotFound, request.BannerId);
                return new ErrorResult(Messages.BannerNotFound);
            }
            request.Adapt(dBbanner);
            if (request.Image is not null && request.Image.Length > 0)
            {
                var uploadResult = await _cloudinaryService.UploadImageAsync(request.Image, "Banner");
                if (uploadResult.Success)
                {
                    if (!string.IsNullOrEmpty(dBbanner.ImagePublicId))
                    {
                        await _cloudinaryService.DeleteImageAsync(dBbanner.ImagePublicId);
                    }
                    dBbanner.ImagePublicId = uploadResult.PublicId;
                    dBbanner.ImageUrl = uploadResult.SecureUrl;
                }
            }
            _repository.Update(dBbanner);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.BannerUpdated) : new ErrorResult(Messages.BannerUpdatedFailed);
        }
    }
}
