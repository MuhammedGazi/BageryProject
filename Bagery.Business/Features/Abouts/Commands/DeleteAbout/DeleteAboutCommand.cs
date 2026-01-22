using MediatR;
using Bagery.Core.Utilities.Results;

namespace Bagery.Business.Features.Abouts.Commands.DeleteAbout
{
    public record DeleteAboutCommand(int Id) : IRequest<IResult>;
}
