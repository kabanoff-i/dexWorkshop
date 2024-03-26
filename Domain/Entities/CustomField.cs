using Domain.Validators;

namespace Domain.Entities;

public class CustomField: BaseEntity
{
    public CustomField()
    {
        var validator = new CustomFieldValidator();

        validator.Validate(this);
    }
    /// <summary>
    /// Название поля
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Значение поля
    /// </summary>
    public string Value { get; set; }
}