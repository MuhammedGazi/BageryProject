using MediatR;
using Bagery.Core.Utilities.Results;
using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Bagery.Business.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler(IGenericRepository<Order> repository) : IRequestHandler<DeleteOrderCommand, IResult>
    {
        public async Task<IResult> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            // Ýþlemler...
            return new SuccessResult();
        }
    }
}
