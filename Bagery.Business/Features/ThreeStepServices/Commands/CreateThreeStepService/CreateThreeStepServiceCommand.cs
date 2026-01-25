using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.ThreeStepServices.Commands.CreateThreeStepService;

public record CreateThreeStepServiceCommand(int ThreeStepServiceId, string IconUrl, string Title, string Description) : IRequest<IResult>;
