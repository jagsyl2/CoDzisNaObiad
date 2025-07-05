namespace CoDzisNaObiad.Domain.Models
{
    public class RecipeByIngredients
    {
        public int Id { get; set; }
        public int? ProviderId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public List<Ingredient> MissedIngredients { get; set; } = new();
        public List<Ingredient> UsedIngredients { get; set; } = new();
    }
}
