using Domain.Primitives;

namespace Application.Dtos;

public class PersonCreateResponse
{
    public Guid Id { get; private set; }
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
    public DateTime BirthDay { get; set; }

    public int Age;
        
    public Gender Gender { get; set; }

    public string PhoneNumber { get; set; }

    public string Telegram {  get; set; }
}