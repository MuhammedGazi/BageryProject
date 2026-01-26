using Bagery.Business.Constants;
using Bagery.Business.Features.ProductImages.Queries.GetProductImageList;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using Bagery.Core.Utilities.Results;
using Mapster;
using MediatR;

namespace Bagery.Business.Features.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler(IGenericRepository<Product> repository) : IRequestHandler<GetProductListQuery, IDataResult<List<GetProductListQueryResult>>>
    {
        public async Task<IDataResult<List<GetProductListQueryResult>>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var product = await repository.GetAllAsync(x => x.Category, y => y.ProductImages);

            var config = new TypeAdapterConfig();
            config.NewConfig<ProductImage, GetProductImageListQueryResult>().MaxDepth(1);
            var result = product.Adapt<List<GetProductListQueryResult>>(config);
            return new SuccessDataResult<List<GetProductListQueryResult>>(result, Messages.ProductsListed);
        }
    }
}
