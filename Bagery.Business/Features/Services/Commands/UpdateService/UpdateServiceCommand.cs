using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Services.Commands.UpdateService;

public record UpdateServiceCommand(int ServiceId, string Title, string Description, string IconUrl) : IRequest<IResult>;
