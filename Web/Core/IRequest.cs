namespace Web.Core
{
    public interface IRequest<out T> where T : class
    {
        T Execute();
    }
}