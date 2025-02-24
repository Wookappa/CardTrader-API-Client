using CardTraderApi.Client.Models;
using System.Net;

namespace CardTraderApi.Client;

public class CardTraderApiException : Exception
{
	public CardTraderApiException(string message) : base(message) { }
	public HttpStatusCode ResponseStatusCode { get; set; }
	public Uri RequestUri { get; set; }
	public HttpMethod RequestMethod { get; set; }
	public Error CardTraderError { get; set; }
}
