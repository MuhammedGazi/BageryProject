using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.Services.Queries.GetServiceById
{
    public class GetServiceByIdQueryHandler(IGenericRepository<Service> _repository,
                                            ILogger<GetServiceByIdQueryHandler> _logger) : IRequestHandler<GetServiceByIdQuery, IDataResult<GetServiceByIdQueryResult>>
    {
        public async Task<IDataResult<GetServiceByIdQueryResult>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var service = await _repository.GetByIdAsync(request.Id);
            if (service == null)
            {
                _logger.LogError(Messages.ServiceNotFound, request.Id);
                return new ErrorDataResult<GetServiceByIdQueryResult>(Messages.ServiceNotFound);
            }
            var result = service.Adapt<GetServiceByIdQueryResult>();
            return new SuccessDataResult<GetServiceByIdQueryResult>(result, Messages.ServiceListed);
        }
    }
}
