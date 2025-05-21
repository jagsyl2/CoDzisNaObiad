using spoonacular.Model;

namespace CoDzisNaObiad.Infrastructure.ExternalApiClients.Spoonacular
{
    public interface ISpoonacularApiClient
    {
        List<SearchRecipesByIngredients200ResponseInner> GetRecipesByIngredients(string ingredients, bool ignorePantry = true);
    }
}