namespace Domain.Entities;

public class CustomField: BaseEntity
{
    /// <summary>
    /// Название поля
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Значение поля
    /// </summary>
    public string Value { get; set; }
}