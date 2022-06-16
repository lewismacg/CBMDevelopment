using Moq;

namespace Tests.Shared.TestBase.Unit
{
	public class MoqHelpers
	{
		#region GenerateStrictMock

		public static Mock<T> GenerateStrictMock<T>(params object[] dependencies) where T : class
		{
			return new Mock<T>(MockBehavior.Strict, dependencies);
		}

		#endregion

		#region GeneratePartialMock

		public static Mock<T> GeneratePartialMock<T>(params object[] dependencies) where T : class
		{
			return new Mock<T>(dependencies) { CallBase = true };
		}

		#endregion
	}
}
