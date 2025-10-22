using CoDzisNaObiad.API.Models;
using FluentValidation;

namespace CoDzisNaObiad.API.Validators
{
    public class GetRecipeByIngredientRequestValidator : AbstractValidator<GetRecipeByIngredientsRequest>
    {
        public GetRecipeByIngredientRequestValidator()
        {
            RuleFor(x => x.Ingredients)
                .NotNull()
                .NotEmpty()
                .WithMessage("Ingredients can't be null or empty.");
        }
    }
}
