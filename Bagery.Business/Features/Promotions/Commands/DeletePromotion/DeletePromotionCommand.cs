using Bagery.Core.Utilities.Results;
using MediatR;

namespace Bagery.Business.Features.Promotions.Commands.DeletePromotion;

public record DeletePromotionCommand(int Id) : IRequest<IResult>;
