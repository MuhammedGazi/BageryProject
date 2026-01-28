using Bagery.Business.Constants;
using Bagery.Business.Services.CloudinaryServices;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Banners.Commands.CreateBanner
{
    public class CreateBannerCommandHandler(IGenericRepository<Banner> repository,
                                            IUnitOfWork _unitOfWork,
                                            ICloudinaryService _cloudinaryService) : IRequestHandler<CreateBannerCommand, IResult>
    {
        public async Task<IResult> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = request.Adapt<Banner>();
            if (request.ImageFile != null && request.ImageFile.Length > 0)
            {
                var urlData = await _cloudinaryService.UploadImageAsync(request.ImageFile, "Banner");
                banner.ImagePublicId = urlData.PublicId;
                banner.ImageUrl = urlData.SecureUrl;
            }
            await repository.CreateAsync(banner);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.BannerAdded) : new ErrorResult(Messages.BannerAddedFailed);
        }
    }
}
