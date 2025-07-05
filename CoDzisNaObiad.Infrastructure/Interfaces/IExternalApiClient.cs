using CoDzisNaObiad.Domain.Models;

namespace CoDzisNaObiad.Infrastructure.Interfaces
{
    public interface IExternalApiClient
    {
        List<RecipeByIngredients> GetRecipesByIngredients(string ingredients, bool ignorePantry = true);
        Recipe GetRecipeById(int id);

    }
}
