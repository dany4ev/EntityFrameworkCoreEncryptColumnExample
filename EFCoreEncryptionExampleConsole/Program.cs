using System.Diagnostics;
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
            var encryptionKey = EncryptionHelper.GenerateRandomKey(256);
            ReverseCryptographyService cryptographyService = new(encryptionKey);

            // Measure time for encryption
            Stopwatch stopwatch = new();
            stopwatch.Start();
            string encryptedText = cryptographyService.Encrypt(content);
            stopwatch.Stop();
            Console.WriteLine($"Encryption Time: {stopwatch.ElapsedMilliseconds} ms");

            // Measure time for decryption
            stopwatch.Restart();
            string decryptedText = cryptographyService.Decrypt(encryptedText);
            stopwatch.Stop();
            Console.WriteLine($"Decryption Time: {stopwatch.ElapsedMilliseconds} ms");

            Console.WriteLine($"Original Text: {content}");
            Console.WriteLine($"Encrypted Text: {encryptedText}");
            Console.WriteLine($"Decrypted Text: {decryptedText}");
        }

        private static void EncryptionDecryptionExample1(string content, string key)
        {
            // Measure time for encryption
            Stopwatch stopwatch = new();
            stopwatch.Start();
            string encryptedText = EncryptionHelper.Encrypt(content, key);
            stopwatch.Stop();
            Console.WriteLine($"Encryption Time: {stopwatch.ElapsedMilliseconds} ms");

            // Measure time for decryption
            stopwatch.Restart();
            string decryptedText = EncryptionHelper.Decrypt(encryptedText, key);
            stopwatch.Stop();
            Console.WriteLine($"Decryption Time: {stopwatch.ElapsedMilliseconds} ms");

            Console.WriteLine($"Original Text: {content}");
            Console.WriteLine($"Encrypted Text: {encryptedText}");
            Console.WriteLine($"Decrypted Text: {decryptedText}");
        }
    }
}
