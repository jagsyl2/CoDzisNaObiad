using Microsoft.AspNetCore.Mvc;
using CoDzisNaObiad.Application.Interfaces;
using CoDzisNaObiad.Application.Queries.GetRecipeByIngredients;
using CoDzisNaObiad.Domain.Models;
using CoDzisNaObiad.Application.Queries.GetRecipeById;
using CoDzisNaObiad.Application.Queries.PostRecipe;
using CoDzisNaObiad.API.Models;
using CoDzisNaObiad.API.Mappers;
using System.Net;

namespace CoDzisNaObiad.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipesController(
        IQueryHandler<GetRecipeByIngredientsQuery, List<RecipeByIngredients>> getRecipeByIngredientsHandler,
        IQueryHandler<GetRecipeByIdQuery, Recipe> getRecipeByIdHandler,
        IQueryHandler<PostRecipeQuery, int> postRecipe,
        IRecipesMapper recipesMapper) : ControllerBase
    {

        [HttpGet("getRecipesByIngredients/{ingredients}")]
        public ActionResult<List<RecipeByIngredients>> GetRecipesByIngredients([FromQuery] GetRecipeByIngredientsRequest request)
        {
            try
            {
                var recipes = getRecipeByIngredientsHandler.Handle(recipesMapper.GetRecipeByIngredientsRequestToQuery(request));
                if (recipes == null)
                {
                    return BadRequest();
                }

                return recipes;
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
                var recipies = getRecipeByIdHandler.Handle(recipesMapper.GetRecipeByIdRequestToQuery(request));
                if (recipies == null)
                {
                    return BadRequest();
                }

                return recipies;
            }
            catch(Exception ex)
            {
                //logger.LogError();
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
    }
}
