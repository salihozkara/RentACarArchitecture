using System.ComponentModel.DataAnnotations;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Core.Application.Pipelines.Validation;

public class ValidationTool
{
    public static void Validate(IValidator validator,object obj)
    {
        var context = new ValidationContext<object>(obj);
        var result = validator.Validate(context);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }
    }
}