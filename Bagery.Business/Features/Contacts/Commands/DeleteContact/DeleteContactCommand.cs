using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Contacts.Commands.DeleteContact
{
    public record DeleteContactCommand(int ContactId) : IRequest<IResult>;
}
