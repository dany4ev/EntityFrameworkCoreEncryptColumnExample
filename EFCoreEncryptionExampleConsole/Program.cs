using Utilities;

namespace EFCoreEncryptionExampleConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var content = "Example test"; // Text content to encrypt and protect
            var key = "E546C8DF278CD5931069B522E695D4F2"; // EncryptionKey this can be generated randomnly using some tool or programmatically
            string encryptionKey = EncryptionHelper.GenerateRandomKey(256); // Create a random encryption key and save it for the values being saved in database

            Console.WriteLine(encryptionKey);
            Console.WriteLine(key);

            AddSeparator();

            EncryptionDecryptionExample1(content, key);

            AddSeparator();

            EncryptionDecryptionExample2(content, key);

            AddSeparator();

            EncryptionDecryptionExample3(content, encryptionKey);

            Console.ReadLine();
        }

        private static void AddSeparator()
        {
            Console.WriteLine("====================================");
            Console.WriteLine();
        }

        private static void EncryptionDecryptionExample3(string content, string encryptionKey)
        {
            ICryptographyService cryptographyService = new ReverseCryptographyService(encryptionKey);
            var encrypted = cryptographyService.Encrypt(content);
            Console.WriteLine(encrypted);

            var decrypted = cryptographyService.Decrypt(encrypted);
            Console.WriteLine(decrypted);
        }

        private static void EncryptionDecryptionExample2(string content, string key)
        {
            string encryptionKey = EncryptionHelper.GenerateRandomKey(256);

            var encrypted = EncryptionHelper.Encrypt(content, encryptionKey);
            Console.WriteLine(encrypted);

            var decrypted = EncryptionHelper.Decrypt(encrypted, encryptionKey);
            Console.WriteLine(decrypted);
        }

        private static void EncryptionDecryptionExample1(string content, string encrytionKey)
        {

            var encrypted = EncryptionHelper2.EncryptString(content, encrytionKey);
            Console.WriteLine(encrypted);

            var decrypted = EncryptionHelper2.DecryptString(encrypted, encrytionKey);
            Console.WriteLine(decrypted);
        }
    }
}
