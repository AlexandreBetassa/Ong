using System.ComponentModel.DataAnnotations;

namespace Ong.Domain.Interfaces.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
