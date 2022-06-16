using System;

namespace Tests.Shared.TestBase.Unit.ExtensionMethods
{
	public static class ModelExtensionMethods
	{
		public static void ShouldBe<T>(this object actual, T expected)
		{
			if (!(actual is T obj))
				throw new ArgumentException(string.Format("Expected to be of type '{0}', but was '{1}'", (object)typeof(T).Name, (object)actual.GetType().Name));
			if (!obj.Equals((object)expected))
				throw new ArgumentException(string.Format("Expected to be {0}, but was {1}", (object)expected, (object)(T)actual));
		}
	}
}
