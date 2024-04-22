namespace Domain.Primitives;

public static class ValidationMessage
{
    public static Func<string, string> NotNull { get; set; } =
        (propertyName) => $"Свойство {propertyName} не может быть NULL";
    public static Func<string, string> NotEmpty { get; set; } =
        (propertyName) => $"Свойство {propertyName} не может быть пустым";
    public static Func<string, string> InvalidPropetry { get; set; } =
        (propertyName) => $"Свойство {propertyName} имеет недопустимое значение";
}