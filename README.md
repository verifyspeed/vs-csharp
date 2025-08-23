# VerifySpeed C#/.NET Client Library

[![NuGet](https://img.shields.io/nuget/v/VerifySpeed.VSCSharp.svg)](https://www.nuget.org/packages/VerifySpeed.VSCSharp)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

A powerful and secure .NET client library for integrating VerifySpeed user verification services into your C# applications. Support for multiple verification methods including Telegram, WhatsApp, and SMS.

## 🚀 Features

- **Multiple Verification Methods**: Support for Telegram, WhatsApp, and SMS verification
- **Local Token Decryption**: Decrypt verification tokens locally for enhanced security and performance
- **Dependency Injection Ready**: Seamless integration with .NET Core/5+ dependency injection
- **Async/Await Support**: Full async support for all operations
- **Comprehensive Error Handling**: Detailed exception types for better error management
- **Cross-Platform**: Works on Windows, macOS, and Linux

## 📦 Installation

### NuGet Package

```bash
dotnet add package VerifySpeed.VSCSharp
```

### Package Manager Console

```powershell
Install-Package VerifySpeed.VSCSharp
```

## 🏗️ Quick Start

### 1. Service Registration

#### .NET 6+
```csharp
using VSCSharp;

var builder = WebApplication.CreateBuilder(args);

// Register VerifySpeed services
builder.Services.AddVerifySpeed("YOUR_SERVER_KEY");

var app = builder.Build();
app.Run();
```

#### .NET 5
```csharp
using VSCSharp;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddVerifySpeed("YOUR_SERVER_KEY");
    }
}
```

### 2. Basic Usage

```csharp
public class VerificationService
{
    private readonly IVerifySpeedClient _verifySpeedClient;

    public VerificationService(IVerifySpeedClient verifySpeedClient)
    {
        _verifySpeedClient = verifySpeedClient;
    }

    public async Task<VerificationResult> VerifyUserAsync(string token)
    {
        try
        {
            // Decrypt token locally (recommended)
            var result = _verifySpeedClient.DecryptVerificationToken(token);
            
            // Or use API verification
            // var result = await _verifySpeedClient.VerifyTokenAsync(token);
            
            // The result contains the user's phone number, verification method, and date
            // result.PhoneNumber - The verified user's phone number
            // result.MethodName - The verification method used (e.g., "telegram-message")
            // result.DateOfVerification - When the verification was completed
            
            return result;
        }
        catch (InvalidVerificationTokenException ex)
        {
            // Handle invalid token
            throw;
        }
    }
}
```

## 📚 Documentation

**📖 Full Documentation**: [http://doc.verifyspeed.com/docs/Integrations/backend/sdks/csharpdotnet](http://doc.verifyspeed.com/docs/Integrations/backend/sdks/csharpdotnet)

The complete documentation covers:
- [Initializing the Client](http://doc.verifyspeed.com/docs/Integrations/backend/sdks/csharpdotnet#1-initializing-the-client)
- [Creating Verifications](http://doc.verifyspeed.com/docs/Integrations/backend/sdks/csharpdotnet#2-creating-a-verification)
- [Decrypting Verification Tokens](http://doc.verifyspeed.com/docs/Integrations/backend/sdks/csharpdotnet#3-decrypting-verification-tokens-recommended)
- [API Examples](http://doc.verifyspeed.com/docs/Integrations/backend/sdks/csharpdotnet#api-example)
- [Models and Exceptions](http://doc.verifyspeed.com/docs/Integrations/backend/sdks/csharpdotnet#models)

## 🔐 Verification Methods

- **Telegram Message**: Send verification codes via Telegram
- **Telegram OTP**: Receiving OTP code via Telegram
- **WhatsApp Message**: Send verification codes via WhatsApp
- **WhatsApp OTP**: Receiving OTP code via WhatsApp
- **SMS OTP**: Receiving OTP code via SMS

## 📋 Requirements

- **.NET 5.0** or later
- **C# 9.0** or later
- **VerifySpeed Account** with server key

## 🔧 Configuration

### Environment Variables

```bash
VERIFYSPEED_SERVER_KEY=your_server_key_here
```

### appsettings.json

```json
{
  "VerifySpeed": {
    "ServerKey": "your_server_key_here"
  }
}
```

## 📖 Examples

### Initialize Verification

```csharp
public async Task InitializeVerificationAsync()
{
    try
    {
        var clientIp = "192.168.1.1"; // Replace with actual client IP
        var initialization = await _verifySpeedClient.InitializeAsync(clientIp);
        
        foreach (var method in initialization.AvailableMethods)
        {
            Console.WriteLine($"- {method.DisplayName} ({method.MethodName})");
        }
    }
    catch (FailedInitializationException ex)
    {
        Console.WriteLine($"Initialization failed: {ex.Message}");
    }
}
```

### Create Verification

```csharp
public async Task<CreatedVerification> CreateVerificationAsync()
{
    try
    {
        var clientIp = "192.168.1.1"; // Replace with actual client IP
        var verification = await _verifySpeedClient.CreateVerificationAsync(
            methodName: "telegram-message",
            clientIPv4Address: clientIp,
            language: "en"
        );
        
        return verification;
    }
    catch (FailedCreateVerificationException ex)
    {
        Console.WriteLine($"Failed to create verification: {ex.Message}");
        throw;
    }
}
```

## 🚨 Exception Handling

The library provides specific exception types for better error handling:

```csharp
try
{
    var result = _verifySpeedClient.DecryptVerificationToken(token);
}
catch (InvalidVerificationTokenException ex)
{
    // Token is null, empty, or has invalid format
    Console.WriteLine($"Invalid token: {ex.Message}");
}
catch (FailedDecryptingVerificationTokenException ex)
{
    // Cryptographic error during decryption
    Console.WriteLine($"Decryption failed: {ex.Message}");
}
catch (FailedVerifyingTokenException ex)
{
    // API verification failed
    Console.WriteLine($"Verification failed: {ex.Message}");
}
```

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🆘 Support

- **Documentation**: [http://doc.verifyspeed.com/docs/Integrations/backend/sdks/csharpdotnet](http://doc.verifyspeed.com/docs/Integrations/backend/sdks/csharpdotnet)
- **Issues**: [GitHub Issues](https://github.com/verifyspeed/vs-csharp/issues)

## 🔗 Related Links

- [VerifySpeed Main Website](https://verifyspeed.com)
- [API Documentation](https://doc.verifyspeed.com)
- [Other SDKs](https://github.com/verifyspeed)

---

**Made with ❤️ by the VerifySpeed Team**
