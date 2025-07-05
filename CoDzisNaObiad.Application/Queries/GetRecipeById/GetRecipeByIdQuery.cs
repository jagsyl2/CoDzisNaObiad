using CoDzisNaObiad.Domain.Enums;

namespace CoDzisNaObiad.Application.Queries.GetRecipeById
{
    public class GetRecipeByIdQuery
    {
        public int Id { get; set; }
        public RecipeSources Sources { get; set; }

        public bool SaveInDatabase { get; set; }
    }
}
