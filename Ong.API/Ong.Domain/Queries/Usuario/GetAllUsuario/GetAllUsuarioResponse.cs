namespace Ong.Domain.Queries.Usuario.GetAllUsuario
{
    public class GetAllUsuarioResponse
    {
        public IEnumerable<Entities.Usuario> Usuarios { get; set; }

        public GetAllUsuarioResponse(IEnumerable<Entities.Usuario> usuarios)
        {
            Usuarios = usuarios;
        }
    }
}