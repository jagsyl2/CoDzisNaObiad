using CoDzisNaObiad.Domain.Models;
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

        List<RecipeByIngredients> IExternalApiClient.GetRecipesByIngredients(string ingredients, bool ignorePantry)
        {
            var recipes = GetRecipesByIngredients(ingredients);
            var mappedRecipies = _recipeMapper.MapRecipiesToRecipiesIngredients(recipes);

            return mappedRecipies;
        }

        public RecipeInformation GetRecipeById(int id)
        {
             return _recipesApi.GetRecipeInformation(id);
        }


        Recipe IExternalApiClient.GetRecipeById(int id)
        {
            var recipe = GetRecipeById(id);
            if (recipe == null)
            {
                return null;
            }

            var mappedRecipe = _recipeMapper.MapRecipeInformationToRecipe(recipe);

            return mappedRecipe;
        }

    }
}
