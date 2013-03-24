using System;
using System.Collections.Specialized;
using NUnit.Framework;
using MvcSiteMapProvider.Core;

namespace MvcSiteMapProviderTests.Core
{
	class SiteMapProviderBaseConfigurationTest
	{
		[Test]
		public void Ctor_throws_argumentexception()
		{
			Assert.Throws<ArgumentException>(() => new SiteMapProviderBaseConfiguration(null));
		}

		[TestCase("siteMapFile", "test", "SiteMapFile")]
		[TestCase("resourceKey", "test", "ResourceKey")]
		[TestCase("nodeKeyGenerator", "test", "NodeKeyGenerator")]
		[TestCase("controllerTypeResolver", "test", "ControllerTypeResolver")]
		[TestCase("actionMethodParameterResolver", "test", "ActionMethodParameterResolver")]
		[TestCase("aclModule", "test", "AclModule")]
		[TestCase("siteMapNodeUrlResolver", "test", "SiteMapNodeUrlResolver")]
		[TestCase("siteMapNodeVisibilityProvider", "test", "SiteMapNodeVisibilityProvider")]
		[TestCase("siteMapProviderEventHandler", "test", "SiteMapProviderEventHandler")]
		public void Ctor_initializes_string_values_correctly(string name, string value, string propertyName)
		{
			var actual = GetActual(name, value, propertyName);

			Assert.AreEqual(value, actual);
		}

		[TestCase("attributesToIgnore", "test1;test2,", "IgnoredAttributes", new[] { "test1", "test2" })]
		[TestCase("attributesToInherit", "test1;test2,", "InheritedAttributes", new[] { "test1", "test2" })]
		[TestCase("excludeAssembliesForScan", "test1;test2,", "ScanAssembliesExcept", new[] { "test1", "test2" })]
		[TestCase("includeAssembliesForScan", "test1;test2,", "ScanAssembliesOnly", new[] { "test1", "test2" })]
		public void Ctor_initializes_string_arrays_correctly(string name, string value, string propertyName, string[] expected)
		{
			var actual = GetActual(name, value, propertyName);

			Assert.AreEqual(expected, actual);
		}

		[TestCase("enableLocalization", "False", "EnableLocalization", false)]
		[TestCase("scanAssembliesForSiteMapNodes", "True", "ScanAssemblies", true)]
		[TestCase("scanAssembliesForSiteMapNodes", "asdasd", "ScanAssemblies", false)]
		public void Ctor_initializes_bool_values_correctly(string name, string value, string propertyName, bool expected)
		{
			var actual = GetActual(name, value, propertyName);

			Assert.AreEqual(expected, actual);
		}

		private object GetActual(string name, string value, string propertyName)
		{
			var attributes = new NameValueCollection { { name, value } };
			var configuration = new SiteMapProviderBaseConfiguration(attributes);
			var property = configuration.GetType().GetProperty(propertyName);
			return property.GetValue(configuration, null);
		}
	}
}
