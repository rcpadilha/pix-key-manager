using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PixKeyManager.Data.Model;

[Table("keys")]
public class Key
{
	[Key, Required]
    [StringLength(16)]
    public string? Id { get; set; }

    [StringLength(140)]
    public required string Value { get; set; }

    [StringLength(10)]
    public required string Type { get; set; }

	public required string AccountId { get; set; }
    public Account? Account { get; set; }
}
