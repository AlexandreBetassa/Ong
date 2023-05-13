using AutoMapper;
using Ong.Domain.Command.Noticias.CreateNoticia;
using Ong.Domain.Entities;

namespace Ong.Domain.MapperProfiles.Noticia
{
    public class CreateNoticiaProfile : Profile
    {
        public CreateNoticiaProfile()
        {
            CreateMap<CreateNoticiaCommand, Entities.Noticia>(MemberList.Destination);
        }
    }
}
