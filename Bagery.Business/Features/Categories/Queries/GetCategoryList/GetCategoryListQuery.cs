using MediatR;
using Bagery.Core.Utilities.Results;
using System.Collections.Generic;

namespace Bagery.Business.Features.Categories.Queries.GetCategoryList
{
    public record GetCategoryListQuery() : IRequest<IDataResult<List<GetCategoryListQueryResult>>>;
}
