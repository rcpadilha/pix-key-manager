using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PixKeyManager.Data.Model;

[Table("keys")]
public class Key
{
	[Key, Required]
    [StringLength(36)]
    public string? Id { get; set; }

    [StringLength(140)]
    public required string Value { get; set; }

    [StringLength(10)]
    public required string Type { get; set; }

    public required DateTime CreatedAt { get; set; }

	public required string AccountId { get; set; }
    public virtual Account? Account { get; set; }
}
