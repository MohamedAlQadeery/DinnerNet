using FluentValidation;

namespace DinnerNet.Application.Dinners.Commands;

public class CreateDinnerCommandValidator : AbstractValidator<CreateDinnerCommand>
{
    public CreateDinnerCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}