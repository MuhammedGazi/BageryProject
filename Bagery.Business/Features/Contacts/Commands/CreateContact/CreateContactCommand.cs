using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Contacts.Commands.CreateContact;

public record CreateContactCommand(int ContactId, string FullName, string Email, string PhoneNumber, string Subject, string Message) : IRequest<IResult>;
