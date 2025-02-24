namespace CardTraderApi.Client;

public class CardTraderApiClientConfig
{
	public Uri CardTraderApiBaseAddress { get; set; } = new Uri("https://api.cardtrader.com/");
	public bool EnableCaching { get; set; } = true;
	public TimeSpan CacheDuration { get; set; } = TimeSpan.FromMinutes(30);
	public bool UseSlidingCacheExpiration { get; set; }

	internal CardTraderApiClientConfig Clone() => new CardTraderApiClientConfig
	{
		CardTraderApiBaseAddress = CardTraderApiBaseAddress,
		CacheDuration = CacheDuration,
		EnableCaching = EnableCaching,
		UseSlidingCacheExpiration = UseSlidingCacheExpiration
	};

	public static CardTraderApiClientConfig GetDefault() => new CardTraderApiClientConfig();
}
