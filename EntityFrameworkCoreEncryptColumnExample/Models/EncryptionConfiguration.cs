using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreEncryptColumnExample.Models;

public record EncryptionConfiguration
{
    [Key]
    public Guid ID { get; set; }
    
    public required string EncryptedPassword { get; set; }

    public string PasswordHash { get; set; } = string.Empty;
    
    public bool IsReset { get; set; }

}