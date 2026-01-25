using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Services.Queries.GetServiceById;

public record GetServiceByIdQuery(int Id) : IRequest<IDataResult<GetServiceByIdQueryResult>>;
