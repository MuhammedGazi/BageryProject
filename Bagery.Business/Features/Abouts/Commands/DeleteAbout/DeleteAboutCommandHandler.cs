using Bagery.Business.Constants;
using Bagery.Business.Services.CloudinaryServices;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Abouts.Commands.DeleteAbout
{
    public class DeleteAboutCommandHandler(IGenericRepository<About> _repository,
                                            IUnitOfWork _unitOfWork,
                                            ICloudinaryService _cloudinaryService) : IRequestHandler<DeleteAboutCommand, IResult>
    {
        public async Task<IResult> Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
        {
            var about = await _repository.GetByIdAsync(request.Id);
            if (!string.IsNullOrEmpty(about.ImagePublicId))
            {
                await _cloudinaryService.DeleteImageAsync(about.ImagePublicId);
            }
            _repository.Delete(about);
            return await _unitOfWork.SaveChangeAsync() ? new SuccessResult(Messages.AboutDeleted) : new ErrorResult(Messages.AboutDeletedFailed);
        }
    }
}
