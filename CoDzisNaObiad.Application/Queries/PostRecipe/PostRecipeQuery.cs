using CoDzisNaObiad.Domain.Enums;

namespace CoDzisNaObiad.Application.Queries.PostRecipe
{
    public class PostRecipeQuery
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int Servings { get; set; }
        public int ReadyInMinutes { get; set; }
        public int CookingMinutes { get; set; }
        public int PreparationMinutes { get; set; }
        public List<DishesTypes> DishTypes { get; set; }
        public List<IngredientDto> Ingredients { get; set; }

        public class IngredientDto
        {
            public int? ProviderId { get; set; }
            public string Name { get; set; }
            public string? ImageUrl { get; set; }
            public decimal Amount { get; set; }
            public string Unit { get; set; }
        }
    }
}
