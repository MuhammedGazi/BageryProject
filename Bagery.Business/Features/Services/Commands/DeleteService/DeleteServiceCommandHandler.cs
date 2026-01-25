using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.Services.Commands.DeleteService
{
    public class DeleteServiceCommandHandler(IGenericRepository<Service> _repository,
                                             IUnitOfWork _unitOfWork,
                                             ILogger<DeleteServiceCommandHandler> _logger) : IRequestHandler<DeleteServiceCommand, IResult>
    {
        public async Task<IResult> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _repository.GetByIdAsync(request.Id);
            if (service == null)
            {
                _logger.LogError(Messages.ServiceNotFound, request.Id);
                return new ErrorResult(Messages.ServiceNotFound);
            }
            _repository.Delete(service);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.ServiceDeleted) : new ErrorResult(Messages.ServiceDeletedFailed);
        }
    }
}
