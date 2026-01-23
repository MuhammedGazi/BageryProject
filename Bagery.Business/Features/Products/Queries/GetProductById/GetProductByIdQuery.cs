using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Products.Queries.GetProductById;

public record GetProductByIdQuery(int Id) : IRequest<IDataResult<GetProductByIdQueryResult>>;
