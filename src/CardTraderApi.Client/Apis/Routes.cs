using System.Text;

namespace CardTraderApi.Client.Apis;

internal static class Routes
{
	// Inventory
	public const string Products = "api/v2/products";
	public const string ProductsExport = "api/v2/products/export";
	public const string ProductsBulkCreate = "api/v2/products/bulk_create";
	public const string ProductsBulkUpdate = "api/v2/products/bulk_update";
	public const string ProductsBulkDestroy = "api/v2/products/bulk_destroy";
	public const string ExpansionsExport = "api/v2/expansions/export";

	private static readonly CompositeFormat ProductById = CompositeFormat.Parse("api/v2/products/{0}");
	private static readonly CompositeFormat ProductIncrement = CompositeFormat.Parse("api/v2/products/{0}/increment");
	private static readonly CompositeFormat JobById = CompositeFormat.Parse("api/v2/jobs/{0}");

	public static string ForProduct(int id) => string.Format(null, ProductById, id);
	public static string ForProductIncrement(int id) => string.Format(null, ProductIncrement, id);
	public static string ForJob(string uuid) => string.Format(null, JobById, uuid);

	// Marketplace
	public const string MarketplaceProducts = "api/v2/marketplace/products";
	public const string Cart = "api/v2/cart";
	public const string CartAdd = "api/v2/cart/add";
	public const string CartRemove = "api/v2/cart/remove";
	public const string Expansions = "api/v2/expansions";
	public const string Games = "api/v2/games";
}
