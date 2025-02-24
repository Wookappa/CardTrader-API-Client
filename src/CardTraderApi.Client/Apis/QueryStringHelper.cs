using System.Web;

namespace CardTraderApi.Client.Apis
{
	internal static class QueryStringHelper
	{
		public static string ToQueryString(object obj)
		{
			if (obj == null)
				return string.Empty;

			var queryString = HttpUtility.ParseQueryString(string.Empty);

			foreach (var prop in obj.GetType().GetProperties())
			{
				var value = prop.GetValue(obj, null);
				if (value != null)
					queryString[prop.Name] = value.ToString();
			}

			return queryString.ToString() != string.Empty ? "?" + queryString : string.Empty;
		}
	}
}
