using System.Threading;
using System.Threading.Tasks;
using Application.DataAccessLayer.Context;
using MediatR;

namespace Application.BusinessLogicLayer.MediatR.Abstractions
{
    public abstract class CommandBase<TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : IRequest<TResult>
    {
        protected readonly ParkingAppDbContext Context;

        protected CommandBase(ParkingAppDbContext context)
        {
            Context = context;
        }

        public abstract Task<TResult> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
