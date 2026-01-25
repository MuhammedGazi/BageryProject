using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Services.Commands.DeleteService;

public record DeleteServiceCommand(int Id) : IRequest<IResult>;
