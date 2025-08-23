using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using VSCSharp.Exceptions;
using VSCSharp.Models.Commons;

namespace VSCSharp.Tools
{
	/// <summary>
	/// Provides extension methods for handling encrypted verification tokens.
	/// </summary>
	public static class EncryptionTool
	{
		/// <summary>
		/// Decrypts an encrypted verification token using the specified server key
		/// and returns the corresponding <see cref="VerificationResult"/> object.
		/// </summary>
		/// <param name="token">The Base64-encoded encrypted token string to decrypt.</param>
		/// <param name="serverKey">
		/// The server key used for AES decryption.
		/// </param>
		/// <returns>
		/// A <see cref="VerificationResult"/> object representing the decrypted token.
		/// </returns>
		/// <exception cref="InvalidVerificationTokenException">
		/// Thrown when the token is <c>null</c>, empty, or cannot be parsed into a valid <see cref="VerificationResult"/>.
		/// </exception>
		/// <exception cref="FailedDecryptingVerificationTokenException">
		/// Thrown when the token cannot be decrypted due to an underlying cryptographic error.
		/// </exception>
		public static VerificationResult DecryptVerificationToken(this string token, string serverKey)
		{
			if (string.IsNullOrWhiteSpace(token))
			{
				throw new InvalidVerificationTokenException("The verification token cannot be null or empty");
			}

			string decrypted = Decrypt(token, serverKey);
			string[] parts = decrypted.Split('|');

			if (parts.Length != 3)
			{
				throw new InvalidVerificationTokenException("The token format is invalid or corrupted");
			}

			string phoneNumber = GetPhoneNumber(parts[0]);
			DateTime dateOfVerification = GetDateOfVerification(parts[1]);
			string methodName = GetMethodName(parts[2]);

			var result = new VerificationResult
			{
				PhoneNumber = phoneNumber, DateOfVerification = dateOfVerification, MethodName = methodName
			};

			return result;
		}

		private static string Decrypt(string token, string serverKey)
		{
			try
			{
				byte[] cipherBytes = Convert.FromBase64String(token);
				using var aes = Aes.Create();
				aes.Key = SHA256.HashData(Encoding.UTF8.GetBytes(serverKey));
				using var memoryStream = new MemoryStream(cipherBytes);
				var iv = new byte[aes.BlockSize / 8];
				_ = memoryStream.Read(iv);
				aes.IV = iv;
				using var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read);
				using var streamReader = new StreamReader(cryptoStream);
				string decrypted = streamReader.ReadToEnd();

				return decrypted;
			}
			catch (Exception exception)
			{
				throw new FailedDecryptingVerificationTokenException(
					message: "Failed to decrypt the verification token",
					exception
				);
			}
		}

		private static string GetMethodName(string methodNamePart) =>
			methodNamePart ?? throw new InvalidVerificationTokenException("The method name part of the token is missing");

		private static DateTime GetDateOfVerification(string? dateOfVerificationPart)
		{
			if (dateOfVerificationPart == null ||
			    !DateTime.TryParse(dateOfVerificationPart, out DateTime dateOfVerification))
			{
				throw new InvalidVerificationTokenException("The date of verification part of the token is invalid");
			}

			return dateOfVerification;
		}

		private static string GetPhoneNumber(string? phoneNumberPart) =>
			phoneNumberPart ?? throw new InvalidVerificationTokenException("The phone number part of the token is missing");
	}
}