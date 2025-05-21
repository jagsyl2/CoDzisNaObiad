using CoDzisNaObiad.Infrastructure.ExternalApiClients.ModelsDto;
using CoDzisNaObiad.Infrastructure.ExternalApiClients.Spoonacular.Mappers;
using CoDzisNaObiad.Infrastructure.Interfaces;
using spoonacular.Api;
using spoonacular.Model;

namespace CoDzisNaObiad.Infrastructure.ExternalApiClients.Spoonacular
{
    public class SpoonacularApiClient : ISpoonacularApiClient, IExternalApiClient
    {
        private readonly RecipesApi _recipesApi = new();
        private readonly IRecipeSpoonacularMapper _recipeMapper;

        public SpoonacularApiClient(
            RecipesApi recipesApi,
            IRecipeSpoonacularMapper recipeMapper)
        {
            _recipesApi = recipesApi;
            _recipeMapper = recipeMapper;
        }

        public List<SearchRecipesByIngredients200ResponseInner> GetRecipesByIngredients(string ingredients, bool ignorePantry = true)
        {
            return _recipesApi.SearchRecipesByIngredients(ingredients, ignorePantry: ignorePantry);
        }

        List<RecipeByIngredientsExternal> IExternalApiClient.GetRecipesByIngredients(string ingredients, bool ignorePantry)
        {
            var recipes = GetRecipesByIngredients(ingredients);
            var mappedRecipies = _recipeMapper.MapRecipiesToRecipiesIngredients(recipes);

            return mappedRecipies;
        }
    }
}
