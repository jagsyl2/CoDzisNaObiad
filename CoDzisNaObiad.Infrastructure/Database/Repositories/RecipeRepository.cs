using CoDzisNaObiad.Domain.Models;
using CoDzisNaObiad.Infrastructure.Database.Mappers;
using Microsoft.EntityFrameworkCore;

namespace CoDzisNaObiad.Infrastructure.Database.Repositories
{
    internal class RecipeRepository : IRecipeRepository
    {
        private readonly CoDzisNaObiadDbContext _dbContext;
        private readonly IRecipeMapper _recipeMapper;
        public RecipeRepository(
            CoDzisNaObiadDbContext dbContext,
            IRecipeMapper recipeMapper)
        {
            _dbContext = dbContext;
            _recipeMapper = recipeMapper;
        }

        public void Add(Recipe recipe)
        {
            _dbContext.Recipes.Add(recipe);
            _dbContext.SaveChanges();
        }

        public Recipe? GetRecipeById(int id)
        {
            return _dbContext.Recipes.Include(x => x.Ingredients).FirstOrDefault(x => x.Id == id);
        }

        public Recipe? GetRecipeByProviderId(int id)
        {
            return _dbContext.Recipes.Include(x => x.Ingredients).FirstOrDefault(x => x.ProviderId == id);
        }

        public bool CheckRecipeByProviderId(int id)
        {
            return _dbContext.Recipes.Any(x => x.ProviderId == id);
        }

        public List<RecipeByIngredients>? GetRecipesByIngredients(string ingredients)
        {
            var ingredientsArray = ingredients
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.Trim().ToLower())
                .ToList();

            var recipes = _dbContext.Recipes
                .Where(r => ingredientsArray
                    .All(ingredient => r.Ingredients
                        .Any(i => i.Name.ToLower().Contains(ingredient))))
                .Include(r => r.Ingredients)
                .ToList();

            return _recipeMapper.MapRecipiesToRecipiesIngredients(recipes, ingredientsArray);
        }
    }
}
