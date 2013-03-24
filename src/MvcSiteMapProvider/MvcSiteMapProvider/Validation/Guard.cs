using System;

namespace MvcSiteMapProvider.Validation
{
	internal static class Guard
	{
		public static void NotNull(object parameterValue, string parameterName)
		{
			if(parameterValue == null)
			{
				throw new ArgumentException("Guard.NotNUll failed.", parameterName);
			}
		}

		public static void NotNullOrEmpty(string parameterValue, string parameterName)
		{
			if(string.IsNullOrEmpty(parameterValue))
			{
				throw new ArgumentException("Guard.NotNullOrEmpty failed.", parameterName);
			}
		}
	}
}
