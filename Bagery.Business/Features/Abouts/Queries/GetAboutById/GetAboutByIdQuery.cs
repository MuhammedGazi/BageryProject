using MediatR;
using Bagery.Core.Utilities.Results;
using System.Collections.Generic;

namespace Bagery.Business.Features.Abouts.Queries.GetAboutById
{
    public record GetAboutByIdQuery(int Id) : IRequest<IDataResult<GetAboutByIdQueryResult>>;
}
