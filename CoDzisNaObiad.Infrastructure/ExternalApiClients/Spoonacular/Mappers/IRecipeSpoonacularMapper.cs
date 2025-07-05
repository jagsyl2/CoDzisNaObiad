using CoDzisNaObiad.Domain.Enums;
using CoDzisNaObiad.Domain.Models;
using spoonacular.Model;

namespace CoDzisNaObiad.Infrastructure.ExternalApiClients.Spoonacular.Mappers
{
    public interface IRecipeSpoonacularMapper
    {
        List<RecipeByIngredients> MapRecipiesToRecipiesIngredients(List<SearchRecipesByIngredients200ResponseInner> recipes);
        Recipe MapRecipeInformationToRecipe(RecipeInformation recipeInformation);
    }

    public class RecipeSpoonacularMapper : IRecipeSpoonacularMapper
    {
        public List<RecipeByIngredients> MapRecipiesToRecipiesIngredients(List<SearchRecipesByIngredients200ResponseInner> recipes)
        {
            List<RecipeByIngredients> mappedRecipes = new List<RecipeByIngredients>();

            if (recipes != null)
            {
                foreach (var recipe in recipes)
                {
                    var mappedRecipe = new RecipeByIngredients
                    {
                        Id = recipe.Id,
                        ProviderId = recipe.Id,
                        Name = recipe.Title,
                        ImageUrl = recipe.Image,
                    };

                    AddIngredientsToList(recipe.MissedIngredients, mappedRecipe);
                    AddIngredientsToList(recipe.UsedIngredients, mappedRecipe);

                    mappedRecipes.Add(mappedRecipe);
                }
            }
            return mappedRecipes;
        }

        public Recipe MapRecipeInformationToRecipe (RecipeInformation recipeInformation)
        {
            var recipe = new Recipe()
            {
                ProviderId = recipeInformation.Id,
                Name = recipeInformation.Title,
                ImageUrl = recipeInformation.Image,
                DishTypes = recipeInformation.DishTypes
                    .Where(s => Enum.TryParse<DishesTypes>(s, true, out _))
                    .Select(s => Enum.Parse<DishesTypes>(s, true))
                    .ToList(),
                CookingMinutes = recipeInformation.CookingMinutes,
                PreparationMinutes = recipeInformation.PreparationMinutes,
                ReadyInMinutes = recipeInformation.ReadyInMinutes,
                Servings = recipeInformation.Servings,
                Ingredients = recipeInformation.ExtendedIngredients.Select(i => new Ingredient
                {
                    ProviderId = i.Id,
                    Name = i.Name,
                    ImageUrl = i.Image,
                    Amount = i.Amount,
                    Unit = i.Unit
                }).ToList()
            };
            return recipe;
        }

        private void AddIngredientsToList(List<SearchRecipesByIngredients200ResponseInnerMissedIngredientsInner> ingredients, RecipeByIngredients mappedRecipe)
        {
            foreach (var ingredient in ingredients)
            {
                var mappedIngredient = MapIngredient(ingredient);
                mappedRecipe.MissedIngredients.Add(mappedIngredient);
            }
        }

        private Ingredient MapIngredient(SearchRecipesByIngredients200ResponseInnerMissedIngredientsInner ingredient)
        {
            var mappedIngredient = new Ingredient
            {
                ProviderId = ingredient.Id,
                Name = ingredient.Name,
                ImageUrl = ingredient.Image,
                Amount = ingredient.Amount,
                Unit = ingredient.Unit,
            };

            return mappedIngredient;
        }
    } 
}
