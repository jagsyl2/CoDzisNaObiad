using spoonacular.Api;

namespace CoDzisNaObiad.Infrastructure.ExternalApiClients.Spoonacular
{
    public interface ISpoonacularClient
    {
        DefaultApi CreateDefaultSpoonacularClient();
        RecipesApi CreateRecipesSpoonacularClient();
    }
}
