using Ong.Domain.Entities.Base;

namespace Ong.Domain.Entities
{
    public class Comentarios : BaseEntity
    {
        public string Comentario { get; set; }

        public Comentarios(string comentario)
        {
            Comentario = comentario;
        }
    }
}
