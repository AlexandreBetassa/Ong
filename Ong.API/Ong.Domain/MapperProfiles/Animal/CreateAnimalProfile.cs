using AutoMapper;
using Ong.Domain.Command.Animal.CreateAnimal;

namespace Ong.Domain.MapperProfiles.Animal
{
    public class CreateAnimalProfile : Profile
    {
        public CreateAnimalProfile()
        {
            CreateMap<CreateAnimalCommand, Entities.Animal>();

            CreateMap<Entities.Animal, CreateAnimalResponse>(MemberList.None)
             .ForMember(dest => dest.Id, src => src.MapFrom(opt => opt.Id));
        }
    }
}
