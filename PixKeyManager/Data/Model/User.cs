using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PixKeyManager.Data.Model;

[Table("user")]
public class User
{
	[Key, Required]
    [StringLength(36)]
    public string? Id { get; set; }

    [StringLength(50)]
    public required string Login { get; set; }

    [StringLength(255)]
    public required string Password { get; set; }
}

