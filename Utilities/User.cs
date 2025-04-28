namespace Utilities;

public class User
{
    public Guid ID { get; set; }
    
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;

    //[Encrypted]
    public string EmailAddress { get; set; } = string.Empty;

    //[Encrypted]
    public string IdentityNumber { get; set; } = string.Empty;

    public string EncryptionKey { get; set; } = string.Empty;
}
