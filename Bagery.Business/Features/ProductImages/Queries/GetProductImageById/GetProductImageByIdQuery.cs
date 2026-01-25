using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.ProductImages.Queries.GetProductImageById;

public record GetProductImageByIdQuery(int Id) : IRequest<IDataResult<GetProductImageByIdQueryResult>>;
