using MediatR;

namespace Application.Core.MediatR.Interfaces
{
    public interface IQuery<out TResult> : IRequest<TResult>
    { }
}
