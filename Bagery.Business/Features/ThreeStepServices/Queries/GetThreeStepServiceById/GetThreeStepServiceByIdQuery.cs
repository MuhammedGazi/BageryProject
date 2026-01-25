using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.ThreeStepServices.Queries.GetThreeStepServiceById;

public record GetThreeStepServiceByIdQuery(int Id) : IRequest<IDataResult<GetThreeStepServiceByIdQueryResult>>;
