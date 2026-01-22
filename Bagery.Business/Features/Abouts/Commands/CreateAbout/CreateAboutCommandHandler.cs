using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Abouts.Commands.CreateAbout
{
    public class CreateAboutCommandHandler(IGenericRepository<About> _repository,
                                            IUnitOfWork _unitOfWork) : IRequestHandler<CreateAboutCommand, IResult>
    {
        public async Task<IResult> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = request.Adapt<About>();
            await _repository.CreateAsync(about);
            return await _unitOfWork.SaveChangeAsync() ? new SuccessResult(Messages.AboutAdded) : new ErrorResult(Messages.AboutAddedFailed);
        }
    }
}
