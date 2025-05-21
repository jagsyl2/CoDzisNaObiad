using Microsoft.Extensions.Options;
using spoonacular.Api;
using spoonacular.Client;

namespace CoDzisNaObiad.Infrastructure.ExternalApiClients.Spoonacular
{
    public class SpoonacularClient : ISpoonacularClient
    {
        private readonly SpoonacularConfig _config;

        public SpoonacularClient(IOptions<SpoonacularConfig> config)
        {
            _config = config.Value;
        }

        public DefaultApi CreateDefaultSpoonacularClient()
        {
            var configuration = SetConfiguration();
            return new DefaultApi(configuration);
        }

        public RecipesApi CreateRecipesSpoonacularClient()
        {
            var configuration = SetConfiguration();
            return new RecipesApi(configuration);
        }

        private Configuration SetConfiguration()
        {
            var configuration = new Configuration();
            configuration.BasePath = _config.BasePath;
            configuration.AddApiKey("x-api-key", _config.ApiKey);

            return configuration;
        }
    }
}
