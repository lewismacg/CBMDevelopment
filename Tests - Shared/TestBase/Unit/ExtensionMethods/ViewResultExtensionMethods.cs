using Microsoft.AspNetCore.Mvc;
using System;

namespace Tests.Shared.TestBase.Unit.ExtensionMethods
{
	public static class ViewResultExtensionMethods
	{
		public static TViewData WithViewData<TViewData>(this ViewResult result)
		{
			return result.WithViewDataBase<TViewData>();
		}

		private static TViewData WithViewDataBase<TViewData>(this ViewResult result)
		{
			object model = result.ViewData.Model;

			Type type1 = typeof(TViewData);

			if (model == null) throw new ActionResultExtensionException(string.Format("Expected view data of type '{0}', actual was NULL", (object)type1.Name));

			Type type2 = model.GetType();

			if (typeof(TViewData).IsAssignableFrom(type2)) return (TViewData)model;

			throw new ActionResultExtensionException(string.Format("Expected view data of type '{0}', actual was '{1}'", (object)type1.Name, (object)type2.Name));
		}
	}
}
