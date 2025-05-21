using CoDzisNaObiad.Application.Enums;

namespace CoDzisNaObiad.Application.Queries
{
    public class GetRecipeByIngredientsQuery
    {
        public string Ingredients { get; set; }
        public Zasoby Zasoby { get; set; }
    }
}
