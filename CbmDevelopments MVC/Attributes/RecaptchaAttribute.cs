using Domain.Recaptcha.Entities;
using Domain.Recaptcha.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace CbmDevelopments.MVC.Attributes
{
	public class RecaptchaAttribute : ActionFilterAttribute
	{
		#region Properties and Fields

		private readonly IRecaptchaService _reCaptchaService;

		#endregion

		#region Constructors

		public RecaptchaAttribute(IRecaptchaService reCaptchaService)
		{
			_reCaptchaService = reCaptchaService;
		}

		#endregion

		#region OnActionExecutionAsync

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="next"></param>
		/// <returns></returns>
		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var responseToken = context.HttpContext.Request.Form["g-recaptcha-response"];

			var isReCaptchaValidResponseEnum = await _reCaptchaService.IsReCaptchaValidAsync(responseToken);

			switch (isReCaptchaValidResponseEnum)
			{
				case IsRecaptchaValidResponseEnum.UserIsHuman:
					break;

				case IsRecaptchaValidResponseEnum.VerificationFailed:
					((Controller)context.Controller).ModelState.AddModelError("Recaptcha", "An error occured verifying with reCAPTCHA. Please try again. If this problem persists please email us directly instead using the contact information below.");
					break;

				default:
					throw new ArgumentOutOfRangeException();
			}

			await CallBaseOnActionExecutionAsync(context, next);
		}

		#region CallBaseOnActionExecutionAsync

		protected internal virtual async Task CallBaseOnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			await base.OnActionExecutionAsync(context, next);
		}

		#endregion

		#endregion
	}
}
