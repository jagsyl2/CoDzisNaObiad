using spoonacular.Api;

namespace CoDzisNaObiad.Infrastructure.ExternalApiClients.Spoonacular
{
    public interface ISpoonacularClient
    {
        
        //nie znajduje mi referencji do DefaultApi i RecipesApi. Czegoś potrzebuję?
        
        DefaultApi CreateDefaultSpoonacularClient();
        RecipesApi CreateRecipesSpoonacularClient();
    }
}
