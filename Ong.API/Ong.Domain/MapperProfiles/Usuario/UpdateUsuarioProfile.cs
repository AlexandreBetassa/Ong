using AutoMapper;
using Ong.Domain.Command.Usuario.UpdateUsuario;

namespace Ong.Domain.MapperProfiles.Usuario
{
    public class UpdateUsuarioProfile : Profile
    {
        public UpdateUsuarioProfile()
        {
            CreateMap<UpdateUsuarioCommand, Entities.Usuario>();
        }
    }
}
