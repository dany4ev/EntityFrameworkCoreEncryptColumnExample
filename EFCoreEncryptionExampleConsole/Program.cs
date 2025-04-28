using Utilities;

namespace EFCoreEncryptionExampleConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var content = "Example test"; // Text content to encrypt and protect
            var key = "E546C8DF278CD5931069B522E695D4F2"; // EncryptionKey this can be generated randomnly using some tool or programmatically

            AddSeparator();

            EncryptionDecryptionExample1(content, key);

            AddSeparator();

            EncryptionDecryptionExample2(content);

            Console.ReadLine();
        }

        private static void AddSeparator()
        {
            Console.WriteLine("====================================");
            Console.WriteLine();
        }

        private static void EncryptionDecryptionExample2(string content)
        {
            ICryptographyService cryptographyService = new ReverseCryptographyService();
            var encrypted = cryptographyService.Encrypt(content);
            Console.WriteLine(encrypted);

            var decrypted = cryptographyService.Decrypt(encrypted);
            Console.WriteLine(decrypted);
        }

        private static void EncryptionDecryptionExample1(string content, string key)
        {
            var encrypted = EncryptionHelper.Encrypt(content, key);
            Console.WriteLine(encrypted);

            var decrypted = EncryptionHelper.Decrypt(encrypted, key);
            Console.WriteLine(decrypted);
        }
    }
}
