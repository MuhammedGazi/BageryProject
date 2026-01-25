using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bagery.Business.Features.ProductImages.Queries.GetProductImageById
{
    public class GetProductImageByIdQueryHandler(IGenericRepository<ProductImage> repository,
                                                 ILogger<GetProductImageByIdQueryHandler> _logger) : IRequestHandler<GetProductImageByIdQuery, IDataResult<GetProductImageByIdQueryResult>>
    {
        public async Task<IDataResult<GetProductImageByIdQueryResult>> Handle(GetProductImageByIdQuery request, CancellationToken cancellationToken)
        {
            var photo = await repository.GetByIdAsync(request.Id);
            if (photo is null)
            {
                _logger.LogError(Messages.ProductImageNotFound, request.Id);
                return new ErrorDataResult<GetProductImageByIdQueryResult>(Messages.ProductImageNotFound);
            }
            var result = photo.Adapt<GetProductImageByIdQueryResult>();
            return new SuccessDataResult<GetProductImageByIdQueryResult>(result, Messages.ProductImageListed);
        }
    }
}
