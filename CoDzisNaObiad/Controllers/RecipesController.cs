using Microsoft.AspNetCore.Mvc;
using CoDzisNaObiad.Application.Interfaces;
using CoDzisNaObiad.Application.Queries.GetRecipeByIngredients;
using CoDzisNaObiad.Domain.Models;
using CoDzisNaObiad.Domain.Enums;
using CoDzisNaObiad.Application.Queries.GetRecipeById;
using CoDzisNaObiad.Application.Queries.PostRecipe;

namespace CoDzisNaObiad.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IQueryHandler<GetRecipeByIngredientsQuery, List<RecipeByIngredients>> _getRecipeByIngredientsHandler;
        private readonly IQueryHandler<GetRecipeByIdQuery, Recipe> _getRecipeByIdHandler;
        private readonly IQueryHandler<PostRecipeQuery, int> _postRecipe;

        public RecipesController(
            IQueryHandler<GetRecipeByIngredientsQuery, List<RecipeByIngredients>> getRecipeByIngredientsHandler,
            IQueryHandler<GetRecipeByIdQuery, Recipe> getRecipeByIdHandler,
            IQueryHandler<PostRecipeQuery, int> postRecipe)
        {
            _getRecipeByIngredientsHandler = getRecipeByIngredientsHandler;
            _getRecipeByIdHandler = getRecipeByIdHandler;
            _postRecipe = postRecipe;
        }

        [HttpGet("getRecipesByIngredients/{ingredients}")]
        public ActionResult<List<RecipeByIngredients>> GetRecipesByIngredients(string ingredients, [FromQuery] RecipeSources sources = RecipeSources.Own)
        {
            if (string.IsNullOrEmpty(ingredients)) 
            {
                return NoContent();
            }

            var recipes = _getRecipeByIngredientsHandler.Handle(new GetRecipeByIngredientsQuery { Ingredients = ingredients, Sources = sources });

            if (recipes == null)
            {
                return NoContent();
            }

            return recipes;
        }

        [HttpGet("getRecipeById/{id}")]
        public ActionResult<Recipe> GetRecipeById(int id, [FromQuery] RecipeSources sources = RecipeSources.Own, [FromQuery] bool saveInDatabase = false)
        {
            var recipies = _getRecipeByIdHandler.Handle(new GetRecipeByIdQuery { Id = id, Sources = sources, SaveInDatabase = saveInDatabase});
            if (recipies == null)
            {
                return NoContent();
            }

            return recipies;
        }

        [HttpPost("addRecipe")]
        public ActionResult<int> PostRecipe([FromBody] PostRecipeQuery recipe)
        {
            return _postRecipe.Handle(recipe);
        }
    }
}
