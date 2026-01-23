using MediatR;
using Bagery.Core.Utilities.Results;

namespace Bagery.Business.Features.Contacts.Commands.DeleteContact
{
    public record DeleteContactCommand(int Id) : IRequest<IResult>;
}
