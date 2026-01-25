using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Services.Commands.CreateService;

public record CreateServiceCommand(int ServiceId, string Title, string Description, string IconUrl) : IRequest<IResult>;
