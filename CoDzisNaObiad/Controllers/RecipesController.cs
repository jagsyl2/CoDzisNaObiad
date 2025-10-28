using Microsoft.AspNetCore.Mvc;
using CoDzisNaObiad.Application.Interfaces;
using CoDzisNaObiad.Application.Queries.GetRecipeByIngredients;
using CoDzisNaObiad.Domain.Models;
using CoDzisNaObiad.Application.Queries.GetRecipeById;
using CoDzisNaObiad.Application.Queries.PostRecipe;
using CoDzisNaObiad.API.Models;
using CoDzisNaObiad.API.Mappers;
using System.Net;
using CoDzisNaObiad.Domain.Interfaces;
using CoDzisNaObiad.Domain.Enums;

namespace CoDzisNaObiad.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipesController(
        IQueryHandler<GetRecipeByIngredientsQuery, List<RecipeByIngredients>> getRecipeByIngredientsHandler,
        IQueryHandler<GetRecipeByIdQuery, Recipe> getRecipeByIdHandler,
        IQueryHandler<PostRecipeQuery, int> postRecipe,
        IRecipesMapper recipesMapper,
        ICasheProvider cache) : ControllerBase
    {
        [HttpGet("getRecipesByIngredients/{ingredients}")]
        public ActionResult<List<RecipeByIngredients>> GetRecipesByIngredients([FromQuery] GetRecipeByIngredientsRequest request)
        {
            try
            {
                var key = CreateIngredientsKey(request.Ingredients, request.Source);

                var recipes = cache.GetOrCreate(key, () => getRecipeByIngredientsHandler.Handle(recipesMapper.GetRecipeByIngredientsRequestToQuery(request)));
                if (recipes == null)
                {
                    return BadRequest();
                }

                return Ok(recipes);
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("getRecipeById/{id}")]
        public ActionResult<Recipe> GetRecipeById([FromQuery] GetRecipeByIdRequest request)
        {
            try
            {
                var key = $"Recipe:{request.Id}_{request.Sources}";
                
                var recipe = cache.GetOrCreate(key, () => getRecipeByIdHandler.Handle(recipesMapper.GetRecipeByIdRequestToQuery(request)));
                if (recipe == null)
                {
                    return BadRequest();
                }

                return Ok(recipe);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("addRecipe")]
        public ActionResult<int> PostRecipe([FromBody] PostRecipeQuery recipe)
        {
            try
            {
                return postRecipe.Handle(recipe);
            } 
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError); 
            }
        }

        private string CreateIngredientsKey(string ingredients, RecipeSources source)
        {
            var ingredientsList = ingredients.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim().ToLower())
                .OrderBy(x => x)
                .ToList();
            var ingredientsSorted = string.Join("|", ingredientsList);

            return $"Ingredients:{ingredientsSorted}_{source}";
        }
    }
}
