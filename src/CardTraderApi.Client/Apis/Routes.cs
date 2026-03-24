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
	public const string ProductImports = "api/v2/product_imports";

	private static readonly CompositeFormat ProductById = CompositeFormat.Parse("api/v2/products/{0}");
	private static readonly CompositeFormat ProductIncrement = CompositeFormat.Parse("api/v2/products/{0}/increment");
	private static readonly CompositeFormat ProductUploadImage = CompositeFormat.Parse("api/v2/products/{0}/upload_image");
	private static readonly CompositeFormat JobById = CompositeFormat.Parse("api/v2/jobs/{0}");
	private static readonly CompositeFormat ProductImportById = CompositeFormat.Parse("api/v2/product_imports/{0}");

	public static string ForProduct(int id) => string.Format(null, ProductById, id);
	public static string ForProductIncrement(int id) => string.Format(null, ProductIncrement, id);
	public static string ForProductUploadImage(int id) => string.Format(null, ProductUploadImage, id);
	public static string ForJob(string uuid) => string.Format(null, JobById, uuid);
	public static string ForProductImport(int id) => string.Format(null, ProductImportById, id);

	// Marketplace
	public const string MarketplaceProducts = "api/v2/marketplace/products";
	public const string Cart = "api/v2/cart";
	public const string CartAdd = "api/v2/cart/add";
	public const string CartRemove = "api/v2/cart/remove";
	public const string CartPurchase = "api/v2/cart/purchase";
	public const string ShippingMethods = "api/v2/shipping_methods";
	public const string Expansions = "api/v2/expansions";
	public const string Games = "api/v2/games";

	// Wishlists
	public const string Wishlists = "api/v2/wishlists";

	private static readonly CompositeFormat WishlistById = CompositeFormat.Parse("api/v2/wishlists/{0}");

	public static string ForWishlist(int id) => string.Format(null, WishlistById, id);

	// Orders
	public const string Orders = "api/v2/orders";
	public const string Ct0BoxItems = "api/v2/ct0_box_items";

	private static readonly CompositeFormat OrderById = CompositeFormat.Parse("api/v2/orders/{0}");
	private static readonly CompositeFormat OrderTrackingCode = CompositeFormat.Parse("api/v2/orders/{0}/tracking_code");
	private static readonly CompositeFormat OrderShip = CompositeFormat.Parse("api/v2/orders/{0}/ship");
	private static readonly CompositeFormat OrderRequestCancellation = CompositeFormat.Parse("api/v2/orders/{0}/request-cancellation");
	private static readonly CompositeFormat OrderConfirmCancellation = CompositeFormat.Parse("api/v2/orders/{0}/confirm-cancellation");
	private static readonly CompositeFormat Ct0BoxItemById = CompositeFormat.Parse("api/v2/ct0_box_items/{0}");

	public static string ForOrder(int id) => string.Format(null, OrderById, id);
	public static string ForOrderTrackingCode(int id) => string.Format(null, OrderTrackingCode, id);
	public static string ForOrderShip(int id) => string.Format(null, OrderShip, id);
	public static string ForOrderRequestCancellation(int id) => string.Format(null, OrderRequestCancellation, id);
	public static string ForOrderConfirmCancellation(int id) => string.Format(null, OrderConfirmCancellation, id);
	public static string ForCt0BoxItem(int id) => string.Format(null, Ct0BoxItemById, id);
}
