using System.ComponentModel.DataAnnotations;

namespace Ong.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
