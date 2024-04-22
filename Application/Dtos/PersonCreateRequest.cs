namespace Application.Dtos;

public class PersonCreateRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime BirthDay { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string Telegram { get; set; }
}