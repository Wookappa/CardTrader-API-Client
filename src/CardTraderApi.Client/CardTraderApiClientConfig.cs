namespace CardTraderApi.Client;

public class CardTraderApiClientConfig
{
	public Uri CardTraderApiBaseAddress { get; set; } = new Uri("https://api.cardtrader.com/");
	public bool EnableCaching { get; set; } = true;
	public TimeSpan CacheDuration { get; set; } = TimeSpan.FromMinutes(30);
	public bool UseSlidingCacheExpiration { get; set; }
	public int MaxRetryAttempts { get; set; } = 5;
	public TimeSpan InitialRetryDelay { get; set; } = TimeSpan.FromSeconds(2);

	internal CardTraderApiClientConfig Clone() => new CardTraderApiClientConfig
	{
		CardTraderApiBaseAddress = CardTraderApiBaseAddress,
		CacheDuration = CacheDuration,
		EnableCaching = EnableCaching,
		UseSlidingCacheExpiration = UseSlidingCacheExpiration,
		MaxRetryAttempts = MaxRetryAttempts,
		InitialRetryDelay = InitialRetryDelay
	};

	public static CardTraderApiClientConfig GetDefault() => new CardTraderApiClientConfig();
}
