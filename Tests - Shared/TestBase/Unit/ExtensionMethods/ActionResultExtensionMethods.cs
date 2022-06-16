using Microsoft.AspNetCore.Mvc;

namespace Tests.Shared.TestBase.Unit.ExtensionMethods
{
	public static class ActionResultExtensionMethods
	{
		public static T AssertResultIs<T>(this IActionResult result) where T : IActionResult
		{
			if (result is T obj) return obj;
			throw new ActionResultExtensionException(string.Format("Expected result to be of type {0}. It is actually of type {1}.", (object)typeof(T).Name, (object)result.GetType().Name));
		}

		public static RedirectToActionResult AssertActionRedirect(this IActionResult result)
		{
			return AssertResultIs<RedirectToActionResult>(result);
		}

		public static RedirectToRouteResult AssertActionRedirect2(this IActionResult result)
		{
			return AssertResultIs<RedirectToRouteResult>(result);
		}

		public static ViewResult AssertViewRendered(this IActionResult result)
		{
			return AssertResultIs<ViewResult>(result);
		}

		public static PartialViewResult AssertPartialViewRendered(this IActionResult result)
		{
			return AssertResultIs<PartialViewResult>(result);
		}

		public static RedirectResult AssertHttpRedirect(this IActionResult result)
		{
			return AssertResultIs<RedirectResult>(result);
		}
	}
}
