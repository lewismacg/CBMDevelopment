using CbmDevelopments.MVC.Attributes;
using CbmDevelopments.MVC.Models;
using Domain.Email.Services;
using Microsoft.AspNetCore.Mvc;

namespace CbmDevelopments.MVC.Controllers
{
	public class HomeController : Controller
	{
		#region Properties and Fields

		private readonly ISendGridEmailService _emailService;

		#endregion

		#region Constructor

		public HomeController(ISendGridEmailService emailService)
		{
			_emailService = emailService;
		}

		#endregion

		#region Landing Page

		#region Get

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[HttpHead]
		public IActionResult Index()
		{
			return View();
		}

		#endregion

		#region Post

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		[ServiceFilter(typeof(RecaptchaAttribute))]
		public IActionResult Index(ContactUsModel model)
		{
			if (ModelState.IsValid == false) return RedirectToAction("ContactUs", model);

			_emailService.SendMail(model.Email, model.Name, model.PhoneNumber, model.Message);

			return RedirectToAction(nameof(Thanks), "Home");
		}

		#endregion

		#endregion

		#region Thanks

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[HttpHead]
		public IActionResult Thanks()
		{
			return View();
		}

		#endregion

		#region Previous Work

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[HttpHead]
		public IActionResult PreviousWork()
		{
			return View();
		}

		#endregion

		#region Investments

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[HttpHead]
		public IActionResult Investments()
		{
			return View();
		}

		#endregion

		#region Contact Us

		#region Get

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[HttpHead]
		public IActionResult ContactUs()
		{
			return View();
		}

		#endregion

		#region Post

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		[ServiceFilter(typeof(RecaptchaAttribute))]
		public IActionResult ContactUs(ContactUsModel model)
		{
			if (ModelState.IsValid == false) return View(model);

			_emailService.SendMail(model.Email, model.Name, model.PhoneNumber, model.Message);

			return RedirectToAction(nameof(Thanks), "Home");
		}

		#endregion

		#endregion

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View();
		}
	}
}
