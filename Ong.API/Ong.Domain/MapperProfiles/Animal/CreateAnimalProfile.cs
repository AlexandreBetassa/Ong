using AutoMapper;
using Ong.Domain.Command.Animal.CreateAnimal;

namespace Ong.Domain.MapperProfiles.Animal
{
    public class CreateAnimalProfile : Profile
    {
        public CreateAnimalProfile()
        {
            CreateMap<CreateAnimalCommand, Entities.Animal>();
        }
    }
}
