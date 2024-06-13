using Domain.Entities;

namespace Application.Interfaces;

public interface IPersonRepository:IRepository<Person>
{
    public List<CustomField<string>> GetCustomFields(Guid personId);
}