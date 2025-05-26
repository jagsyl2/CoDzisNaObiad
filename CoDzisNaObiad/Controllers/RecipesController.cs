using Microsoft.AspNetCore.Mvc;
using CoDzisNaObiad.Application.DtoModels;
using CoDzisNaObiad.Application.Interfaces;
using CoDzisNaObiad.Application.Enums;
using CoDzisNaObiad.Application.Queries.GetRecipeByIngredients;

namespace CoDzisNaObiad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IQueryHandler<GetRecipeByIngredientsQuery, List<RecipeByIngredientsDto>> _getRecipeByIngredientsHandler;
        public RecipesController(IQueryHandler<GetRecipeByIngredientsQuery, List<RecipeByIngredientsDto>> getRecipeByIngredientsHandler)
        {
            _getRecipeByIngredientsHandler = getRecipeByIngredientsHandler;
        }

        [HttpGet("getRecipesByIngredients/{ingredients}")]
        public ActionResult<List<RecipeByIngredientsDto>> GetRecipesByIngredients(string ingredients, Zasoby zasoby)
        {
            var recipes = _getRecipeByIngredientsHandler.Handle(new GetRecipeByIngredientsQuery { Ingredients = ingredients, Zasoby = zasoby });
            DisplayInConsole(recipes);

            return recipes;
        }

        //[HttpGet("getRecipe/{recipeId}")]
        //public ActionResult<RecipeDto>

        private void DisplayInConsole(List<RecipeByIngredientsDto> mappedRecipies)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("{0,-10} {1,-50} {2,-30} {3,-30}", "Id", "Nazwa", "Co wykorzystasz:", "Co jeszcze potrzebujesz:");
            Console.ResetColor();
            Console.WriteLine(new string('-', 75));


            foreach (var recipe in mappedRecipies)
            {
                Console.Write("{0,-10} {1,-50} {2,-30} {3,-30}", recipe.ProviderId, recipe.Name, recipe.UsedIngredients[0].Name, recipe.MissedIngredients[0].Name);

                var max = Math.Max(recipe.UsedIngredients.Count, recipe.MissedIngredients.Count);

                for (int i = 1; i<max; i++)
                {
                    var kol3 = i < recipe.UsedIngredients.Count ? recipe.UsedIngredients[i].Name : "";
                    var kol4 = i < recipe.MissedIngredients.Count ? recipe.MissedIngredients[i].Name : "";

                    Console.WriteLine("{0,-60} {1,-30} {2,-30}", "", kol3, kol4);
                }
            }
            Console.WriteLine();
        }
    }
}
