using CoDzisNaObiad.Infrastructure.ExternalApiClients.ModelsDto;
using spoonacular.Model;

namespace CoDzisNaObiad.Infrastructure.ExternalApiClients.Spoonacular.Mappers
{
    public interface IRecipeSpoonacularMapper
    {
        List<RecipeByIngredientsExternal> MapRecipiesToRecipiesIngredients(List<SearchRecipesByIngredients200ResponseInner> recipes);
    }

    public class RecipeSpoonacularMapper : IRecipeSpoonacularMapper
    {
        public List<RecipeByIngredientsExternal> MapRecipiesToRecipiesIngredients(List<SearchRecipesByIngredients200ResponseInner> recipes)
        {
            List<RecipeByIngredientsExternal> mappedRecipes = new List<RecipeByIngredientsExternal>();

            if (recipes != null)
            {
                foreach (var recipe in recipes)
                {
                    var mappedRecipe = new RecipeByIngredientsExternal
                    {
                        ProviderId = recipe.Id,
                        Name = recipe.Title,
                        ImageUrl = recipe.Image,
                    };

                    foreach (var ingredient in recipe.MissedIngredients)
                    {
                        var mappedIngredient = new IngredientInRecipeExternal
                        {
                            ProviderIngredientId = ingredient.Id,
                            Name = ingredient.Name,
                            ImageUrl = ingredient.Image,
                            Amount = ingredient.Amount,
                            Unit = ingredient.Unit,
                        };
                        mappedRecipe.MissedIngredients.Add(mappedIngredient);
                    }

                    foreach (var ingredient in recipe.UsedIngredients)
                    {
                        var mappedIngredient = new IngredientInRecipeExternal
                        {
                            ProviderIngredientId = ingredient.Id,
                            Name = ingredient.Name,
                            ImageUrl = ingredient.Image,
                            Amount = ingredient.Amount,
                            Unit = ingredient.Unit,
                        };
                        mappedRecipe.UsedIngredients.Add(mappedIngredient);
                    }
                    mappedRecipes.Add(mappedRecipe);
                }
            }
            return mappedRecipes;
        }
    } 
}
