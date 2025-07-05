using System.Text.Json.Serialization;

namespace CoDzisNaObiad.Domain.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int? ProviderId { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Amount { get; set; }
        public string Unit { get; set; }
        public int RecipeId { get; set; }
        [JsonIgnore]
        public Recipe Recipe { get; set; }
        
    }
}
