using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Services.Queries.GetServiceList
{
    public class GetServiceListQueryHandler(IGenericRepository<Service> _repository) : IRequestHandler<GetServiceListQuery, IDataResult<List<GetServiceListQueryResult>>>
    {
        public async Task<IDataResult<List<GetServiceListQueryResult>>> Handle(GetServiceListQuery request, CancellationToken cancellationToken)
        {
            var services = await _repository.GetAllAsync();
            var result = services.Adapt<List<GetServiceListQueryResult>>();
            return new SuccessDataResult<List<GetServiceListQueryResult>>(result, Messages.ServicesListed);
        }
    }
}
