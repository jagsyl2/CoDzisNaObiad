namespace CoDzisNaObiad.Application.Interfaces
{
    public interface IQueryHandler<TQuery, TResult>
    {
        TResult? Handle(TQuery query);
    }
}
