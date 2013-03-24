using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Caching;
using MvcSiteMapProvider.Core;

namespace MvcSiteMapProvider.Caching
{
	/// <summary>
	/// This is the wrapper for SiteMapProviderBase to use HttpCache
	/// </summary>
	public class CachingSiteMapProvider : SiteMapProviderBase
	{
		#region Private

		private CachingSiteMapProviderConfiguration _configuration;
		private int cacheDurationInMinutes;
		private string cacheKey;

		#endregion

		#region Override

		public override void Initialize(string name, System.Collections.Specialized.NameValueCollection attributes)
		{
			base.Initialize(name, attributes);

			_configuration = new CachingSiteMapProviderConfiguration(attributes);

			cacheDurationInMinutes = _configuration.CacheDurationInMinutes;
			cacheKey = _configuration.CacheKey;
		}

		public override bool IsAccessibleToUser(HttpContext context, SiteMapNode node)
		{
			if (isBuildingSiteMap && cacheDurationInMinutes > 0)
			{
				return true;
			}

			return base.IsAccessibleToUser(context, node);
		}

		public override SiteMapNode BuildSiteMap()
		{
			var node = HttpContext.Current.Cache[cacheKey] as SiteMapNode;
			if (node != null)
			{
				return node;
			}

			node = base.BuildSiteMap();
			HttpContext.Current.Cache.Add(
				key: cacheKey,
				value: node,
				dependencies: File.Exists(siteMapFileAbsolute)
					? new CacheDependency(siteMapFileAbsolute)
					: null,
				absoluteExpiration: DateTime.Now.AddMinutes(cacheDurationInMinutes),
				slidingExpiration: Cache.NoSlidingExpiration,
				priority: CacheItemPriority.Default,
				onRemoveCallback: OnCacheExpiration
			);
			return node;
		}

		protected override IEnumerable<SiteMapNode> AddDynamicNodesFor(SiteMapNode node, SiteMapNode parentNode)
		{
			var mvcNode = node as MvcSiteMapNode;

			var cacheDescription = mvcNode.DynamicNodeProvider.GetCacheDescription();
			if (cacheDescription != null)
			{
				HttpContext.Current.Cache.Add(
					key: cacheDescription.Key,
					value: "",
					dependencies: cacheDescription.Dependencies,
					absoluteExpiration: cacheDescription.AbsoluteExpiration,
					slidingExpiration: cacheDescription.SlidingExpiration,
					priority: cacheDescription.Priority,
					onRemoveCallback: OnCacheExpiration
				);
			}

			return base.AddDynamicNodesFor(node, parentNode);
		}

		#endregion

		#region Helper

		private void OnCacheExpiration(string key, object item, CacheItemRemovedReason reason)
		{
			if (item == null)
			{
				return;
			}

			Clear();

			BuildSiteMap();
		}

		#endregion

		/// <summary>
		/// Refreshes this instance.
		/// </summary>
		public void Refresh()
		{
			if (HttpContext.Current.Cache[cacheKey] != null)
			{
				HttpContext.Current.Cache.Remove(cacheKey);
			}
		}
	}
}
