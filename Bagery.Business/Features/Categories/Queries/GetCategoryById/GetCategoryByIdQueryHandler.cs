using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler(IGenericRepository<Category> _repository,
                                             ILogger<GetCategoryByIdQueryHandler> _logger) : IRequestHandler<GetCategoryByIdQuery, IDataResult<GetCategoryByIdQueryResult>>
    {
        public async Task<IDataResult<GetCategoryByIdQueryResult>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);
            if (category is null)
            {
                _logger.LogError(Messages.CategoryNotFound, request.Id);
                return new ErrorDataResult<GetCategoryByIdQueryResult>(Messages.CategoryNotFound);
            }
            var result = category.Adapt<GetCategoryByIdQueryResult>();
            return new SuccessDataResult<GetCategoryByIdQueryResult>(result, Messages.CategoryListed);
        }
    }
}
