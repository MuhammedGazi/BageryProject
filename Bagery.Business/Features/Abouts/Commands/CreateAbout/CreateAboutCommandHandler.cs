using Bagery.Business.Constants;
using Bagery.Business.Services.CloudinaryServices;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Abouts.Commands.CreateAbout
{
    public class CreateAboutCommandHandler(IGenericRepository<About> _repository,
                                            IUnitOfWork _unitOfWork,
                                            ICloudinaryService _cloudinaryService) : IRequestHandler<CreateAboutCommand, IResult>
    {
        public async Task<IResult> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = request.Adapt<About>();
            if (request.ImageFile is not null && request.ImageFile.Length > 0)
            {
                var image = await _cloudinaryService.UploadImageAsync(request.ImageFile, "About");
                about.ImagePublicId = image.PublicId;
                about.MainImageUrl = image.SecureUrl;
            }
            await _repository.CreateAsync(about);
            return await _unitOfWork.SaveChangeAsync() ? new SuccessResult(Messages.AboutAdded) : new ErrorResult(Messages.AboutAddedFailed);
        }
    }
}
