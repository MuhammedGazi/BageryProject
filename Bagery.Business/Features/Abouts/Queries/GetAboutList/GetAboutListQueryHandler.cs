using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Abouts.Queries.GetAboutList
{
    public class GetAboutListQueryHandler(IGenericRepository<About> _repository) : IRequestHandler<GetAboutListQuery, IDataResult<List<GetAboutListQueryResult>>>
    {
        public async Task<IDataResult<List<GetAboutListQueryResult>>> Handle(GetAboutListQuery request, CancellationToken cancellationToken)
        {
            var abouts = await _repository.GetAllAsync();
            var result = abouts.Adapt<List<GetAboutListQueryResult>>();
            return new SuccessDataResult<List<GetAboutListQueryResult>>(result, Messages.AboutsListed);
        }
    }
}
