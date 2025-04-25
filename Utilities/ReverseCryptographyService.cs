namespace Utilities
{
    public class ReverseCryptographyService : ICryptographyService
    {
        public string EncryptionKey { get; set; } = string.Empty;

        public (string EncryptedText, string EncryptionKey) Encrypt(string data)
        {
            (string EncryptedText, string EncryptionKey) result = EncryptionHelper.Encrypt(data);
            EncryptionKey = result.EncryptionKey;
            return result;
        }

        public (string DecryptedText, string EncryptionKey) Decrypt(string data)
        {
            (string DecryptedText, string EncryptionKey) result = EncryptionHelper.Decrypt(data);
            EncryptionKey = result.EncryptionKey;
            return result;
        }
    }
}