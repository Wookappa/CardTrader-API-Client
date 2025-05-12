namespace CardTraderApi.Client
{
	public interface ITokenProvider
	{
		string JwtToken { get; }
		void SetToken(string jwtToken);
	}
}
