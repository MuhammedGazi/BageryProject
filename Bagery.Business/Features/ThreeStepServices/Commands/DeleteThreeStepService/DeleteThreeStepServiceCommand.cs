using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.ThreeStepServices.Commands.DeleteThreeStepService;

public record DeleteThreeStepServiceCommand(int Id) : IRequest<IResult>;
