using AutoMapper;
using Ong.Domain.Command.Noticias.UpdateNoticia;

namespace Ong.Domain.MapperProfiles.Animal
{
    public class UpdateAnimalProfile : Profile
    {
        public UpdateAnimalProfile()
        {
            CreateMap<UpdateAnimalCommand, Entities.Animal>(MemberList.Source);
        }
    }
}
