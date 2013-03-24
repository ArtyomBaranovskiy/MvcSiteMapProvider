namespace MvcSiteMapProvider.Extensions
{
	internal static class StringExtensions
	{
		public static string AsNullIfEmpty(this string value)
		{
			return string.IsNullOrEmpty(value) ? null : value;
		}
	}
}
