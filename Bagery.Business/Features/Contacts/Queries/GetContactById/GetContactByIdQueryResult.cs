namespace Bagery.Business.Features.Contacts.Queries.GetContactById;

public record GetContactByIdQueryResult(int ContactId, string FullName, string Email, string PhoneNumber, string Subject, string Message);
