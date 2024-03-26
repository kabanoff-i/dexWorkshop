using Domain.Primitives;
using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validators;

public class FullNameValidator: AbstractValidator<FullName>
{
    public FullNameValidator()
    {
        //TODO Провалидировать все поля (MiddleName если не null то проверять на Empty(каскад правил))
        RuleFor(x => x.FirstName)
            .NotNull()
            .WithMessage(ValidationMessage.NotNull)
            .NotEmpty()
            .WithMessage(ValidationMessage.NotEmpty);
        
        RuleFor(x => x.LastName)
            .NotNull()
            .WithMessage(ValidationMessage.NotNull)
            .NotEmpty()
            .WithMessage(ValidationMessage.NotEmpty);

        RuleFor(x => x.MiddleName)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage(ValidationMessage.NotNull)
            .NotEmpty()
            .WithMessage(ValidationMessage.NotEmpty);
    }
}