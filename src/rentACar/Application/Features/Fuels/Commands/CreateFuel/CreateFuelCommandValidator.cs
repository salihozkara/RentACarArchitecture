using FluentValidation;

namespace Application.Features.Fuels.Commands.CreateFuel;

public class CreateFuelCommandValidator:AbstractValidator<CreateFuelCommand>
{
    public CreateFuelCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c=>c.Name).MinimumLength(2);
        RuleFor(c=>c.Name).MaximumLength(50);
    }
    
}