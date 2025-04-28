namespace Utilities
{
    public class ReverseCryptographyService(string encryptionKey) : ICryptographyService
    {
        private readonly string EncryptionKey = encryptionKey;

        public string Encrypt(string data)
        {
            string EncryptedText = EncryptionHelper.Encrypt(data, EncryptionKey);
            return EncryptedText;
        }

        public string Decrypt(string data)
        {
            string DecryptedText = EncryptionHelper.Decrypt(data, EncryptionKey);
            return DecryptedText;
        }
    }
}