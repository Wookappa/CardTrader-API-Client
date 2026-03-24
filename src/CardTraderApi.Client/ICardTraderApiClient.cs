using CardTraderApi.Client.Apis.Interfaces;

namespace CardTraderApi.Client;

/// <summary>
/// REST client for retrieving data from https://api.cardtrader.com/. This software has no affiliation
/// with cardtrader.com
/// </summary>
public interface ICardTraderApiClient
{
	///<inheritdoc cref="IInventory"/>
	IInventory Inventory { get; }

	///<inheritdoc cref="IMarketplace"/>
	IMarketplace Marketplace { get; }

	///<inheritdoc cref="IWishlists"/>
	IWishlists Wishlists { get; }

	///<inheritdoc cref="IOrders"/>
	IOrders Orders { get; }
}
