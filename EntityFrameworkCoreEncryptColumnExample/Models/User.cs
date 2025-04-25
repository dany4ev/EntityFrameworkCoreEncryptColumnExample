using Utilities;

namespace EntityFrameworkCoreEncryptColumnExample.Models;

public record User
{
    public Guid ID { get; set; }
    
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    [Encrypted]
    public required string EmailAddress { get; set; }
    
    [Encrypted]
    public required string IdentityNumber { get; set; }
}
