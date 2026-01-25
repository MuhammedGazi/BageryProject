using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Services.Commands.UpdateService
{
    public class UpdateServiceCommandHandler(IGenericRepository<Service> _repository,
                                             IUnitOfWork _unitOfWork) : IRequestHandler<UpdateServiceCommand, IResult>
    {
        public async Task<IResult> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = request.Adapt<Service>();
            _repository.Update(service);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.ServiceUpdated) : new ErrorResult(Messages.ServiceUpdatedFailed);
        }
    }
}
