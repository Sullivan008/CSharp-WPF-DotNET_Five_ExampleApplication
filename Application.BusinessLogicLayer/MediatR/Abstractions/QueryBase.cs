using System.Threading;
using System.Threading.Tasks;
using Application.DataAccessLayer.Context;
using MediatR;

namespace Application.BusinessLogicLayer.MediatR.Abstractions
{
    public abstract class QueryBase<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IRequest<TResult>
    {
        protected ParkingAppReadonlyDbContext Context;

        protected QueryBase(ParkingAppReadonlyDbContext context)
        {
            Context = context;
        }

        public abstract Task<TResult> Handle(TQuery request, CancellationToken cancellationToken);
    }
}
