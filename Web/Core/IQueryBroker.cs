namespace Web.Core
{
    public interface IQueryBroker
    {
        TResult Execute<TRequest, TResult>(TRequest request)
            where TRequest : class, IRequest<TResult>
            where TResult : class, new();
    }
}