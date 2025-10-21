using FluentValidation;
using static CoDzisNaObiad.Application.Queries.PostRecipe.PostRecipeQuery;

namespace CoDzisNaObiad.API.Validators
{
    public class IngredientDtoValidator : AbstractValidator<IngredientDto>
    {
        public IngredientDtoValidator() 
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name can't be null");

            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .WithMessage("Amount must be grater then 0");

            RuleFor(x => x.Unit)
                .NotNull()
                .NotEmpty()
                .WithMessage("Unit can't be null or empty.");
        }
    }
}
