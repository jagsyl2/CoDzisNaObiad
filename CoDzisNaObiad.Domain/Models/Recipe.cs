using CoDzisNaObiad.Domain.Enums;

namespace CoDzisNaObiad.Domain.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public int? ProviderId { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Servings { get; set; }
        public int? ReadyInMinutes { get; set; }
        public int? CookingMinutes { get; set; }
        public int? PreparationMinutes { get; set; }
        public List<DishesTypes> DishTypes { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new();
    }
}
