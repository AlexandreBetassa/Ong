namespace Ong.Domain.Queries.Usuario.GetAllUsuario
{
    public class GetAllUsuarioQueryResponse
    {
        public IEnumerable<Entities.Usuario> Usuarios { get; set; }

        public GetAllUsuarioQueryResponse(IEnumerable<Entities.Usuario> usuarios)
        {
            Usuarios = usuarios;
        }
    }
}