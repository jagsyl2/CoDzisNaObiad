namespace CoDzisNaObiad.Domain.Interfaces
{
    public interface ICasheProvider
    {
        T? GetOrCreate<T>(string key, Func<T> factory);
    }
}
