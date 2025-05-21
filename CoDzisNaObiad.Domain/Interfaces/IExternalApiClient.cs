using CoDzisNaObiad.Domain.Inter;

namespace CoDzisNaObiad.Domain.Interfaces
{
    public interface IExternalApiClient
    {
        List<RecipeByIngredientsDto> GetRecipesByIngredients(string ingredients, bool ignorePantry = true);
    }
}
