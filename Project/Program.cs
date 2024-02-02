using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

// flyttade filer

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Memory storage for encrypted message and shift value
byte[] encryptedMessage = null;
int shiftValue = 0;

app.MapGet("/", () => "Hello! \n To encrypt a message: /encrypt/{message}/{shift} \n To decrypt that message: /decrypt");

app.MapGet("/encrypt/{message}/{shift}", (string message, int shift) =>
{
    // Encrypt message using Caesar Cipher
    encryptedMessage = EncryptStringToBytes(message, shift);
    shiftValue = shift;

    return $"Encrypted message: {Convert.ToBase64String(encryptedMessage)}";
});

app.MapGet("/decrypt", () =>
{
    // Decrypt the encrypted message using the stored shift value
    string decryptedMessage = DecryptStringFromBytes(encryptedMessage, shiftValue);

    return $"Decrypted message: {decryptedMessage}";
});

app.Run();

// Encrypt a string using Caesar Cipher
byte[] EncryptStringToBytes(string text, int shift)
{
    // Convert string to char array
    char[] chars = text.ToCharArray();

    // Shift each character by the specified amount
    for (int i = 0; i < chars.Length; i++)
    {
        char c = chars[i];

        // Encrypt the alphabetical characters
        if (char.IsLetter(c))
        {
            char offset = char.IsUpper(c) ? 'A' : 'a';
            chars[i] = (char)((c + shift - offset) % 26 + offset);
        }
    }

    // Convert char array back to string
    string encryptedText = new string(chars);

    // Convert string to bytes
    return Encoding.UTF8.GetBytes(encryptedText);
}

// Decrypt a string using Caesar Cipher
string DecryptStringFromBytes(byte[] encryptedText, int shift)
{
    // Convert bytes to string
    string encryptedString = Encoding.UTF8.GetString(encryptedText);

    // Convert string to char array
    char[] chars = encryptedString.ToCharArray();

    // Shift each character back by the specified amount
    for (int i = 0; i < chars.Length; i++)
    {
        char c = chars[i];

        // Decrypt the alphabetical characters
        if (char.IsLetter(c))
        {
            char offset = char.IsUpper(c) ? 'A' : 'a';
            chars[i] = (char)((c - shift - offset + 26) % 26 + offset);
        }
    }

    // Convert char array back to string
    return new string(chars);
}
