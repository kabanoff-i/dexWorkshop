using Domain.Validators;


namespace Domain.ValueObjects;

public class FullName : BaseValueObject
{
    public FullName(string firstName, string lastName, string middleName)
    {
        var validator = new FullNameValidator();
        validator.Validate(this);
    }

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; private set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; private set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string? MiddleName { get; private set; } = null;

    public FullName Update(string? firstName, string? lastName, string? middleName)
    {
        if (firstName is not null)
        {
            FirstName = firstName;
        }

        if (lastName is not null)
        {
            LastName = lastName;
        }

        if (middleName is not null)
        {
            MiddleName = middleName;
        }

        var validator = new FullNameValidator();
        validator.Validate(this);

        return this;
    }
}