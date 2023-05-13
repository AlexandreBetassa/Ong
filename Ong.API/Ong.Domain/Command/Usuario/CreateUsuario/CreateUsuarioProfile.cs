using AutoMapper;

namespace Ong.Domain.Command.Usuario.CreateUsuario
{
    public class CreateUsuarioProfile : Profile
    {
        public CreateUsuarioProfile()
        {
            CreateMap<CreateUsuarioCommand, Entities.Usuario>();
        }
    }
}
