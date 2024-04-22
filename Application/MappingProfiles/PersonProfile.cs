using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Application.MappingProfiles;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<PersonCreateRequest, Person>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => new FullName(src.FirstName, src.LastName, src.MiddleName)))
            .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.BirthDay))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse<Gender>(src.Gender)))
            .ForMember(dest => dest.CustomFields, opt => opt.Ignore()); // Игнорирование, так как не задается при создании

        CreateMap<Person, PersonUpdateResponse>(); // Маппинг для ответа обновления

        CreateMap<PersonUpdateRequest, Person>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); // Обновляет поля только если они не null
    }
}