using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Http;

namespace UnitTest;

// flyttade filer

/**
To run the tests you need to start up the main project, in the terminal to Project file run: dotnet run
See which localhost server is opened and update BaseAddress to the right one (line 26)
ex. BaseAddress = new Uri("http://localhost:5242")
In the terminal to UnitTest file run: dotnet test
**/

public class UnitTest1
{
    private readonly HttpClient _client;

    public UnitTest1()
    {
        // Create an instance of HttpClient with your server URL
        _client = new HttpClient
        {
            // Update with your current localhost after you start the project
            BaseAddress = new Uri("http://localhost:5070")
        };
    }

    [Fact]
    public async Task EncryptMessage_ShouldReturnEncryptedString()
    {
        // Act
        var response = await _client.GetAsync("/encrypt/hello/3");
        var result = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.Contains("Encrypted message", result);
        Assert.Equal(StatusCodes.Status200OK, (int)response.StatusCode);
    }

    // TODO: write a decrypt test
    // [Fact]
    // public async Task DecryptMessage_ShouldReturnDecryptedString()
    // {
    //     // Act
    //     var response = await _client.GetAsync("/decrypt");
    //     var result = await response.Content.ReadAsStringAsync();
    //     Console.WriteLine(result);

    //     // Assert
    //     Assert.Contains("Decrypted message", result);
    //     Assert.Equal(StatusCodes.Status200OK, (int)response.StatusCode);

    //     // Additional check: Ensure decrypted message matches the original
    //     Assert.Contains("Original message:", result);
    // }
}