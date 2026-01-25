using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.ThreeStepServices.Commands.UpdateThreeStepService
{
    public class UpdateThreeStepServiceCommandHandler(IGenericRepository<ThreeStepService> _repository,
                                                      IUnitOfWork _unitOfWork) : IRequestHandler<UpdateThreeStepServiceCommand, IResult>
    {
        public async Task<IResult> Handle(UpdateThreeStepServiceCommand request, CancellationToken cancellationToken)
        {
            var tss = request.Adapt<ThreeStepService>();
            _repository.Update(tss);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.TSServiceUpdated) : new ErrorResult(Messages.TSServiceUpdatedFailed);
        }
    }
}
