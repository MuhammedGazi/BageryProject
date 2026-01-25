using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.ProductImages.Queries.GetProductImageList;

public record GetProductImageListQuery() : IRequest<IDataResult<List<GetProductImageListQueryResult>>>;
