using CoDzisNaObiad.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CoDzisNaObiad.API.Models
{
    public class GetRecipeByIdResponse
    {
        [FromRoute(Name ="id")]
        public int Id { get; set; }

        [FromQuery]
        public RecipeSources Sources { get; set; }

        [FromQuery]
        public bool SaveInDatabase { get; set; }
    }
}
