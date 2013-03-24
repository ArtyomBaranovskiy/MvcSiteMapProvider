using System;
using System.Collections.Specialized;
using MvcSiteMapProvider.Extensions;
using MvcSiteMapProvider.Validation;

namespace MvcSiteMapProvider.Caching
{
	internal class CachingSiteMapProviderConfiguration
	{
		public CachingSiteMapProviderConfiguration(NameValueCollection attributes)
		{
			Guard.NotNull(attributes, "attributes");

			CacheDurationInMinutes = ParseInt(attributes["cacheDuration"], DefaultCacheDuration);
			CacheKey = attributes["cacheKey"].AsNullIfEmpty() ?? DefaultCacheKey;
		}

		public int CacheDurationInMinutes { get; set; }
		public string CacheKey { get; set; }

		#region Constant

		private const int DefaultCacheDuration = 5;
		private readonly string DefaultCacheKey = "__MVCSITEMAP_" + Guid.NewGuid();

		#endregion

		#region Helper

		protected int ParseInt(string value, int defaultValue = 0)
		{
			int result;
			return int.TryParse(value, out result) ? result : defaultValue;
		}

		#endregion
	}
}
