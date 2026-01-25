using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.ThreeStepServices.Commands.UpdateThreeStepService;

public record UpdateThreeStepServiceCommand(int ThreeStepServiceId, string IconUrl, string Title, string Description) : IRequest<IResult>;
