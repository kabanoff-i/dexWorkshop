using System.Data;
using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validators;

public class CustomFieldValidator<T>: AbstractValidator<CustomField<T>>
{
    public CustomFieldValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .WithMessage(ValidationMessage.NotNull(nameof(CustomField<T>.Id)));

        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage(ValidationMessage.NotNull(nameof(CustomField<T>.Name)))
            .NotEmpty()
            .WithMessage(ValidationMessage.NotEmpty(nameof(CustomField<T>.Name)));
        
        RuleFor(x => x.Value)
            .NotNull()
            .WithMessage(ValidationMessage.NotNull(nameof(CustomField<T>.Name)))
            .NotEmpty()
            .WithMessage(ValidationMessage.NotEmpty(nameof(CustomField<T>.Name)));
    }
}