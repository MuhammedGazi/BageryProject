using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Services.Commands.CreateService
{
    public class CreateServiceCommandHandler(IGenericRepository<Service> _repository,
                                             IUnitOfWork _unitOfWork) : IRequestHandler<CreateServiceCommand, IResult>
    {
        public async Task<IResult> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = request.Adapt<Service>();
            await _repository.CreateAsync(service);
            var result = await _unitOfWork.SaveChangeAsync();
            return result ? new SuccessResult(Messages.ServiceAdded) : new ErrorResult(Messages.ServiceAddedFailed);
        }
    }
}
