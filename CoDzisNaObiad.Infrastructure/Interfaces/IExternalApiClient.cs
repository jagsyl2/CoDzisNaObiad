using CoDzisNaObiad.Infrastructure.ExternalApiClients.ModelsDto;

namespace CoDzisNaObiad.Infrastructure.Interfaces
{
    public interface IExternalApiClient
    {
        List<RecipeByIngredientsExternal> GetRecipesByIngredients(string ingredients, bool ignorePantry = true);
    }
}
