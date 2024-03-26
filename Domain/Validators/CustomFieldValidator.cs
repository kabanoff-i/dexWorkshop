using System.Data;
using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validators;

public class CustomFieldValidator: AbstractValidator<CustomField>
{
    public CustomFieldValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .WithMessage(ValidationMessage.NotNull);

        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage(ValidationMessage.NotNull)
            .NotEmpty()
            .WithMessage(ValidationMessage.NotEmpty);
        
        RuleFor(x => x.Value)
            .NotNull()
            .WithMessage(ValidationMessage.NotNull)
            .NotEmpty()
            .WithMessage(ValidationMessage.NotEmpty);
    }
}