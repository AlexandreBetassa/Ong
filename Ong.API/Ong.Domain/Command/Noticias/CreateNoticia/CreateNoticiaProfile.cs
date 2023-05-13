using AutoMapper;
using Ong.Domain.Entities;

namespace Ong.Domain.Command.Noticias.CreateNoticia
{
    public class CreateNoticiaProfile : Profile
    {
        public CreateNoticiaProfile()
        {
            CreateMap<CreateNoticiaCommand, Noticia>(MemberList.Destination);
        }
    }
}
