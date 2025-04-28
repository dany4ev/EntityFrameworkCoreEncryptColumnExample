namespace Utilities
{
    public interface ICryptographyService
    {
        public string Decrypt(string data);
        public string Encrypt(string data);
    }
}