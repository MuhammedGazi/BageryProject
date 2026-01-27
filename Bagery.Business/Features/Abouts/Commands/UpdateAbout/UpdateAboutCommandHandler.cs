using Bagery.Business.Constants;
using Bagery.Business.Services.CloudinaryServices;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Abouts.Commands.UpdateAbout
{
    public class UpdateAboutCommandHandler(IGenericRepository<About> _repository,
                                            IUnitOfWork _unitOfWork,
                                            ICloudinaryService _cloudinaryService) : IRequestHandler<UpdateAboutCommand, IResult>
    {
        public async Task<IResult> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var dbAbout = await _repository.GetByIdAsync(request.AboutId);
            request.Adapt(dbAbout);
            if (request.Image is not null && request.Image.Length > 0)
            {
                var uploadResult = await _cloudinaryService.UploadImageAsync(request.Image, "About");

                if (uploadResult.Success)
                {
                    if (!string.IsNullOrEmpty(dbAbout.ImagePublicId))
                    {
                        await _cloudinaryService.DeleteImageAsync(dbAbout.ImagePublicId);
                    }
                    dbAbout.ImagePublicId = uploadResult.PublicId;
                    dbAbout.MainImageUrl = uploadResult.SecureUrl;
                }
            }
            _repository.Update(dbAbout);

            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.AboutUpdated) : new ErrorResult(Messages.AboutUpdatedFailed);
        }
    }
}
