using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PixKeyManager.Data.Model;

[Table("account")]
public class Account
{
	[Key, Required]
    [StringLength(36)]
    public string? Id { get; set; }

    [StringLength(10)]
    public required string Number { get; set; }
    public string? UserId { get; set; }

    public virtual required User User { get; set; }
}