using System;
using Xunit;
using global::encryptionDecryptionProject;

public class UnitTest1
{
    // Testing encryption
    [Theory]
    [InlineData("Hello", 3, "S2hvb3I=")] // a2hvb3I=
    [InlineData("webapi", 5, "YmpnZnVu")]
    //Input: hello, Encrypted: khoor
    // Input: webapi, Encrypted: bjgfun
    public void EncryptStringToBytes_ShouldEncryptCorrectly(string input, int shift, string expected)
    {
        // Arrange
        var cipherService = new encryptionDecryptionProject.CaesarCipherAlgorithm();

        // Act
        byte[] result = cipherService.EncryptStringToBytes(input, shift);

        // Assert
        string encryptedResult = Convert.ToBase64String(result);
        Assert.Equal(expected, encryptedResult);
    }

    // Testing decryption
    [Theory]
    [InlineData("S2hvb3I=", 3, "Hello")]
    [InlineData("YmpnZnVu", 5, "webapi")]
    public void DecryptStringFromBytes_ShouldDecryptCorrectly(string input, int shift, string expected)
    {
        // Arrange
        var cipherService = new encryptionDecryptionProject.CaesarCipherAlgorithm();

        // Convert the Base64-encoded input to bytes
        byte[] encryptedBytes = Convert.FromBase64String(input);

        // Act
        string result = cipherService.DecryptStringFromBytes(encryptedBytes, shift);

        // Assert
        Assert.Equal(expected, result);
    }
}