using MediatR;
using Bagery.Core.Utilities.Results;
using System.Collections.Generic;

namespace Bagery.Business.Features.Abouts.Queries.GetAboutList
{
    public record GetAboutListQuery() : IRequest<IDataResult<List<GetAboutListQueryResult>>>;
}
