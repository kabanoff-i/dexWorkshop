using FluentValidation;
using Domain.Entities;
using Domain.Primitives;

namespace Domain.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FullName).SetValidator(new FullNameValidator());

            RuleFor(x => x.Birthday)
                .NotEmpty().WithMessage(ValidationMessage.NotEmpty(nameof(Person.Birthday)))
                .Must(BeAValidAge).WithMessage(ValidationMessage.InvalidPropetry(nameof(Person.Birthday)));

            RuleFor(x => x.Gender)
                .IsInEnum().WithMessage(ValidationMessage.InvalidPropetry(nameof(Person.Gender)));

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage(ValidationMessage.NotEmpty(nameof(Person.PhoneNumber)))
                .Matches(@"^\+37377[4-9]\d{5}$").WithMessage(ValidationMessage.InvalidPropetry(nameof(Person.PhoneNumber)));

            RuleFor(x => x.Telegram)
                .NotEmpty().WithMessage(ValidationMessage.NotEmpty(nameof(Person.Telegram)))
                .Must(BeAValidTelegram).WithMessage(ValidationMessage.InvalidPropetry(nameof(Person.Telegram)));
        }

        private bool BeAValidAge(DateTime birthDate)
        {
            var age = DateTime.Now.Year - birthDate.Year;
            return age <= 150;
        }

        private bool BeAValidTelegram(string telegram)
        {
            return telegram.StartsWith("@");
        }
    }
}