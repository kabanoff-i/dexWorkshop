using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class PersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }
    public PersonGetByIdResponse GetById(Guid id)
    {
        var person = _personRepository.GetById(id);
        var response = _mapper.Map<PersonGetByIdResponse>(person);
        return response;
    }
    public PersonCreateResponse Create(PersonCreateRequest personCreateRequest)
    {
        var person = _mapper.Map<Person>(personCreateRequest);
        var createdPerson = _personRepository.Create(person);
        var response = _mapper.Map<PersonCreateResponse>(createdPerson);
        return response;
    }

    public void Delete(Guid id)
    {
        _personRepository.Delete(id);
    }

    public PersonUpdateResponse Update(PersonUpdateRequest personUpdateRequest)
    {
        var person = _personRepository.GetById(personUpdateRequest.Id);
        _mapper.Map(personUpdateRequest, person);
        var updatedPerson = _personRepository.Update(person);
        var response = _mapper.Map<PersonUpdateResponse>(updatedPerson);
        return response;
    }
}