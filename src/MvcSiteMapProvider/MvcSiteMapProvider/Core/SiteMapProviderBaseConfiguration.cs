using System.Collections.Specialized;
using System.Linq;
using MvcSiteMapProvider.Validation;

namespace MvcSiteMapProvider.Core
{
	internal class SiteMapProviderBaseConfiguration
	{
		public SiteMapProviderBaseConfiguration(NameValueCollection attributes)
		{
			Guard.NotNull(attributes, "attributes");

			SiteMapFile = attributes["siteMapFile"];
			EnableLocalization = ParseBool(attributes["enableLocalization"]);
			ResourceKey = attributes["resourceKey"];
			ScanAssemblies = ParseBool(attributes["scanAssembliesForSiteMapNodes"]);
			ScanAssembliesExcept = ParseStringArray(attributes["excludeAssembliesForScan"]);
			ScanAssembliesOnly = ParseStringArray(attributes["includeAssembliesForScan"]);
			IgnoredAttributes = ParseStringArray(attributes["attributesToIgnore"]);
			InheritedAttributes = ParseStringArray(attributes["attributesToInherit"]);
			NodeKeyGenerator = attributes["nodeKeyGenerator"];
			ControllerTypeResolver = attributes["controllerTypeResolver"];
			ActionMethodParameterResolver = attributes["actionMethodParameterResolver"];
			AclModule = attributes["aclModule"];
			SiteMapNodeUrlResolver = attributes["siteMapNodeUrlResolver"];
			SiteMapNodeVisibilityProvider = attributes["siteMapNodeVisibilityProvider"];
			SiteMapProviderEventHandler = attributes["siteMapProviderEventHandler"];
		}

		public string SiteMapFile { get; set; }
		public bool EnableLocalization { get; set; }
		public string ResourceKey { get; set; }
		public bool ScanAssemblies { get; set; }
		public string[] ScanAssembliesExcept { get; set; }
		public string[] ScanAssembliesOnly { get; set; }
		public string[] IgnoredAttributes { get; set; }
		public string[] InheritedAttributes { get; set; }
		public string NodeKeyGenerator { get; set; }
		public string ControllerTypeResolver { get; set; }
		public string ActionMethodParameterResolver { get; set; }
		public string AclModule { get; set; }
		public string SiteMapNodeUrlResolver { get; set; }
		public string SiteMapNodeVisibilityProvider { get; set; }
		public string SiteMapProviderEventHandler { get; set; }

		#region Helper

		protected bool ParseBool(string value)
		{
			bool result;
			return bool.TryParse(value, out result) && result;
		}

		protected string[] ParseStringArray(string value)
		{
			return string.IsNullOrEmpty(value)
				? new string[0]
				: value
					.Split(';', ',')
					.Where(item => !string.IsNullOrEmpty(item))
					.ToArray();
		}

		#endregion
	}
}
