using System.ComponentModel.DataAnnotations;

namespace Ong.Domain.Interfaces.Base
{
    public interface IBaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
