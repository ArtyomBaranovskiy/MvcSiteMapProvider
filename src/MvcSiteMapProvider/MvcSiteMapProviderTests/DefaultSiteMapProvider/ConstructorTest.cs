using NUnit.Framework;

namespace MvcSiteMapProviderTests.DefaultSiteMapProvider
{
	class ConstructorTest
	{
		[Test]
		public void DefaultSiteMapPrivider_ctor_throws_no_exceptions()
		{
			var siteMapProvider = new MvcSiteMapProvider.DefaultSiteMapProvider();

			Assert.NotNull(siteMapProvider);
		}
	}
}
