using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.ThreeStepServices.Queries.GetThreeStepServiceList;

public record GetThreeStepServiceListQuery() : IRequest<IDataResult<List<GetThreeStepServiceListQueryResult>>>;
