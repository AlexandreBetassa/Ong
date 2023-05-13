using AutoMapper;
using Ong.Domain.Command.Usuario.CreateUsuario;
using Ong.Domain.Command.Usuario.UpdateUsuario;

namespace Ong.Domain.MapperProfiles.Usuario
{
    public class CreateUsuarioProfile : Profile
    {
        public CreateUsuarioProfile()
        {
            CreateMap<CreateUsuarioCommand, Entities.Usuario>();
        }
    }
}
