using System;
using System.Collections.Specialized;
using MvcSiteMapProvider.Caching;
using NUnit.Framework;

namespace MvcSiteMapProviderTests.Caching
{
	class CachingSiteMapProviderConfigurationTest
	{
		[Test]
		public void Ctor_throws_argumentexception()
		{
			Assert.Throws<ArgumentException>(() => new CachingSiteMapProviderConfiguration(null));
		}

		[TestCase("cacheKey", "test", "CacheKey")]
		public void Ctor_initializes_string_values_correctly(string name, string value, string propertyName)
		{
			var actual = GetActual(name, value, propertyName);

			Assert.AreEqual(value, actual);
		}

		[TestCase("cacheDuration", "10", "CacheDurationInMinutes", 10)]
		public void Ctor_initializes_int_values_correctly(string name, string value, string propertyName, int expected)
		{
			var actual = GetActual(name, value, propertyName);

			Assert.AreEqual(expected, actual);
		}

		private object GetActual(string name, string value, string propertyName)
		{
			var attributes = new NameValueCollection { { name, value } };
			var configuration = new CachingSiteMapProviderConfiguration(attributes);
			var property = configuration.GetType().GetProperty(propertyName);
			return property.GetValue(configuration, null);
		}
	}
}
