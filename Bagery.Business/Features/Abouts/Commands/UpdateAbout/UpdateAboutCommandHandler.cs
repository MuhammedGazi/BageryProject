using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Abouts.Commands.UpdateAbout
{
    public class UpdateAboutCommandHandler(IGenericRepository<About> _repository,
                                            IUnitOfWork _unitOfWork) : IRequestHandler<UpdateAboutCommand, IResult>
    {
        public async Task<IResult> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = request.Adapt<About>();
            _repository.Update(about);
            return await _unitOfWork.SaveChangeAsync() ? new SuccessResult(Messages.AboutUpdated) : new ErrorResult(Messages.AboutUpdatedFailed);
        }
    }
}
