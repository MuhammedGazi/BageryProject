using MediatR;
using Bagery.Core.Utilities.Results;

namespace Bagery.Business.Features.Categories.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(int Id) : IRequest<IResult>;
}
