using CoDzisNaObiad.Application.DtoModels;
using CoDzisNaObiad.Infrastructure.ExternalApiClients.ModelsDto;

namespace CoDzisNaObiad.Application.Mappers
{
    public interface IRecipeMapper
    {
        List<RecipeByIngredientsDto> MapRecipiesToRecipiesIngredients(List<RecipeByIngredientsExternal> recipes);
    }

    public class RecipeMapper : IRecipeMapper
    {
        public List<RecipeByIngredientsDto> MapRecipiesToRecipiesIngredients(List<RecipeByIngredientsExternal> recipes)
        {
            var mappedRecipes = new List<RecipeByIngredientsDto>();

            foreach (var recipe in recipes)
            {
                var mappedRecipe = new RecipeByIngredientsDto
                {
                    ProviderId = recipe.ProviderId,
                    Name = recipe.Name,
                    ImageUrl = recipe.ImageUrl,
                };

                foreach (var ingredient in recipe.MissedIngredients)
                {
                    var mappedIngredient = new IngredientInRecipeDto
                    {
                        ProviderIngredientId = ingredient.ProviderIngredientId,
                        Name = ingredient.Name,
                        ImageUrl = ingredient.ImageUrl,
                        Amount = ingredient.Amount,
                        Unit = ingredient.Unit,
                    };
                    mappedRecipe.MissedIngredients.Add(mappedIngredient);
                }

                foreach (var ingredient in recipe.UsedIngredients)
                {
                    var mappedIngredient = new IngredientInRecipeDto
                    {
                        ProviderIngredientId = ingredient.ProviderIngredientId,
                        Name = ingredient.Name,
                        ImageUrl = ingredient.ImageUrl,
                        Amount = ingredient.Amount,
                        Unit = ingredient.Unit,
                    };
                    mappedRecipe.UsedIngredients.Add(mappedIngredient);
                }
                mappedRecipes.Add(mappedRecipe);
            }

            return mappedRecipes;
        }
    }
}
