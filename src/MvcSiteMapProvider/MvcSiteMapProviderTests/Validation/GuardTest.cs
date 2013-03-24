using System;
using MvcSiteMapProvider.Validation;
using NUnit.Framework;

namespace MvcSiteMapProviderTests.Validation
{
	class GuardTest
	{
		[Test]
		public void NotNull_throws_argumentexception()
		{
			Assert.Throws<ArgumentException>(() => Guard.NotNull(null, "test"));
		}

		[Test]
		public void NotNull_valid_case()
		{
			Assert.DoesNotThrow(() => Guard.NotNull(new object(), "test"));
		}

		[Test]
		public void NotNullOrEmpty_throws_argumentexception()
		{
			Assert.Throws<ArgumentException>(() => Guard.NotNullOrEmpty(null, "test"));
			Assert.Throws<ArgumentException>(() => Guard.NotNullOrEmpty(string.Empty, "test"));
		}

		[Test]
		public void NotNullOrEmpty_valid_case()
		{
			Assert.DoesNotThrow(() => Guard.NotNull("test", "test"));
		}
	}
}
