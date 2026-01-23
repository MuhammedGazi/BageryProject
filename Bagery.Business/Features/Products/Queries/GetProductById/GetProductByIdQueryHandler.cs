using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler(IGenericRepository<Product> _repository,
                                            ILogger<GetProductByIdQueryHandler> _logger) : IRequestHandler<GetProductByIdQuery, IDataResult<GetProductByIdQueryResult>>
    {
        public async Task<IDataResult<GetProductByIdQueryResult>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);
            if (product is null)
            {
                _logger.LogError(Messages.ProductNotFound, request.Id);
                return new ErrorDataResult<GetProductByIdQueryResult>(Messages.ProductNotFound);
            }
            var result = product.Adapt<GetProductByIdQueryResult>();
            return new SuccessDataResult<GetProductByIdQueryResult>(result, Messages.ProductListed);
        }
    }
}
