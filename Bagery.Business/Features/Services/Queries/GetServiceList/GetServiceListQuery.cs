using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Services.Queries.GetServiceList;

public record GetServiceListQuery() : IRequest<IDataResult<List<GetServiceListQueryResult>>>;
