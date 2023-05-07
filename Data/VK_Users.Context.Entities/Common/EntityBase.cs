
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VK_Users.Context.Entities;

public abstract class EntityBase
{
    [Key]
    [Column("uid")]
    public Guid Uid { get; set; }
}
