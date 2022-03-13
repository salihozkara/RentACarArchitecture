using FluentValidation;

namespace Application.Features.Colors.Commands.CreateColor;

public class CreateColorCommandValidator:AbstractValidator<CreateColorCommand>
{
    public CreateColorCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c=>c.Name).MinimumLength(2);
        RuleFor(c=>c.Name).MaximumLength(50);
    }
    
}