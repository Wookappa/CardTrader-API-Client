using System.Security.Cryptography;
using System.Text;

namespace CardTraderApi.Client;

/// <summary>
/// Utility to verify the authenticity of webhook notifications from CardTrader.
/// Each original request coming from the Full API is signed by a Signature header,
/// which is the base64 representation of the HMAC digest via SHA256 of the request body,
/// signed with the app's shared_secret.
/// </summary>
public static class WebhookValidator
{
	/// <summary>
	/// Validates that the webhook request was genuinely sent by CardTrader.
	/// </summary>
	/// <param name="requestBody">The raw request body as a string.</param>
	/// <param name="signatureHeader">The value of the Signature header from the request.</param>
	/// <param name="sharedSecret">Your app's shared_secret obtained from GET /info.</param>
	/// <returns>True if the signature is valid; otherwise false.</returns>
	public static bool ValidateSignature(string requestBody, string signatureHeader, string sharedSecret)
	{
		if (string.IsNullOrEmpty(requestBody) || string.IsNullOrEmpty(signatureHeader) || string.IsNullOrEmpty(sharedSecret))
			return false;

		var keyBytes = Encoding.UTF8.GetBytes(sharedSecret);
		var bodyBytes = Encoding.UTF8.GetBytes(requestBody);

		using var hmac = new HMACSHA256(keyBytes);
		var hash = hmac.ComputeHash(bodyBytes);
		var computedSignature = Convert.ToBase64String(hash);

		return CryptographicOperations.FixedTimeEquals(
			Encoding.UTF8.GetBytes(computedSignature),
			Encoding.UTF8.GetBytes(signatureHeader));
	}
}
