using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Contacts.Queries.GetContactById;

public record GetContactByIdQuery(int Id) : IRequest<IDataResult<GetContactByIdQueryResult>>;
