using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.ThreeStepServices.Queries.GetThreeStepServiceById
{
    public class GetThreeStepServiceByIdQueryHandler(IGenericRepository<ThreeStepService> _repository,
                                                     ILogger<GetThreeStepServiceByIdQueryHandler> _logger) : IRequestHandler<GetThreeStepServiceByIdQuery, IDataResult<GetThreeStepServiceByIdQueryResult>>
    {
        public async Task<IDataResult<GetThreeStepServiceByIdQueryResult>> Handle(GetThreeStepServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var tss = await _repository.GetByIdAsync(request.Id);
            if (tss == null)
            {
                _logger.LogError(Messages.TSServiceNotFound, request.Id);
                return new ErrorDataResult<GetThreeStepServiceByIdQueryResult>(Messages.TSServiceNotFound);
            }
            var result = tss.Adapt<GetThreeStepServiceByIdQueryResult>();
            return new SuccessDataResult<GetThreeStepServiceByIdQueryResult>(result, Messages.TSServiceListed);
        }
    }
}
