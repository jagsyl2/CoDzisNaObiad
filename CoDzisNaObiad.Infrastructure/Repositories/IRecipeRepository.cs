using CoDzisNaObiad.Domain.Models;

namespace CoDzisNaObiad.Infrastructure.Repositories
{
    public interface IRecipeRepository
    {
        List<RecipeByIngredients>? GetRecipesByIngredients(string ingredients);
        Recipe? GetRecipeById(int id);
        Recipe? GetRecipeByProviderId(int id);
        bool CheckRecipeByProviderId(int id);
        void Add(Recipe recipe);
    }
}
