using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validators;

public class PersonValidator: AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .WithMessage(ValidationMessage.NotNull);

        RuleFor(x => x.Birthday)
            .NotNull()
            .WithMessage(ValidationMessage.NotNull)
            .NotEmpty()
            .WithMessage(ValidationMessage.NotEmpty)
            .LessThan(DateTime.Now)
            .WithMessage("День рождения не существует");
        
        RuleFor(x => x.FullName).SetValidator(new FullNameValidator());

        RuleFor(x => x.Gender)
            .NotNull()
            .WithMessage(ValidationMessage.NotNull);

        RuleForEach(x => x.CustomFields).SetValidator(new CustomFieldValidator());
    }
}