namespace encryptionDecryptionProject
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Text;

    public class CaesarCipherAlgorithm
    {
        public byte[] EncryptStringToBytes(string text, int shift)
        {
            char[] chars = text.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];

                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    chars[i] = (char)((c + shift - offset) % 26 + offset);
                }
            }

            string encryptedText = new string(chars);
            Console.WriteLine($"Input: {text}, Encrypted: {encryptedText}");
            return Encoding.UTF8.GetBytes(encryptedText);
        }

        public string DecryptStringFromBytes(byte[] encryptedText, int shift)
        {
            string encryptedString = Encoding.UTF8.GetString(encryptedText);
            char[] chars = encryptedString.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];

                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    chars[i] = (char)((c - shift - offset + 26) % 26 + offset);
                }
            }

            return new string(chars);
        }
    }

    class Program
    {
        private static byte[] encryptedMessage;
        private static int shiftValue;

        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            var ceasarAlg = new CaesarCipherAlgorithm();

            app.MapGet("/", () => "Hello! \nTo encrypt a message: /encrypt/{message}/{shift} \nTo decrypt that message: /decrypt");

            app.MapGet("/encrypt/{message}/{shift}", (string message, int shift) =>
            {
                encryptedMessage = ceasarAlg.EncryptStringToBytes(message, shift);
                shiftValue = shift; // store shift value for decryption
                return $"Encrypted message: {Convert.ToBase64String(encryptedMessage)}";
            });

            app.MapGet("/decrypt", () =>
            {
                // Decrypt the encrypted message using the stored shift value
                string decryptedMessage = ceasarAlg.DecryptStringFromBytes(encryptedMessage, shiftValue);

                return $"Decrypted message: {decryptedMessage}";
            });

            app.Run();
        }
    }
}