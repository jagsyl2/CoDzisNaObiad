using CoDzisNaObiad.Application.Interfaces;
using CoDzisNaObiad.Domain.Models;
using CoDzisNaObiad.Infrastructure.Repositories;

namespace CoDzisNaObiad.Application.Queries.PostRecipe
{
    public class PostRecipeHandler : IQueryHandler<PostRecipeQuery, int>
    {
        public readonly IRecipeRepository _recipeRepository;
        public Recipe Recipe { get; set; }
        public PostRecipeHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public int Handle(PostRecipeQuery query)
        {
            var recipe = new Recipe()
            {
                Name = query.Name,
                CookingMinutes = query.CookingMinutes,
                DishTypes = query.DishTypes,
                ImageUrl = query.ImageUrl,
                PreparationMinutes = query.PreparationMinutes,
                ReadyInMinutes = query.ReadyInMinutes,
                Servings = query.Servings,
                Ingredients = query.Ingredients.Select(i => new Ingredient
                {
                    Name = i.Name,
                    ImageUrl = i.ImageUrl,
                    Amount = i.Amount,
                    Unit = i.Unit
                }).ToList(),
            };

            _recipeRepository.Add(recipe);
            return recipe.Id;
        }
    }
}
