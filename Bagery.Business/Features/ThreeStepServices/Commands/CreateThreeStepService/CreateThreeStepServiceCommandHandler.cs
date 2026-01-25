using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.ThreeStepServices.Commands.CreateThreeStepService
{
    public class CreateThreeStepServiceCommandHandler(IGenericRepository<ThreeStepService> _repository,
                                                      IUnitOfWork _unitOfWork) : IRequestHandler<CreateThreeStepServiceCommand, IResult>
    {
        public async Task<IResult> Handle(CreateThreeStepServiceCommand request, CancellationToken cancellationToken)
        {
            var tss = request.Adapt<ThreeStepService>();
            await _repository.CreateAsync(tss);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.TSServiceAdded) : new ErrorResult(Messages.TSServiceAddedFailed);
        }
    }
}
