using Bagery.Business.Constants;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.ProductImages.Queries.GetProductImageList
{
    public class GetProductImageListQueryHandler(IGenericRepository<ProductImage> repository) : IRequestHandler<GetProductImageListQuery, IDataResult<List<GetProductImageListQueryResult>>>
    {
        public async Task<IDataResult<List<GetProductImageListQueryResult>>> Handle(GetProductImageListQuery request, CancellationToken cancellationToken)
        {
            var photo = await repository.GetAllAsync(x => x.Product);

            var config = new TypeAdapterConfig();
            config.NewConfig<ProductImage, GetProductImageListQueryResult>().MaxDepth(1);
            var result = photo.Adapt<List<GetProductImageListQueryResult>>(config);

            return new SuccessDataResult<List<GetProductImageListQueryResult>>(result, Messages.ProductImagesListed);
        }
    }
}
