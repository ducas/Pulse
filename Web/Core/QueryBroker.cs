namespace Web.Core
{
    public class QueryBroker : IQueryBroker
    {
        public TResult Execute<TRequest, TResult>(TRequest request)
            where TRequest : class, IRequest<TResult>
            where TResult : class, new()
        {
            return request.Execute();
        }
    }
}