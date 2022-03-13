using FluentValidation;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c=>c.Name).MinimumLength(2);
        RuleFor(c=>c.Name).MaximumLength(50);
    }
    
}