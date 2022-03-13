using FluentValidation;

namespace Application.Features.Transmissions.Commands.CreateTransmission;

public class CreateTransmissionCommandValidator:AbstractValidator<CreateTransmissionCommand>
{
    public CreateTransmissionCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c=>c.Name).MinimumLength(2);
        RuleFor(c=>c.Name).MaximumLength(50);
    }
    
}