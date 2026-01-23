namespace Bagery.Business.Features.Contacts.Queries.GetContactList;

public record GetContactListQueryResult(int ContactId, string FullName, string Email, string PhoneNumber, string Subject, string Message);
