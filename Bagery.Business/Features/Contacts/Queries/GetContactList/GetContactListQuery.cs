using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Contacts.Queries.GetContactList;

public record GetContactListQuery() : IRequest<IDataResult<List<GetContactListQueryResult>>>;
