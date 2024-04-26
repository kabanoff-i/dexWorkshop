using Domain.Validators;

namespace Domain.Entities;

public class CustomField<T>: BaseEntity
{
    public CustomField()
    {
        var validator = new CustomFieldValidator<T>();

        validator.Validate(this);
    }
    /// <summary>
    /// Название поля
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Значение поля
    /// </summary>
    public T Value { get; set; }
    public Guid PersonId { get; set; }
    public Person Person { get; set; } = null!;
}