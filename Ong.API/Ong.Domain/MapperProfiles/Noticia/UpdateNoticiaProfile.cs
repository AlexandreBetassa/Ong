using AutoMapper;

namespace Ong.Domain.MapperProfiles.Noticia
{
    public class UpdateNoticiaProfile : Profile
    {
        public UpdateNoticiaProfile()
        {
            CreateMap<UpdateNoticiaProfile, Entities.Noticia>();
        }
    }
}
