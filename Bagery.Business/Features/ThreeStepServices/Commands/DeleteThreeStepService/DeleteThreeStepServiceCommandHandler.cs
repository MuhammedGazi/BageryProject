using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.ThreeStepServices.Commands.DeleteThreeStepService
{
    public class DeleteThreeStepServiceCommandHandler(IGenericRepository<ThreeStepService> _repository,
                                                      IUnitOfWork _unitOfWork,
                                                      ILogger<DeleteThreeStepServiceCommandHandler> _logger) : IRequestHandler<DeleteThreeStepServiceCommand, IResult>
    {
        public async Task<IResult> Handle(DeleteThreeStepServiceCommand request, CancellationToken cancellationToken)
        {
            var tss = await _repository.GetByIdAsync(request.Id);
            if (tss is null)
            {
                _logger.LogError(Messages.TSServiceNotFound, request.Id);
                return new ErrorResult(Messages.TSServiceNotFound);
            }
            _repository.Delete(tss);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.TSServiceDeleted) : new ErrorResult(Messages.TSServiceDeletedFailed);
        }
    }
}
