using FluentValidation;

namespace Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandValidator:AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c=>c.Name).MinimumLength(2);
        RuleFor(c=>c.Name).MaximumLength(50);
    }
    
}