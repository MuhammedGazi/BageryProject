using MediatR;
using Bagery.Core.Utilities.Results;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Bagery.Business.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler(IGenericRepository<Order> repository) : IRequestHandler<UpdateOrderCommand, IResult>
    {
        public async Task<IResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            // Ýþlemler...
            return new SuccessResult();
        }
    }
}
