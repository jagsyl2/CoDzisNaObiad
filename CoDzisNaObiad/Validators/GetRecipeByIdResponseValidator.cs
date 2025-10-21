using CoDzisNaObiad.API.Models;
using FluentValidation;

namespace CoDzisNaObiad.API.Validators
{
    public class GetRecipeByIdResponseValidator : AbstractValidator<GetRecipeByIdResponse>
    {
        public GetRecipeByIdResponseValidator()
        {

            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id should be grater than 0.");

            RuleFor(x => x.Sources)
                .NotNull()
                .WithMessage("Source should be chosen.");
        }
    }
}
