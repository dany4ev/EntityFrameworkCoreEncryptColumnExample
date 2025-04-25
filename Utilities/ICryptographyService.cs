namespace Utilities
{
    public interface ICryptographyService
    {
        public string EncryptionKey { get; set; }
        public (string DecryptedText, string EncryptionKey) Decrypt(string data);
        public (string EncryptedText, string EncryptionKey) Encrypt(string data);
    }
}