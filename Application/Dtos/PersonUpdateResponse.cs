namespace Application.Dtos;

public class PersonUpdateResponse
{
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string? FirstName { get; private set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string? LastName { get; private set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string? MiddleName { get; private set; }
}