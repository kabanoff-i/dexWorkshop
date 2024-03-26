namespace Domain.Primitives;

public static class ValidationMessage
{
    public static string NotNull { get; set; } = "Это значение ноль";
    public static string NotEmpty { get; set; } = "Это значение пустое";
}