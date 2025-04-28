using System.Security.Cryptography;

namespace Utilities
{
    public static class EncryptionHelper
    {
        public static string Encrypt(string plainText, string encryptionKey)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Convert.FromBase64String(encryptionKey);
            aesAlg.IV = GenerateRandomIV(); // Generate a random IV for each encryption

            aesAlg.Padding = PaddingMode.PKCS7; // Set the padding mode to PKCS7

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msEncrypt = new();
            using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using StreamWriter swEncrypt = new(csEncrypt);
                swEncrypt.Write(plainText);
            }

            var encryptedText = Convert.ToBase64String(aesAlg.IV.Concat(msEncrypt.ToArray()).ToArray());
            return encryptedText;
        }

        public static string Decrypt(string cipherText, string encryptionKey)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Convert.FromBase64String(encryptionKey);
            aesAlg.IV = [.. cipherBytes.Take(16)];

            aesAlg.Padding = PaddingMode.PKCS7; // Set the padding mode to PKCS7

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msDecrypt = new(cipherBytes, 16, cipherBytes.Length - 16);
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);
            var decryptedText = srDecrypt.ReadToEnd();
            return decryptedText;
        }

        private static byte[] GenerateRandomIV()
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.GenerateIV();
            return aesAlg.IV;
        }

        public static string GenerateRandomKey(int keySizeInBits)
        {
            // Convert the key size to bytes
            int keySizeInBytes = keySizeInBits / 8;

            string key = string.Empty;

            //key = GenerateRandomStringWithRNGCryptoServiceProvider(keySizeInBytes);
            key = GetRandomStringWithRandomNumberGenerator();

            return key;
        }

        private static string GenerateRandomStringWithRNGCryptoServiceProvider(int keySizeInBytes)
        {
            // Create a byte array to hold the random key
            byte[] keyBytes = new byte[keySizeInBytes];

            // Use a cryptographic random number generator to fill the byte array
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(keyBytes);
            }

            // Convert the byte array to a base64-encoded string for storage
            string key = Convert.ToBase64String(keyBytes);
            return key;
        }

        private static string GetRandomStringWithRandomNumberGenerator()
        {
            var randomNumber = new byte[32];
            string randomKey = string.Empty;

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                randomKey = Convert.ToBase64String(randomNumber);
            }

            return randomKey;
        }
    }
}