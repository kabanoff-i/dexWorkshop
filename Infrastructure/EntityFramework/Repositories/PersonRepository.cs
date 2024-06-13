using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.EntityFramework.Repositories;

public class PersonRepository: IPersonRepository
{
    private readonly TelegramBotDbContext _telegramBotDbContext;

    public PersonRepository(TelegramBotDbContext telegramBotDbContext)
    {
        _telegramBotDbContext = telegramBotDbContext;
    }
    public Person? GetById(Guid id)
    {
        return _telegramBotDbContext.Persons.FirstOrDefault(x => x.Id == id);
    }

    public List<Person> GetAll()
    {
        return _telegramBotDbContext.Persons.ToList();
    }

    public Person Update(Person person)
    {
        _telegramBotDbContext.Update(person);
        return person;
    }

    public Person Create(Person person)
    {
        _telegramBotDbContext.Add(person);
        return person;
    }

    public bool Delete(Guid id)
    {
        var removedPerson = _telegramBotDbContext.Persons.FirstOrDefault(x => x.Id == id);
        if (removedPerson != null)
        {
            _telegramBotDbContext.Persons.Remove(removedPerson);
            return true;
        }
        return false;
    }
    
    public List<CustomField<string>> GetCustomFields(Guid personId)
    {
        var person = _telegramBotDbContext.Persons.FirstOrDefault(x => x.Id == personId);
        if (person == null)
            throw new Exception("Not found");
        return person.CustomFields;
    }
}