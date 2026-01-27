using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Abouts.Commands.DeleteAbout
{
    public record DeleteAboutCommand(int Id) : IRequest<IResult>;
}
