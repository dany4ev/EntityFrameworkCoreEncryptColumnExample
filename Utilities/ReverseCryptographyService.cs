namespace Utilities
{
    public class ReverseCryptographyService(string encryptionKey) : ICryptographyService
    {
        public string Encrypt(string data)
        {
            string EncryptedText = EncryptionHelper.Encrypt(data, encryptionKey);
            return EncryptedText;
        }

        public string Decrypt(string data)
        {
            string DecryptedText = EncryptionHelper.Decrypt(data, encryptionKey);
            return DecryptedText;
        }
    }
}