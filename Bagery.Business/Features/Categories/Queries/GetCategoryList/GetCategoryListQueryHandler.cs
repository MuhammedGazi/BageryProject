using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler(IGenericRepository<Category> _repository) : IRequestHandler<GetCategoryListQuery, IDataResult<List<GetCategoryListQueryResult>>>
    {
        public async Task<IDataResult<List<GetCategoryListQueryResult>>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetAllAsync();
            var mappedResult = category.Adapt<List<GetCategoryListQueryResult>>();
            return new SuccessDataResult<List<GetCategoryListQueryResult>>(mappedResult, Messages.CategorysListed);
        }
    }
}
