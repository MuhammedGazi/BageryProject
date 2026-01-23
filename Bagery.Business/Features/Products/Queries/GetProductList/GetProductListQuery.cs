using MediatR;
using Bagery.Core.Utilities.Results;
using System.Collections.Generic;

namespace Bagery.Business.Features.Products.Queries.GetProductList
{
    public record GetProductListQuery() : IRequest<IDataResult<List<GetProductListQueryResult>>>;
}
