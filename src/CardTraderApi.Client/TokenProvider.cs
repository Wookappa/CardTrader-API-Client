namespace CardTraderApi.Client
{
	public class TokenProvider : ITokenProvider
	{
		private string _jwtToken;
		private readonly object _lock = new();

		public string JwtToken
		{
			get
			{
				lock (_lock)
				{
					return _jwtToken;
				}
			}
		}

		public void SetToken(string jwtToken)
		{
			if (string.IsNullOrWhiteSpace(jwtToken))
				throw new ArgumentNullException(nameof(jwtToken));

			lock (_lock)
			{
				_jwtToken = jwtToken;
			}
		}
	}
}
