namespace Utilities
{
    public interface ICryptographyService
    {
        (string DecryptedText, string EncryptionKey) Decrypt(string data);
        (string EncryptedText, string EncryptionKey) Encrypt(string data);
    }
}