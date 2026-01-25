using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.ThreeStepServices.Queries.GetThreeStepServiceList
{
    public class GetThreeStepServiceListQueryHandler(IGenericRepository<ThreeStepService> _repository) : IRequestHandler<GetThreeStepServiceListQuery, IDataResult<List<GetThreeStepServiceListQueryResult>>>
    {
        public async Task<IDataResult<List<GetThreeStepServiceListQueryResult>>> Handle(GetThreeStepServiceListQuery request, CancellationToken cancellationToken)
        {
            var tss = await _repository.GetAllAsync();
            var result = tss.Adapt<List<GetThreeStepServiceListQueryResult>>();
            return new SuccessDataResult<List<GetThreeStepServiceListQueryResult>>(result, Messages.TSServicesListed);
        }
    }
}
