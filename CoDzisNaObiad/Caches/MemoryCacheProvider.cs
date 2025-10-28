using CoDzisNaObiad.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace CoDzisNaObiad.API.Caches
{
    public class MemoryCacheProvider : ICasheProvider
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;
        private readonly MemoryCacheEntryOptions _options;

        private const string absoluteExpirationRelativeToNowPath = "Caching:MemoryCashe:AbsoluteExpirationRelativeToNow";
        private const string slidingExpirationPath = "Caching:MemoryCashe:SlidingExpiration";

        public MemoryCacheProvider(
            IMemoryCache memoryCache,
            IConfiguration configuration)
        {
            _memoryCache = memoryCache;
            _configuration = configuration;

            _options = new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(
                    Double.TryParse(_configuration[absoluteExpirationRelativeToNowPath], out var absoluteExpirationRelativeToNow)
                        ? absoluteExpirationRelativeToNow
                        : 60),
                SlidingExpiration = TimeSpan.FromMinutes(
                    Double.TryParse(configuration[slidingExpirationPath], out var slidingExpiration)
                        ? slidingExpiration
                        : 30)
            };
        }
        
        public T? GetOrCreate<T>(string key, Func<T> factory)
        {
            if (!_memoryCache.TryGetValue(key, out var recipe))
            {
                recipe = factory();

                if (recipe != null)
                {
                    _memoryCache.Set(key, recipe, _options);
                }
            }
            return (T?)recipe;
        }
    }
}
