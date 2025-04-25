namespace Utilities
{
    public class ReverseCryptographyService : ICryptographyService
    {
        public (string EncryptedText, string EncryptionKey) Encrypt(string data)
        {
            (string EncryptedText, string EncryptionKey) result = EncryptionHelper.Encrypt(data);
            return result;
        }

        public (string DecryptedText, string EncryptionKey) Decrypt(string data)
        {
            (string DecryptedText, string EncryptionKey) result = EncryptionHelper.Decrypt(data);
            return result;
        }
    }
}