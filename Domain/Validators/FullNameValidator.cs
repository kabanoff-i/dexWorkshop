using Domain.Primitives;
using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validators;

public class FullNameValidator : AbstractValidator<FullName>
{
    public FullNameValidator()
    {
        RuleFor(x => x.FirstName)
            .NotNull().WithMessage(x => ValidationMessage.NotNull(nameof(x.FirstName)))
            .NotEmpty().WithMessage(x => ValidationMessage.NotEmpty(nameof(x.FirstName)))
            .Matches(@"^[a-zA-Zа-яА-Я]+$").WithMessage(x => ValidationMessage.InvalidPropetry(nameof(x.FirstName)));

        RuleFor(x => x.LastName)
            .NotNull().WithMessage(x => ValidationMessage.NotNull(nameof(x.LastName)))
            .NotEmpty().WithMessage(x => ValidationMessage.NotEmpty(nameof(x.LastName)))
            .Matches(@"^[a-zA-Zа-яА-Я]+$").WithMessage(x => ValidationMessage.InvalidPropetry(nameof(x.LastName)));

        RuleFor(x => x.MiddleName)
            .NotEmpty().When(x => x.MiddleName != null)
            .WithMessage(x => ValidationMessage.NotEmpty(nameof(x.MiddleName)))
            .Matches(@"^[a-zA-Zа-яА-Я]+$").When(x => x.MiddleName != null)
            .WithMessage(x => ValidationMessage.InvalidPropetry(nameof(x.MiddleName)));
    }
}