using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PixKeyManager.Data.Model;

[Table("account")]
public class Account
{
	[Key, Required]
    [StringLength(16)]
    public required string Id { get; set; }

    [StringLength(10)]
    public required string Number { get; set; }
    public required string UserId { get; set; }

    public virtual required User User { get; set; }
}