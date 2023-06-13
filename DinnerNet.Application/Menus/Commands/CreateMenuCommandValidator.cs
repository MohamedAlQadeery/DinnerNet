using FluentValidation;

namespace DinnerNet.Application.Menus.Commands;


public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(v => v.HostId)
            .NotEmpty();

        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(v => v.Description)
            .MaximumLength(200)
            .NotEmpty();



    }
}