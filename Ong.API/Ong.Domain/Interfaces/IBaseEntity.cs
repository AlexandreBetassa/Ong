using System.ComponentModel.DataAnnotations;

namespace Ong.Domain.Interfaces
{
    public interface IBaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
