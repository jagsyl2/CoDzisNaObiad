using CoDzisNaObiad.Domain.Models;

namespace CoDzisNaObiad.Infrastructure.Database.Mappers
{
    internal interface IRecipeMapper
    {
        List<RecipeByIngredients> MapRecipiesToRecipiesIngredients(List<Recipe> recipes, List<string> includedIngredients);
    }

    public class RecipeMapper : IRecipeMapper
    {
        public List<RecipeByIngredients> MapRecipiesToRecipiesIngredients(List<Recipe> recipes, List<string> includedIngredients)
        {
            List<RecipeByIngredients> mappedRecipes = new List<RecipeByIngredients>();

            if (recipes != null)
            {
                foreach (var recipe in recipes)
                {
                    var mappedRecipe = new RecipeByIngredients
                    {
                        Id = recipe.Id,
                        Name = recipe.Name,
                        ImageUrl = recipe.ImageUrl,
                    };

                    AddIngredientsToList(recipe.Ingredients, includedIngredients, mappedRecipe);

                    mappedRecipes.Add(mappedRecipe);
                }
            }
            return mappedRecipes;
        }

        private void AddIngredientsToList(List<Ingredient> ingredients, List<string> includedIngredients, RecipeByIngredients mappedRecipe)
        {
            foreach (var ingredient in ingredients)
            {
                var mappedIngredient = MapIngredient(ingredient);

                if (includedIngredients.Contains(ingredient.Name.ToLower()))
                {    
                    mappedRecipe.UsedIngredients.Add(mappedIngredient);
                } 
                else
                {
                    mappedRecipe.MissedIngredients.Add(mappedIngredient);
                }
            }
        }

        private Ingredient MapIngredient(Ingredient ingredient)
        {
            var mappedIngredient = new Ingredient
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                ImageUrl = ingredient.ImageUrl,
                Amount = ingredient.Amount,
                Unit = ingredient.Unit,
            };

            return mappedIngredient;
        }

    }
}
