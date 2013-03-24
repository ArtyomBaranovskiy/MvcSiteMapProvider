using MvcSiteMapProvider.Extensions;
using NUnit.Framework;

namespace MvcSiteMapProviderTests.Extensions
{
	class StringExtensionsTest
	{
		[TestCase("", null)]
		[TestCase(null, null)]
		[TestCase("Test", "Test")]
		public void AsNullIfEmptyTest(string value, string expected)
		{
			var actual = value.AsNullIfEmpty();
			Assert.AreEqual(expected, actual);
		}
	}
}
