using Bagery.Business.Constants;
using Bagery.Business.Features.Products.Queries.GetProductList;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bagery.Business.Features.ProductImages.Queries.GetProductImageList
{
    public class GetProductImageListQueryHandler(IGenericRepository<ProductImage> repository) : IRequestHandler<GetProductImageListQuery, IDataResult<List<GetProductImageListQueryResult>>>
    {
        public async Task<IDataResult<List<GetProductImageListQueryResult>>> Handle(GetProductImageListQuery request, CancellationToken cancellationToken)
        {
            var photo = await repository.GetAllAsync(q => q.Include(x => x.Product).ThenInclude(x => x.Category).AsSplitQuery());

            var config = new TypeAdapterConfig();
            config.NewConfig<ProductImage, GetProductImageListQueryResult>();
            config.NewConfig<Product, GetProductListQueryResult>()
                  .Map(dest => dest.ProductImages, src => (IList<GetProductImageListQueryResult>)null);
            var result = photo.Adapt<List<GetProductImageListQueryResult>>(config);

            return new SuccessDataResult<List<GetProductImageListQueryResult>>(result, Messages.ProductImagesListed);
        }
    }
}
